package com.periscope.qviz.client;

import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.microsoft.azure.storage.CloudStorageAccount;
import com.microsoft.azure.storage.blob.CloudBlobClient;
import com.microsoft.azure.storage.blob.CloudBlobContainer;
import com.microsoft.azure.storage.blob.CloudBlockBlob;
import com.periscope.qviz.json.*;
import org.apache.http.util.EntityUtils;

import java.io.File;
import java.io.FileInputStream;
import java.net.URI;
import java.text.SimpleDateFormat;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.stream.Collectors;

/**
 * Client Library for interfacing with QViz APIs
 *
 * <script src="https://cdn.jsdelivr.net/gh/google/code-prettify/loader/run_prettify.js"></script>
 */
public class QVizClient {

	private URI baseURL;
	private AccessUser user;
	private ObjectMapper jsonMapper;
	private String lastResponse;

	/**
	 * Initialize QViz Client with the default Base URL for the API Instance of QViz
	 *
	 * @throws Exception In case of any failures
	 */
	public QVizClient() throws Exception {
		this.baseURL = new URI("https://api.qviz.io");
		initialize();
	}

	/**
	 * Initialize QViz Client with the provided Base URL for the API Instance of QViz
	 *
	 * @param apiURL Base URL to the API Instance of QViz
	 * @throws Exception In case of any failures
	 */
	public QVizClient(String apiURL) throws Exception {
		this.baseURL = new URI(apiURL);
		initialize();
	}

	/**
	 * Initialize QViz Client with the provided Base URL
	 */
	private void initialize() {
		SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss.SSS");
		this.jsonMapper = new ObjectMapper();
		this.jsonMapper.setDateFormat(dateFormat);
	}

	/**
	 * Get the Response from the QViz API that was executed last
	 *
	 * @return Text content of the Response from the QViz API that was executed last
	 */
	public String getLastResponse() {
		return lastResponse;
	}

	/**
	 * Authenticate with QViz using the provided User credentials
	 *
	 * <pre class="prettyprint">
	 * try {
	 *     QVizClient client = new QVizClient();
	 *     client.authenticate("user", "password");
	 *     // Successful authentication
	 * } catch(Exception error) {
	 *     // Failed authentication
	 *     throw error;
	 * }</pre>
	 *
	 * @param userName Name of the User
	 * @param password Password of the User
	 * @throws Exception In case of failure
	 */
	public void authenticate(String userName, String password) throws Exception {
		Authentication authentication = new Authentication(userName, password);
		APIClient apiClient = new APIClient(this.baseURL);
		apiClient.headers.add(new KeyValue("Content-Type", "application/json"));
		apiClient.body = jsonMapper.writeValueAsString(authentication);
		if (apiClient.post("/api/authentication") == 200) {
			// DEBUG: Store the API Response
			lastResponse = EntityUtils.toString(apiClient.response.getEntity());
			this.user = jsonMapper.readValue(lastResponse, AccessUser.class);
		} else {
			throw apiClient.getError();
		}
	}

	/**
	 * Get the list of Projects associated with the User
	 *
	 * <pre class="prettyprint">
	 * try {
	 *     QVizClient client = new QVizClient();
	 *     client.authenticate("user", "password");
	 *     List{@code <Project>} projects = client.getProjects();
	 *     // Successfully retrieved the list of Projects
	 * } catch(Exception error) {
	 *     // Failed to get the list of Projects
	 *     throw error;
	 * }</pre>
	 *
	 * @return List of Projects as Array of Objects
	 * @throws Exception In case of failure
	 */
	public List<Project> getProjects() throws Exception {
		APIClient apiClient = new APIClient(this.baseURL);
		apiClient.headers.add(new KeyValue("Content-Type", "application/json"));
		apiClient.headers.add(new KeyValue("Authorization", "Bearer " + this.user.access_token));
		apiClient.queries.add(new KeyValue("userId", this.user.userId));
		if (apiClient.get("/api/projects") == 200) {
			// DEBUG: Store the API Response
			lastResponse = EntityUtils.toString(apiClient.response.getEntity());
			return jsonMapper.readValue(lastResponse, new TypeReference<List<Project>>() {
			});
		} else {
			throw apiClient.getError();
		}
	}

