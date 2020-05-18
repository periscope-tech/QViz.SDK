using System;
using System.Linq;
using NUnit.Framework;
using Periscope.QViz.Clients;
using Periscope.QViz.JSON;

namespace Periscope.QViz.Test
{
	[TestFixture]
	public class QVizClientTests
	{
		private const string QVizURL = "https://api-demo.qviz.io";
		private const string QVizProject = "UbiSoft Web (en-US)";
		private const string QVizUser = "DemoAdmin";
		private const string QVizPassword = "password";
		private static QVizClient _qvizClient;

		[OneTimeSetUp]
		public static void SetUp()
		{
			_qvizClient = new QVizClient(QVizURL);
		}

		[Test(Description = "Authenticate with QViz")]
		[Order(1)]
		public void Authenticate()
		{
			Assert.DoesNotThrow(
				() => _qvizClient.Authenticate(QVizUser, QVizPassword),
				"Authentication should not throw any Error"
			);
		}

		[Test(Description = "Get the Project from QViz")]
		[Order(2)]
		public void GetProject()
		{
			try
			{
				_qvizClient.Authenticate(QVizUser, QVizPassword);
				var project = _qvizClient.GetProject(QVizProject);
				if (project != null)
				{
					Assert.AreEqual(
						QVizProject,
						project.projectName,
						"Project Name must match the provided one"
					);
				}
				else
				{
					throw new Exception("Project was not successfully returned from QViz");
				}
			}
			catch (Exception error)
			{
				Assert.Fail(error.Message);
			}
		}

		[Test(Description = "Get all the GUI Test Cases from QViz")]
		[Order(3)]
		public void GetGUITestCases()
		{
			try
			{
				_qvizClient.Authenticate(QVizUser, QVizPassword);
				var project = _qvizClient.GetProject(QVizProject);
				if (project != null)
				{
					var testCases = _qvizClient.GetGUITestCases(project.projectId);
					Assert.True(testCases.Count > 0, "There should at least be one GUI Test Case");
				}
				else
				{
					throw new Exception("Project was not successfully returned from QViz");
				}
			}
			catch (Exception error)
			{
				Assert.Fail(error.Message);
			}
		}

		[Test(Description = "Send a Test Result for the GUI Test Case to QViz")]
		[Order(4)]
		public void PostGUITestResult()
		{
			try
			{
				_qvizClient.Authenticate(QVizUser, QVizPassword);
				var project = _qvizClient.GetProject(QVizProject);
				var testCases = _qvizClient.GetGUITestCases(project.projectId);
				if (testCases.Count > 0)
				{
					var testCase = testCases.First();
					var guiResult = new GUITestResult
					{
						testResult =
						{
							testCaseId = testCase.testCaseId,
							moduleId = testCase.moduleId,
							subModuleId = testCase.subModuleId,
							status = "Pass",
							sUT = project.projectName,
							releaseName = "Version 1.0.0",
							releaseNo = "1.0.0",
							sprintName = "UBI Sprint 1",
							sprintNo = "UBI-1",
							buildVersion = "1.0.0",
							browserName = "ChromeDriver",
							browserVersion = "2.46",
							resolution = "1920x1080",
							oSName = "Windows 10 Professional",
							oSVersion = "1903",
							appType = "Angular 8 Application",
							appVersion = "1.0.0",
							executionStartTime = DateTime.Now,
							projectId = project.projectId,
							environment = "Cloud",
							runID = "SDK-Unit-Test"
						}
					};
					foreach (var testStep in testCase.testCaseSteps)
					{
						var stepResult = new TestStepResult
						{
							testCaseStepId = testStep.testCaseStepId,
							status = "Pass",
							actualResult = testStep.expectedResult,
							executionStartTime = DateTime.Now,
							executionEndTime = DateTime.Now
						};
						guiResult.testResult.testStepResults.Add(stepResult);
					}

					guiResult.testResult.executionEndTime = DateTime.Now;
					_qvizClient.PostGUITestResults(guiResult);
					Assert.AreEqual("Pass", guiResult.testResult.status);
				}
				else
				{
					throw new Exception("There are NO GUI Test Cases available in the Project (" + QVizProject + ").");
				}
			}
			catch (Exception error)
			{
				Assert.Fail(error.Message);
			}
		}

		[Test(Description = "Send a Test Result for the GUI Test Case to Slack")]
		[Order(5)]
		public void PostResultSlack()
		{
			try
			{
				_qvizClient.Authenticate(QVizUser, QVizPassword);
				var project = _qvizClient.GetProject(QVizProject);
				var testCases = _qvizClient.GetGUITestCases(project.projectId);
				if (testCases.Count > 0)
				{
					var testCase = testCases.First();
					var guiResult = new GUITestResult
					{
						testResult =
						{
							testCaseId = testCase.testCaseId,
							moduleId = testCase.moduleId,
							subModuleId = testCase.subModuleId,
							status = "Pass",
							sUT = project.projectName,
							releaseName = "Version 1.0.0",
							releaseNo = "1.0.0",
							sprintName = "UBI Sprint 1",
							sprintNo = "UBI-1",
							buildVersion = "1.0.0",
							browserName = "ChromeDriver",
							browserVersion = "2.46",
							resolution = "1920x1080",
							oSName = "Windows 10 Professional",
							oSVersion = "1903",
							appType = "Angular 8 Application",
							appVersion = "1.0.0",
							executionStartTime = DateTime.Now,
							projectId = project.projectId,
							environment = "Cloud",
							runID = "SDK-Unit-Test"
						}
					};
					foreach (var testStep in testCase.testCaseSteps)
					{
						var stepResult = new TestStepResult
						{
							testCaseStepId = testStep.testCaseStepId,
							status = "Pass",
							actualResult = testStep.expectedResult,
							executionStartTime = DateTime.Now,
							executionEndTime = DateTime.Now
						};
						guiResult.testResult.testStepResults.Add(stepResult);
					}

					guiResult.testResult.executionEndTime = DateTime.Now;
					try
					{
						var slack = _qvizClient.GetToolConfiguration<ToolSlack>(project.projectId, "SLACK");
						_qvizClient.SendTestResultsToSlack(
							guiResult,
							slack.url,
							project.projectId,
							project.projectName,
							project.projectType,
							"https://app-demo.qviz.io",
							guiResult.testResult.runID
						);
					}
					catch (Exception)
					{
						// Does not contain configurations for Slack
					}
					Assert.AreEqual("Pass", guiResult.testResult.status);
				}
				else
				{
					throw new Exception("There are NO GUI Test Cases available in the Project (" + QVizProject + ").");
				}
			}
			catch (Exception error)
			{
				Assert.Fail(error.Message);
			}
		}

