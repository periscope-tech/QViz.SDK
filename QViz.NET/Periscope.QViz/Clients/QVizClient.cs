using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Newtonsoft.Json;
using Periscope.QViz.JSON;

namespace Periscope.QViz.Clients
{
	/// <summary>
	/// Client Library for interfacing with QViz APIs
	/// </summary>
	public class QVizClient
	{
		#region Private Properties

		private readonly Uri _baseURL;
		private AccessUser _user;
		private string _lastResponse;

		#endregion

		#region Constructors

		/// <summary>
		/// Initialize QViz Client with the default Base URL for the API Instance of QViz
		/// </summary>
		public QVizClient()
		{
			_baseURL = new Uri("https://api.qviz.io");
		}

		/// <summary>
		/// Initialize QViz Client with the provided Base URL for the API Instance of QViz
		/// </summary>
		/// <param name="baseURL">Base URL to the API Instance of QViz</param>
		public QVizClient(string baseURL)
		{
			_baseURL = new Uri(baseURL);
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Get the Response from the QViz API that was executed last
		/// </summary>
		/// <returns>Text content of the Response from the QViz API that was executed last</returns>
		public string LastResponse()
		{
			return _lastResponse;
		}

		/// <summary>
		/// Authenticate with QViz using the provided User credentials
		/// </summary>
		/// <param name="userName">Name of the User</param>
		/// <param name="password">Password of the User</param>
		/// <exception cref="Exception">In case of failure</exception>
		public void Authenticate(string userName, string password)
		{
			var authentication = new Authentication(userName, password);
			var apiClient = new APIClient(_baseURL);
			apiClient.Headers.Add(new KeyValue("Content-Type", "application/json"));
			apiClient.Body = authentication;
			_user = apiClient.Post<AccessUser>("/api/authentication");
			_lastResponse = apiClient.Response.Content;
			if (!apiClient.Response.IsSuccessful) throw apiClient.GetError();
		}

		/// <summary>
		/// Get the list of Projects associated with the User
		/// </summary>
		/// <returns>List of Projects as Array of Objects</returns>
		/// <exception cref="Exception">In case of failure</exception>
		public List<Project> GetProjects()
		{
			var apiClient = new APIClient(_baseURL);
			apiClient.Headers.Add(new KeyValue("Content-Type", "application/json"));
			apiClient.Headers.Add(new KeyValue("Authorization", "Bearer " + _user.access_token));
			apiClient.Queries.Add(new KeyValue("userId", _user.userId));
			var projects = apiClient.Get<List<Project>>("/api/projects");
			_lastResponse = apiClient.Response.Content;
			if (!apiClient.Response.IsSuccessful) throw apiClient.GetError();
			return projects;
		}

		/// <summary>
		/// Get a specific Project associated with the User
		/// </summary>
		/// <param name="projectName">Name of the Project to be fetched</param>
		/// <returns>Project Object</returns>
		public Project GetProject(string projectName)
		{
			var projects = GetProjects();
			return projects.FirstOrDefault(
				project => project.projectName.Equals(projectName, StringComparison.CurrentCultureIgnoreCase));
		}

		/// <summary>
		/// Get the list of Configurations associated with the give Project
		/// </summary>
		/// <param name="projectId">Identifier of the Project to get Configurations from</param>
		/// <returns>List of Configurations for the given Project</returns>
		public List<ProjectConfiguration> GetProjectConfigurations(string projectId)
		{
			var apiClient = new APIClient(_baseURL);
			apiClient.Headers.Add(new KeyValue("Content-Type", "application/json"));
			apiClient.Headers.Add(new KeyValue("Authorization", "Bearer " + _user.access_token));
			apiClient.Headers.Add(new KeyValue("userId", _user.userId));
			apiClient.Queries.Add(new KeyValue("projectId", projectId));
			var configurations = apiClient.Get<List<ProjectConfiguration>>("/api/projectConfigurations");
			_lastResponse = apiClient.Response.Content;
			if (!apiClient.Response.IsSuccessful) throw apiClient.GetError();
			return configurations;
		}

		/// <summary>
		/// Get a specific Tool Configuration from the Project Configurations
		/// </summary>
		/// <param name="projectId">Identifier of the Project</param>
		/// <param name="toolName">Name of the Tool (SLACK, JIRA, TESTRAIL, etc.)</param>
		/// <typeparam name="T">Type of the JSON Model for Tool Configuration</typeparam>
		/// <returns>Tool Configuration Details as given JSON Model</returns>
		public T GetToolConfiguration<T>(string projectId, string toolName) where T : new()
		{
			var projectConfigurations = GetProjectConfigurations(projectId);
			foreach (var configuration in projectConfigurations)
			{
				if (configuration.value.IndexOf(toolName, StringComparison.Ordinal) > 0)
				{
					return JsonConvert.DeserializeObject<T>(configuration.value);
				}
			}

			// Throw an Exception if the given Tool Name was not found
			throw new Exception(
				"Project (" + projectId + ") does not contain a Tool Configuration for (" + toolName + ") tool."
			);
		}

		/// <summary>
		/// Get the list of GUI Test Cases associated with the specified Project
		/// </summary>
		/// <param name="projectId">Identifier for the Project to fetch GUI Test Cases from</param>
		/// <param name="onlyAutomated">Get only the GUI Test Cases that are Automated?</param>
		/// <param name="onlyDescription">Get only the GUI Test Case(s) that matches the Description?</param>
		/// <returns>List of GUI Test Cases as Array of Objects</returns>
		/// <exception cref="Exception">In case of failure</exception>
		public List<TestCaseGUI> GetGUITestCases(
			string projectId,
			bool onlyAutomated = false,
			string onlyDescription = "")
		{
			var apiClient = new APIClient(_baseURL);
			apiClient.Headers.Add(new KeyValue("Content-Type", "application/json"));
			apiClient.Headers.Add(new KeyValue("Authorization", "Bearer " + _user.access_token));
			apiClient.Queries.Add(new KeyValue("projectId", projectId));
			var guiCases = apiClient.Get<List<TestCaseGUI>>("/api/uiTestcases");
			_lastResponse = apiClient.Response.Content;
			if (!apiClient.Response.IsSuccessful) throw apiClient.GetError();
			// Filter only Automated Test Cases (if requested)
			if (onlyAutomated)
			{
				guiCases = guiCases.Where(tc => tc.isAutomated.Equals(true)).ToList();
			}

			// Filter only Test Cases that matches the Description (if requested)
			if (!string.IsNullOrEmpty(onlyDescription))
			{
				guiCases = guiCases.Where(
					tc => tc.description.Equals(onlyDescription, StringComparison.CurrentCultureIgnoreCase)).ToList();
			}

			return guiCases;
		}

		/// <summary>
		/// Get the list of API Test Cases associated with the specified Project
		/// </summary>
		/// <param name="projectId">Identifier for the Project to fetch API Test Cases from</param>
		/// <param name="onlyAutomated">Get only the API Test Cases that are Automated?</param>
		/// <param name="onlyDescription">Get only the API Test Case(s) that matches the Description?</param>
		/// <returns>List of API Test Cases as Array of Objects</returns>
		/// <exception cref="Exception">In case of failure</exception>
		public List<TestCaseAPI> GetAPITestCases(
			string projectId,
			bool onlyAutomated = false,
			string onlyDescription = "")
		{
			var apiClient = new APIClient(_baseURL);
			apiClient.Headers.Add(new KeyValue("Content-Type", "application/json"));
			apiClient.Headers.Add(new KeyValue("Authorization", "Bearer " + _user.access_token));
			apiClient.Queries.Add(new KeyValue("projectId", projectId));
			var apiCases = apiClient.Get<List<TestCaseAPI>>("/api/apiTestcases");
			_lastResponse = apiClient.Response.Content;
			if (!apiClient.Response.IsSuccessful) throw apiClient.GetError();
			// Filter only Automated Test Cases (if requested)
			if (onlyAutomated)
			{
				apiCases = apiCases.Where(tc => tc.isAutomated.Equals(true)).ToList();
			}

			// Filter only Test Cases that matches the Description (if requested)
			if (!string.IsNullOrEmpty(onlyDescription))
			{
				apiCases = apiCases.Where(
					tc => tc.description.Equals(onlyDescription, StringComparison.CurrentCultureIgnoreCase)).ToList();
			}

			return apiCases;
		}

		/// <summary>
		/// Upload the given Screen Shot File into Azure BLOB Storage and return the URL
		/// </summary>
		/// <param name="connection">Azure Storage Account Connection String</param>
		/// <param name="container">Azure Storage Container Name</param>
		/// <param name="file">Screen Shot File</param>
		/// <returns>Full URL of the Screen Shot File from Azure BLOB Storage</returns>
		/// <exception cref="Exception">In case of failure</exception>
		public static string UploadScreenShot(string connection, string container, FileInfo file)
		{
			try
			{
				// Make sure the File exists
				if (file is null || !file.Exists)
				{
					throw new Exception("Provided Screen Shot File does not exist.");
				}

				// Upload the File to BLOB and return the URL
				var storageAccount = CloudStorageAccount.Parse(connection);
				var blobClient = storageAccount.CreateCloudBlobClient();
				var blobContainer = blobClient.GetContainerReference(container);
				var blob = blobContainer.GetBlockBlobReference(file.Name);
				blob.UploadFromFile(file.FullName);
				return blob.Uri.AbsoluteUri;
			}
			catch (Exception)
			{
				return "";
			}
		}

		/// <summary>
		/// Post the provided GUI Testing Results to the QViz Instance
		/// </summary>
		/// <param name="guiTestResult">GUI Test Results as JSON Object</param>
		public void PostGUITestResults(GUITestResult guiTestResult)
		{
			var apiClient = new APIClient(_baseURL);
			apiClient.Headers.Add(new KeyValue("Content-Type", "application/json"));
			apiClient.Headers.Add(new KeyValue("Authorization", "Bearer " + _user.access_token));
			apiClient.Headers.Add(new KeyValue("userId", _user.userId));
			apiClient.Body = guiTestResult;
			apiClient.Post<object>("/api/ui-results");
			_lastResponse = apiClient.Response.Content;
			if (!apiClient.Response.IsSuccessful) throw apiClient.GetError();
		}

		/// <summary>
		/// Post the provided API Testing Results to the QViz Instance
		/// </summary>
		/// <param name="apiTestResult">API Test Results as JSON Object</param>
		public void PostAPITestResults(APITestResult apiTestResult)
		{
			var apiClient = new APIClient(_baseURL);
			apiClient.Headers.Add(new KeyValue("Content-Type", "application/json"));
			apiClient.Headers.Add(new KeyValue("Authorization", "Bearer " + _user.access_token));
			apiClient.Headers.Add(new KeyValue("userId", _user.userId));
			apiClient.Body = apiTestResult;
			apiClient.Post<object>("/api/api-results");
			_lastResponse = apiClient.Response.Content;
			if (!apiClient.Response.IsSuccessful) throw apiClient.GetError();
		}

		/// <summary>
		/// Send the provided GUI/API Testing Results to the Test Rail Instance configured with QViz
		/// </summary>
		/// <param name="testResult">GUI or API Test Results as JSON Object</param>
		/// <param name="testRailURL">URL of the TestRail Instance</param>
		/// <param name="userName">Unique Name of the TestRail User</param>
		/// <param name="apiToken">API Access Key of the TestRail User</param>
		/// <param name="testRailRunID">Identifier for the Test Run from TestRail Instance</param>
		/// <param name="lastError">Last Error Message (if any)</param>
		public void SendTestResultsToTestRail(
			object testResult,
			string testRailURL,
			string userName,
			string apiToken,
			string testRailRunID,
			string lastError)
		{
			var apiClient = new APIClient(_baseURL);
			apiClient.Headers.Add(new KeyValue("Content-Type", "application/json"));
			apiClient.Headers.Add(new KeyValue("Authorization", "Bearer " + _user.access_token));
			apiClient.Queries.Add(new KeyValue("TestRailURL", testRailURL));
			apiClient.Queries.Add(new KeyValue("username", userName));
			apiClient.Queries.Add(new KeyValue("passwordKey", apiToken));
			apiClient.Queries.Add(new KeyValue("postResult", "true"));
			apiClient.Queries.Add(new KeyValue("TestRailRunID", testRailRunID));
			if (lastError != null && lastError.StartsWith("Defect", StringComparison.CurrentCultureIgnoreCase))
			{
				apiClient.Queries.Add(
					new KeyValue(
						"Defect",
						lastError.Split(": ".ToCharArray())[1].Split("::".ToCharArray())[0]
							.Replace(" :", "")
					)
				);
			}

			apiClient.Body = testResult;
			apiClient.Post<object>("/api/integration/TestRail");
			_lastResponse = apiClient.Response.Content;
			if (!apiClient.Response.IsSuccessful) throw apiClient.GetError();
		}

		/// <summary>
		/// Send the provided GUI/API Testing Results to the Slack Instance configured with QViz
		/// </summary>
		/// <param name="testResult">GUI or API Test Results as JSON Object</param>
		/// <param name="slackURL">URL of the Slack Hooks for sending Messages</param>
		/// <param name="projectID">Identifier for the Project</param>
		/// <param name="projectName">Name of the Project</param>
		/// <param name="projectType">Type of the Project</param>
		/// <param name="qvizURL">URL to the QViz App Instance</param>
		/// <param name="runID">Identifier for the Run</param>
		public void SendTestResultsToSlack(
			object testResult,
			string slackURL,
			string projectID,
			string projectName,
			string projectType,
			string qvizURL,
			string runID)
		{
			var apiClient = new APIClient(_baseURL);
			apiClient.Headers.Add(new KeyValue("Content-Type", "application/json"));
			apiClient.Headers.Add(new KeyValue("Authorization", "Bearer " + _user.access_token));
			apiClient.Queries.Add(new KeyValue("userId", _user.userId));
			apiClient.Queries.Add(new KeyValue("projectId", projectID));
			apiClient.Queries.Add(new KeyValue("slackURL", slackURL));
			apiClient.Queries.Add(new KeyValue("ProjectName", projectName));
			apiClient.Queries.Add(new KeyValue("type", projectType));
			apiClient.Queries.Add(new KeyValue("QIFURL", qvizURL));
			apiClient.Queries.Add(new KeyValue("runId", runID));
			apiClient.Body = testResult;
			apiClient.Post<object>("/api/integration/Slack");
			_lastResponse = apiClient.Response.Content;
			if (!apiClient.Response.IsSuccessful) throw apiClient.GetError();
		}

		/// <summary>
		/// Send the provided GUI/API Testing Results to the JIRA Instance configured with QViz
		/// </summary>
		/// <param name="testResult">GUI or API Test Results as JSON Object</param>
		/// <param name="jiraURL">URL of the JIRA REST v2 API Instance</param>
		/// <param name="userName">Unique Name of the JIRA User</param>
		/// <param name="apiToken">JIRA REST v2 API Access Token of the User</param>
		public void SendTestResultsToJIRA(
			object testResult,
			string jiraURL,
			string userName,
			string apiToken)
		{
			var apiClient = new APIClient(_baseURL);
			apiClient.Headers.Add(new KeyValue("Content-Type", "application/json"));
			apiClient.Headers.Add(new KeyValue("Authorization", "Bearer " + _user.access_token));
			apiClient.Queries.Add(new KeyValue("jiraAPIURL", jiraURL));
			apiClient.Queries.Add(new KeyValue("username", userName));
			apiClient.Queries.Add(new KeyValue("passwordKey", apiToken));
			apiClient.Queries.Add(new KeyValue("postComment", "true"));
			apiClient.Queries.Add(new KeyValue("logDefect", "true"));
			apiClient.Body = testResult;
			apiClient.Post<object>("/api/integration/Jira");
			_lastResponse = apiClient.Response.Content;
			if (!apiClient.Response.IsSuccessful) throw apiClient.GetError();
		}

		#endregion
	}
}