	/**
	 * Get a specific Project associated with the User
	 *
	 * <pre class="prettyprint">
	 * try {
	 *     QVizClient client = new QVizClient();
	 *     client.authenticate("user", "password");
	 *     Project testProject = client.getProject("Test Project");
	 *     // Successfully retrieved the Project
	 * } catch(Exception error) {
	 *     // Failed to get the Project
	 *     throw error;
	 * }</pre>
	 *
	 * @param projectName Name of the Project to be fetched
	 * @return Project Object
	 * @throws Exception In case of failure
	 */
	public Project getProject(String projectName) throws Exception {
		List<Project> projects = this.getProjects();
		for (Project project : projects) {
			if (project.projectName.equals(projectName)) {
				return project;
			}
		}
		// Throw an Exception if the given Project Name was not found.
		throw new Exception(
			"Project (" + projectName + ") was not found in the User (" + this.user.username + ") account."
		);
	}

	/**
	 * Get the list of Configurations associated with the give Project
	 *
	 * @param projectId Identifier of the Project to get Configurations from
	 * @return List of Configurations for the given Project
	 * @throws Exception In case of failure
	 */
	public List<ProjectConfiguration> getProjectConfigurations(String projectId) throws Exception {
		APIClient apiClient = new APIClient(this.baseURL);
		apiClient.headers.add(new KeyValue("Content-Type", "application/json"));
		apiClient.headers.add(new KeyValue("Authorization", "Bearer " + this.user.access_token));
		apiClient.headers.add(new KeyValue("userId", this.user.userId));
		apiClient.queries.add(new KeyValue("projectId", projectId));
		if (apiClient.get("/api/projectConfigurations") == 200) {
			// DEBUG: Store the API Response
			lastResponse = EntityUtils.toString(apiClient.response.getEntity());
			return jsonMapper.readValue(lastResponse, new TypeReference<List<ProjectConfiguration>>() {
			});
		} else {
			throw apiClient.getError();
		}
	}

	/**
	 * Get a specific Tool Configuration from the Project Configurations
	 *
	 * @param projectId Identifier of the Project
	 * @param toolName  Name of the Tool (SLACK, JIRA, TESTRAIL, etc.)
	 * @return Tool Configuration Data as Linked Hash Map of JSON Key and Value pairs
	 * @throws Exception In case of failure
	 */
	public LinkedHashMap<String, String> getToolConfiguration(String projectId, String toolName) throws Exception {
		List<ProjectConfiguration> projectConfigurations = this.getProjectConfigurations(projectId);
		for (ProjectConfiguration configuration : projectConfigurations) {
			if (configuration.value.indexOf(toolName) > 0) {
				return jsonMapper.readValue(configuration.value,
					new TypeReference<LinkedHashMap<String, String>>() {
					});
			}
		}
		// Throw an Exception if the given Tool Name was not found
		throw new Exception(
			"Project (" + projectId + ") does not contain a Tool Configuration for (" + toolName + ") tool."
		);
	}

	/**
	 * Get the list of GUI Test Cases associated with the specified Project
	 *
	 * <pre class="prettyprint">
	 * try {
	 *     QVizClient client = new QVizClient();
	 *     client.authenticate("user", "password");
	 *     Project guiProject = client.getProject("GUI Test Project");
	 *     List{@code <TestCaseGUI>} guiTestCases = client.getGUITestCases(guiProject.projectId, false, "");
	 *     // Successfully retrieved the list of GUI Test Cases
	 * } catch(Exception error) {
	 *     // Failed to get the list of GUI Test Cases
	 *     throw error;
	 * }</pre>
	 *
	 * @param projectId       Identifier for the Project to fetch GUI Test Cases from
	 * @param onlyAutomated   Get only the GUI Test Cases that are Automated?
	 * @param onlyDescription Get only the GUI Test Case(s) that matches the Description?
	 * @return List of GUI Test Cases as Array of Objects
	 * @throws Exception In case of failure
	 */
	public List<TestCaseGUI> getGUITestCases(
		String projectId,
		boolean onlyAutomated,
		String onlyDescription
	) throws Exception {
		APIClient apiClient = new APIClient(this.baseURL);
		apiClient.headers.add(new KeyValue("Content-Type", "application/json"));
		apiClient.headers.add(new KeyValue("Authorization", "Bearer " + this.user.access_token));
		apiClient.queries.add(new KeyValue("projectId", projectId));
		apiClient.headers.add(new KeyValue("userId",this.user.userId));
		if (apiClient.get("/api/uiTestcases") == 200) {
			// DEBUG: Store the API Response
			lastResponse = EntityUtils.toString(apiClient.response.getEntity());
			List<TestCaseGUI> guiCases = jsonMapper.readValue(lastResponse, new TypeReference<List<TestCaseGUI>>() {
			});
			// Filter only Automated Test Cases (if requested)
			if (onlyAutomated) {
				guiCases = guiCases.stream().filter(
					tc -> tc.isAutomated.equals(true)).collect(Collectors.toList()
				);
			}
			// Filter only Test Cases that matches the Description (if requested)
			if (onlyDescription != null && !onlyDescription.isEmpty()) {
				guiCases = guiCases.stream().filter(
					tc -> tc.description.equals(onlyDescription)).collect(Collectors.toList()
				);
			}
			return guiCases;
		} else {
			throw apiClient.getError();
		}
	}