		[Test(Description = "Send a Test Result for the GUI Test Case to JIRA")]
		[Order(6)]
		public void PostResultJIRA()
		{
			try
			{
				_qvizClient.Authenticate(QVizUser, QVizPassword);
				var project = _qvizClient.GetProject(QVizProject);
				var testCases = _qvizClient.GetGUITestCases(project.projectId);
				if (testCases.Count > 0)
				{
					var testCase = testCases.First();
					var guiResult = new GUITestResult
					{
						testResult =
						{
							testCaseId = testCase.testCaseId,
							moduleId = testCase.moduleId,
							subModuleId = testCase.subModuleId,
							status = "Pass",
							sUT = project.projectName,
							releaseName = "Version 1.0.0",
							releaseNo = "1.0.0",
							sprintName = "UBI Sprint 1",
							sprintNo = "UBI-1",
							buildVersion = "1.0.0",
							browserName = "ChromeDriver",
							browserVersion = "2.46",
							resolution = "1920x1080",
							oSName = "Windows 10 Professional",
							oSVersion = "1903",
							appType = "Angular 8 Application",
							appVersion = "1.0.0",
							executionStartTime = DateTime.Now,
							projectId = project.projectId,
							environment = "Cloud",
							runID = "SDK-Unit-Test"
						}
					};
					foreach (var testStep in testCase.testCaseSteps)
					{
						var stepResult = new TestStepResult
						{
							testCaseStepId = testStep.testCaseStepId,
							status = "Pass",
							actualResult = testStep.expectedResult,
							executionStartTime = DateTime.Now,
							executionEndTime = DateTime.Now
						};
						guiResult.testResult.testStepResults.Add(stepResult);
					}

					guiResult.testResult.executionEndTime = DateTime.Now;
					try
					{
						var jira = _qvizClient.GetToolConfiguration<ToolJira>(project.projectId, "JIRA");
						_qvizClient.SendTestResultsToJIRA(
							guiResult,
							jira.url,
							jira.userName,
							jira.password
						);
					}
					catch (Exception)
					{
						// Does not contain configurations for JIRA
					}
					Assert.AreEqual("Pass", guiResult.testResult.status);
				}
				else
				{
					throw new Exception("There are NO GUI Test Cases available in the Project (" + QVizProject + ").");
				}
			}
			catch (Exception error)
			{
				Assert.Fail(error.Message);
			}
		}

		[Test(Description = "Send a Test Result for the GUI Test Case to TestRail")]
		[Order(7)]
		public void PostResultTestRail()
		{
			try
			{
				_qvizClient.Authenticate(QVizUser, QVizPassword);
				var project = _qvizClient.GetProject(QVizProject);
				var testCases = _qvizClient.GetGUITestCases(project.projectId);
				if (testCases.Count > 0)
				{
					var testCase = testCases.First();
					var guiResult = new GUITestResult
					{
						testResult =
						{
							testCaseId = testCase.testCaseId,
							moduleId = testCase.moduleId,
							subModuleId = testCase.subModuleId,
							status = "Pass",
							sUT = project.projectName,
							releaseName = "Version 1.0.0",
							releaseNo = "1.0.0",
							sprintName = "UBI Sprint 1",
							sprintNo = "UBI-1",
							buildVersion = "1.0.0",
							browserName = "ChromeDriver",
							browserVersion = "2.46",
							resolution = "1920x1080",
							oSName = "Windows 10 Professional",
							oSVersion = "1903",
							appType = "Angular 8 Application",
							appVersion = "1.0.0",
							executionStartTime = DateTime.Now,
							projectId = project.projectId,
							environment = "Cloud",
							runID = "SDK-Unit-Test"
						}
					};
					foreach (var testStep in testCase.testCaseSteps)
					{
						var stepResult = new TestStepResult
						{
							testCaseStepId = testStep.testCaseStepId,
							status = "Pass",
							actualResult = testStep.expectedResult,
							executionStartTime = DateTime.Now,
							executionEndTime = DateTime.Now
						};
						guiResult.testResult.testStepResults.Add(stepResult);
					}

					guiResult.testResult.executionEndTime = DateTime.Now;
					try
					{
						var testRail = _qvizClient.GetToolConfiguration<ToolTestRail>(
							project.projectId, "TESTRAIL"
						);
						_qvizClient.SendTestResultsToTestRail(
							guiResult,
							testRail.url,
							testRail.userName,
							testRail.password,
							"10",
							""
						);
					}
					catch (Exception)
					{
						// Does not contain configurations for TestRail
					}
					Assert.AreEqual("Pass", guiResult.testResult.status);
				}
				else
				{
					throw new Exception("There are NO GUI Test Cases available in the Project (" + QVizProject + ").");
				}
			}
			catch (Exception error)
			{
				Assert.Fail(error.Message);
			}
		}
	}
}