	/**
	 * Get the list of API Test Cases associated with the specified Project
	 *
	 * <pre class="prettyprint">
	 * try {
	 *     QVizClient client = new QVizClient();
	 *     client.authenticate("user", "password");
	 *     Project apiProject = client.getProject("API Test Project");
	 *     List{@code <TestCaseAPI>} apiTestCases = client.getAPITestCases(apiProject.projectId, false, "");
	 *     // Successfully retrieved the list of API Test Cases
	 * } catch(Exception error) {
	 *     // Failed to get the list of API Test Cases
	 *     throw error;
	 * }</pre>
	 *
	 * @param projectId       Identifier for the Project to fetch API Test Cases from
	 * @param onlyAutomated   Get only the API Test Cases that are Automated?
	 * @param onlyDescription Get only the API Test Case(s) that matches the Description?
	 * @return List of API Test Cases as Array of Objects
	 * @throws Exception In case of failure
	 */
	public List<TestCaseAPI> getAPITestCases(
		String projectId,
		boolean onlyAutomated,
		String onlyDescription
	) throws Exception {
		APIClient apiClient = new APIClient(this.baseURL);
		apiClient.headers.add(new KeyValue("Content-Type", "application/json"));
		apiClient.headers.add(new KeyValue("Authorization", "Bearer " + this.user.access_token));
		apiClient.queries.add(new KeyValue("projectId", projectId));
		apiClient.headers.add(new KeyValue("userId", user.userId));
		if (apiClient.get("/api/apiTestcases") == 200) {
			// DEBUG: Store the API Response
			lastResponse = EntityUtils.toString(apiClient.response.getEntity());
			List<TestCaseAPI> apiCases = jsonMapper.readValue(lastResponse, new TypeReference<List<TestCaseAPI>>() {
			});
			// Filter only Automated Test Cases (if requested)
			if (onlyAutomated) {
				apiCases = apiCases.stream().filter(
					tc -> tc.isAutomated.equals(true)).collect(Collectors.toList()
				);
			}
			// Filter only Test Cases that matches the Description (if requested)
			if (onlyDescription != null && !onlyDescription.isEmpty()) {
				apiCases = apiCases.stream().filter(
					tc -> tc.description.equals(onlyDescription)).collect(Collectors.toList()
				);
			}
			return apiCases;
		} else {
			throw apiClient.getError();
		}
	}

	/**
	 * Upload the given Screen Shot File into Azure BLOB Storage and return the URL
	 *
	 * <pre class="prettyprint">
	 * try {
	 *     QVizClient client = new QVizClient();
	 *     client.authenticate("user", "password");
	 *     File file = new File("files/screenshot_date_time.png");
	 *     String screenShotURL = client.uploadScreenShot("blob-connection-string", "blob-container-name", file);
	 *     // Successfully uploaded the Screen Shot and retrieved the BLOB URL
	 * } catch(Exception error) {
	 *     // Failed to upload the Screen Shot
	 *     throw error;
	 * }</pre>
	 *
	 * @param connection Azure Storage Account Connection String
	 * @param container  Azure Storage Container Name
	 * @param file       Screen Shot File
	 * @return Full URL of the Screen Shot File from Azure BLOB Storage
	 */
	public String uploadScreenShot(String connection, String container, File file) {
		try {
			if (!file.exists()) {
				throw new Exception("Provided Screen Shot File does not exist.");
			}
			CloudStorageAccount account = CloudStorageAccount.parse(connection);
			CloudBlobClient blobClient = account.createCloudBlobClient();
			CloudBlobContainer blobContainer = blobClient.getContainerReference(container);
			CloudBlockBlob blob = blobContainer.getBlockBlobReference(file.getName());
			blob.upload(new FileInputStream(file), file.length());
			return blob.getUri().toString();
		} catch (Exception error) {
			return "";
		}
	}

	/**
	 * Post the provided GUI Testing Results to the QViz Instance
	 *
	 * <pre class="prettyprint">
	 * try {
	 *     QVizClient client = new QVizClient();
	 *     client.authenticate("user", "password");
	 *     GUITestResult guiTestResult = new GUITestResult();
	 *     // Update the Properties of guiTestResult object before posting
	 *     client.postGUITestResults(guiTestResult);
	 *     // Successfully posted the GUI Test Results
	 * } catch(Exception error) {
	 *     // Failed to post the GUI Test Results
	 *     throw error;
	 * }</pre>
	 *
	 * @param guiTestResult GUI Test Results as JSON Object
	 * @throws Exception In case of failure
	 */
	public void postGUITestResults(GUITestResult guiTestResult) throws Exception {
		APIClient apiClient = new APIClient(this.baseURL);
		apiClient.headers.add(new KeyValue("Content-Type", "application/json"));
		apiClient.headers.add(new KeyValue("Authorization", "Bearer " + this.user.access_token));
		apiClient.headers.add(new KeyValue("userId", this.user.userId));
		apiClient.body = jsonMapper.writeValueAsString(guiTestResult);
		if (apiClient.post("/api/ui-results") == 200) {
			// DEBUG: Store the API Response
			lastResponse = EntityUtils.toString(apiClient.response.getEntity());
		} else {
			throw apiClient.getError();
		}
	}

	/**
	 * Post the provided API Testing Results to the QViz Instance
	 *
	 * <pre class="prettyprint">
	 * try {
	 *     QVizClient client = new QVizClient();
	 *     client.authenticate("user", "password");
	 *     APITestResult apiTestResult = new APITestResult();
	 *     // Update the Properties of apiTestResult object before posting
	 *     client.postAPITestResults(apiTestResult);
	 *     // Successfully posted the API Test Results
	 * } catch(Exception error) {
	 *     // Failed to post the API Test Results
	 *     throw error;
	 * }</pre>
	 *
	 * @param apiTestResult API Test Results as JSON Object
	 * @throws Exception In case of failure
	 */
	public void postAPITestResults(APITestResult apiTestResult) throws Exception {
		APIClient apiClient = new APIClient(this.baseURL);
		apiClient.headers.add(new KeyValue("Content-Type", "application/json"));
		apiClient.headers.add(new KeyValue("Authorization", "Bearer " + this.user.access_token));
		apiClient.headers.add(new KeyValue("userId", this.user.userId));
		apiClient.body = jsonMapper.writeValueAsString(apiTestResult);
		if (apiClient.post("/api/api-results") == 200) {
			// DEBUG: Store the API Response
			lastResponse = EntityUtils.toString(apiClient.response.getEntity());
		} else {
			throw apiClient.getError();
		}
	}

	/**
	 * Send the provided GUI/API Testing Results to the TestRail Instance configured with QViz
	 *
	 * @param testResult    GUI or API Test Results as JSON Object
	 * @param testRailURL   URL of the TestRail Instance
	 * @param userName      Unique Name of the TestRail User
	 * @param apiToken      API Access Key of the TestRail User
	 * @param testRailRunID Identifier for the Test Run from TestRail Instance
	 * @param lastError     Last Error Message (if any)
	 * @throws Exception In case of failure
	 */
	public void sendTestResultsToTestRail(
		Object testResult,
		String testRailURL,
		String userName,
		String apiToken,
		String testRailRunID,
		String lastError
	) throws Exception {
		APIClient apiClient = new APIClient(this.baseURL);
		apiClient.headers.add(new KeyValue("Content-Type", "application/json"));
		apiClient.headers.add(new KeyValue("Authorization", "Bearer " + this.user.access_token));
		apiClient.queries.add(new KeyValue("TestRailURL", testRailURL));
		apiClient.queries.add(new KeyValue("username", userName));
		apiClient.queries.add(new KeyValue("passwordKey", apiToken));
		apiClient.queries.add(new KeyValue("postResult", "true"));
		apiClient.queries.add(new KeyValue("TestRailRunID", testRailRunID));
		if (lastError.startsWith("Defect")) {
			apiClient.queries.add(
				new KeyValue(
					"Defect",
					lastError.split(": ")[1].split("::")[0].replace(" :", "")
				)
			);
		}
		apiClient.body = jsonMapper.writeValueAsString(testResult);
		if (apiClient.post("/api/integration/TestRail") == 200) {
			// DEBUG: Store the API Response
			lastResponse = EntityUtils.toString(apiClient.response.getEntity());
		} else {
			throw apiClient.getError();
		}
	}

	/**
	 * Send the provided GUI/API Testing Results to the Slack Instance configured with QViz
	 *
	 * @param testResult  GUI or API Test Results as JSON Object
	 * @param slackURL    URL of the Slack Hooks for sending Messages
	 * @param projectID   Identifier for the Project
	 * @param projectName Name of the Project
	 * @param projectType Type of the Project
	 * @param qvizURL     URL to the QViz App Instance
	 * @param runID       Identifier for the Run
	 * @throws Exception In case of failure
	 */
	public void sendTestResultsToSlack(
		Object testResult,
		String slackURL,
		String projectID,
		String projectName,
		String projectType,
		String qvizURL,
		String runID
	) throws Exception {
		APIClient apiClient = new APIClient(this.baseURL);
		apiClient.headers.add(new KeyValue("Content-Type", "application/json"));
		apiClient.headers.add(new KeyValue("Authorization", "Bearer " + this.user.access_token));
		apiClient.queries.add(new KeyValue("userId", this.user.userId));
		apiClient.queries.add(new KeyValue("projectId", projectID));
		apiClient.queries.add(new KeyValue("slackURL", slackURL));
		apiClient.queries.add(new KeyValue("ProjectName", projectName));
		apiClient.queries.add(new KeyValue("type", projectType));
		apiClient.queries.add(new KeyValue("QIFURL", qvizURL));
		apiClient.queries.add(new KeyValue("runId", runID));
		apiClient.body = jsonMapper.writeValueAsString(testResult);
		if (apiClient.post("/api/integration/Slack") == 200) {
			// DEBUG: Store the API Response
			lastResponse = EntityUtils.toString(apiClient.response.getEntity());
		} else {
			throw apiClient.getError();
		}
	}

	/**
	 * Send the provided GUI/API Testing Results to the JIRA Instance configured with QViz
	 *
	 * @param testResult GUI or API Test Results as JSON Object
	 * @param jiraURL    URL of the JIRA REST v2 API Instance
	 * @param userName   Unique Name of the JIRA User
	 * @param apiToken   JIRA REST v2 API Access Token of the User
	 * @throws Exception In case of failures
	 */
	public void sendTestResultsToJIRA(
		Object testResult,
		String jiraURL,
		String userName,
		String apiToken
	) throws Exception {
		APIClient apiClient = new APIClient(this.baseURL);
		apiClient.headers.add(new KeyValue("Content-Type", "application/json"));
		apiClient.headers.add(new KeyValue("Authorization", "Bearer " + this.user.access_token));
		apiClient.queries.add(new KeyValue("jiraAPIURL", jiraURL));
		apiClient.queries.add(new KeyValue("username", userName));
		apiClient.queries.add(new KeyValue("passwordKey", apiToken));
		apiClient.queries.add(new KeyValue("postComment", "true"));
		apiClient.queries.add(new KeyValue("logDefect", "true"));
		apiClient.body = jsonMapper.writeValueAsString(testResult);
		if (apiClient.post("/api/integration/Jira") == 200) {
			// DEBUG: Store the API Response
			lastResponse = EntityUtils.toString(apiClient.response.getEntity());
		} else {
			throw apiClient.getError();
		}
	}

}
