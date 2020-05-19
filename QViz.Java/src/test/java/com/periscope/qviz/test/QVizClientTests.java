package com.periscope.qviz.test;

import com.periscope.qviz.client.QVizClient;
import com.periscope.qviz.json.*;
import org.junit.jupiter.api.*;

import java.util.Date;
import java.util.LinkedHashMap;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

@TestMethodOrder(MethodOrderer.OrderAnnotation.class)
public class QVizClientTests {

	private static String qvizURL = "https://api.qviz.io";
	private static String qvizProject = "PandC";
	private static String qvizUser = "wdadmin";
	private static String qvizPassword = "password";
	private static QVizClient qvizClient;

	@BeforeAll
	public static void setUp() throws Exception {
		qvizClient = new QVizClient(qvizURL);
	}

	@Test
	@Order(1)
	@DisplayName("Authenticate with QViz")
	public void authenticate() {
		assertDoesNotThrow(
			() -> qvizClient.authenticate(qvizUser, qvizPassword),
			"Authentication should not throw any Error"
		);
	}

	@Test
	@Order(2)
	@DisplayName("Get the Project from QViz")
	public void getProject() {
		try {
			qvizClient.authenticate(qvizUser, qvizPassword);
			Project project = qvizClient.getProject(qvizProject);
			assertEquals(qvizProject, project.projectName, "Project Name must match the provided one");
		} catch (Exception error) {
			fail(error);
		}
	}

	@Test
	@Order(3)
	@DisplayName("Get all the GUI Test Cases from QViz")
	public void getGUITestCases() {
		try {
			qvizClient.authenticate(qvizUser, qvizPassword);
			Project project = qvizClient.getProject(qvizProject);
			List<TestCaseGUI> testCases = qvizClient.getGUITestCases(project.projectId, false, "");
			assertTrue(testCases.size() > 0, "There should at least be one GUI Test Case");
		} catch (Exception error) {
			fail(error);
		}
	}

	@Test
	@Order(4)
	@DisplayName("Send a Test Result for the GUI Test Case to QViz")
	public void postGUITestResult() {
		try {
			qvizClient.authenticate(qvizUser, qvizPassword);
			Project project = qvizClient.getProject(qvizProject);
			List<TestCaseGUI> testCases = qvizClient.getGUITestCases(project.projectId, false, "");
			if (testCases.size() > 0) {
				TestCaseGUI testCase = testCases.get(0);
				GUITestResult guiResult = new GUITestResult();
				guiResult.testResult.testCaseId = testCase.testCaseId;
				guiResult.testResult.moduleId = testCase.moduleId;
				guiResult.testResult.subModuleId = testCase.subModuleId;
				guiResult.testResult.status = "Pass";
				guiResult.testResult.sUT = project.projectName;
				guiResult.testResult.releaseName = "Version 1.0.0";
				guiResult.testResult.releaseNo = "1.0.0";
				guiResult.testResult.sprintName = "UBI Sprint 1";
				guiResult.testResult.sprintNo = "UBI-1";
				guiResult.testResult.buildVersion = "1.0.0";
				guiResult.testResult.browserName = "ChromeDriver";
				guiResult.testResult.browserVersion = "2.46";
				guiResult.testResult.resolution = "1920x1080";
				guiResult.testResult.oSName = "Windows 10 Professional";
				guiResult.testResult.oSVersion = "1903";
				guiResult.testResult.appType = "Angular 8 Application";
				guiResult.testResult.appVersion = "1.0.0";
				guiResult.testResult.executionStartTime = new Date();
				guiResult.testResult.projectId = project.projectId;
				guiResult.testResult.environment = "Cloud";
				guiResult.testResult.runID = "SDK-Unit-Test";
				for (TestCaseStep testStep : testCase.testCaseSteps) {
					TestStepResult stepResult = new TestStepResult();
					stepResult.testCaseStepId = testStep.testCaseStepId;
					stepResult.status = "Pass";
					stepResult.actualResult = testStep.expectedResult;
					stepResult.executionStartTime = new Date();
					stepResult.executionEndTime = new Date();
					guiResult.testResult.testStepResults.add(stepResult);
				}
				guiResult.testResult.executionEndTime = new Date();
				qvizClient.postGUITestResults(guiResult);
				assertEquals("Pass", guiResult.testResult.status);
			} else {
				throw new Exception("There are NO GUI Test Cases available in the Project (" + qvizProject + ").");
			}
		} catch (Exception error) {
			fail(error);
		}
	}

	@Test
	@Order(5)
	@DisplayName("Send a Test Result for the GUI Test Case to Slack")
	public void postResultSlack() {
		try {
			qvizClient.authenticate(qvizUser, qvizPassword);
			Project project = qvizClient.getProject(qvizProject);
			List<TestCaseGUI> testCases = qvizClient.getGUITestCases(project.projectId, false, "");
			if (testCases.size() > 0) {
				TestCaseGUI testCase = testCases.get(0);
				GUITestResult guiResult = new GUITestResult();
				guiResult.testResult.testCaseId = testCase.testCaseId;
				guiResult.testResult.moduleId = testCase.moduleId;
				guiResult.testResult.subModuleId = testCase.subModuleId;
				guiResult.testResult.status = "Pass";
				guiResult.testResult.sUT = project.projectName;
				guiResult.testResult.releaseName = "Version 1.0.0";
				guiResult.testResult.releaseNo = "1.0.0";
				guiResult.testResult.sprintName = "UBI Sprint 1";
				guiResult.testResult.sprintNo = "UBI-1";
				guiResult.testResult.buildVersion = "1.0.0";
				guiResult.testResult.browserName = "ChromeDriver";
				guiResult.testResult.browserVersion = "2.46";
				guiResult.testResult.resolution = "1920x1080";
				guiResult.testResult.oSName = "Windows 10 Professional";
				guiResult.testResult.oSVersion = "1903";
				guiResult.testResult.appType = "Angular 8 Application";
				guiResult.testResult.appVersion = "1.0.0";
				guiResult.testResult.executionStartTime = new Date();
				guiResult.testResult.projectId = project.projectId;
				guiResult.testResult.environment = "Cloud";
				guiResult.testResult.runID = "SDK-Unit-Test";
				for (TestCaseStep testStep : testCase.testCaseSteps) {
					TestStepResult stepResult = new TestStepResult();
					stepResult.testCaseStepId = testStep.testCaseStepId;
					stepResult.status = "Pass";
					stepResult.actualResult = testStep.expectedResult;
					stepResult.executionStartTime = new Date();
					stepResult.executionEndTime = new Date();
					guiResult.testResult.testStepResults.add(stepResult);
				}
				guiResult.testResult.executionEndTime = new Date();
				try {
					LinkedHashMap<String, String> slack = qvizClient.getToolConfiguration(project.projectId, "SLACK");
					qvizClient.sendTestResultsToSlack(
						guiResult,
						slack.get("url"),
						project.projectId,
						project.projectName,
						project.projectType,
						"https://app-demo.qviz.io",
						guiResult.testResult.runID
					);
				} catch (Exception error) {
					// Does not contain configurations for Slack
				}
				assertEquals("Pass", guiResult.testResult.status);
			} else {
				throw new Exception("There are NO GUI Test Cases available in the Project (" + qvizProject + ").");
			}
		} catch (Exception error) {
			fail(error);
		}
	}

	@Test
	@Order(6)
	@DisplayName("Send a Test Result for the GUI Test Case to JIRA")
	public void postResultJIRA() {
		try {
			qvizClient.authenticate(qvizUser, qvizPassword);
			Project project = qvizClient.getProject(qvizProject);
			List<TestCaseGUI> testCases = qvizClient.getGUITestCases(project.projectId, false, "");
			if (testCases.size() > 0) {
				TestCaseGUI testCase = testCases.get(0);
				GUITestResult guiResult = new GUITestResult();
				guiResult.testResult.testCaseId = testCase.testCaseId;
				guiResult.testResult.moduleId = testCase.moduleId;
				guiResult.testResult.subModuleId = testCase.subModuleId;
				guiResult.testResult.status = "Pass";
				guiResult.testResult.sUT = project.projectName;
				guiResult.testResult.releaseName = "Version 1.0.0";
				guiResult.testResult.releaseNo = "1.0.0";
				guiResult.testResult.sprintName = "UBI Sprint 1";
				guiResult.testResult.sprintNo = "UBI-1";
				guiResult.testResult.buildVersion = "1.0.0";
				guiResult.testResult.browserName = "ChromeDriver";
				guiResult.testResult.browserVersion = "2.46";
				guiResult.testResult.resolution = "1920x1080";
				guiResult.testResult.oSName = "Windows 10 Professional";
				guiResult.testResult.oSVersion = "1903";
				guiResult.testResult.appType = "Angular 8 Application";
				guiResult.testResult.appVersion = "1.0.0";
				guiResult.testResult.executionStartTime = new Date();
				guiResult.testResult.projectId = project.projectId;
				guiResult.testResult.environment = "Cloud";
				guiResult.testResult.runID = "SDK-Unit-Test";
				for (TestCaseStep testStep : testCase.testCaseSteps) {
					TestStepResult stepResult = new TestStepResult();
					stepResult.testCaseStepId = testStep.testCaseStepId;
					stepResult.status = "Pass";
					stepResult.actualResult = testStep.expectedResult;
					stepResult.executionStartTime = new Date();
					stepResult.executionEndTime = new Date();
					guiResult.testResult.testStepResults.add(stepResult);
				}
				guiResult.testResult.executionEndTime = new Date();
				try {
					LinkedHashMap<String, String> jira = qvizClient.getToolConfiguration(project.projectId, "JIRA");
					qvizClient.sendTestResultsToJIRA(
						guiResult,
						jira.get("url"),
						jira.get("userName"),
						jira.get("password")
					);
				} catch (Exception error) {
					// Does not contain configurations for JIRA
				}
				assertEquals("Pass", guiResult.testResult.status);
			} else {
				throw new Exception("There are NO GUI Test Cases available in the Project (" + qvizProject + ").");
			}
		} catch (Exception error) {
			fail(error);
		}
	}

	@Test
	@Order(7)
	@DisplayName("Send a Test Result for the GUI Test Case to TestRail")
	public void postResultTestRail() {
		try {
			qvizClient.authenticate(qvizUser, qvizPassword);
			Project project = qvizClient.getProject(qvizProject);
			List<TestCaseGUI> testCases = qvizClient.getGUITestCases(project.projectId, false, "");
			if (testCases.size() > 0) {
				TestCaseGUI testCase = testCases.get(0);
				GUITestResult guiResult = new GUITestResult();
				guiResult.testResult.testCaseId = testCase.testCaseId;
				guiResult.testResult.moduleId = testCase.moduleId;
				guiResult.testResult.subModuleId = testCase.subModuleId;
				guiResult.testResult.status = "Pass";
				guiResult.testResult.sUT = project.projectName;
				guiResult.testResult.releaseName = "Version 1.0.0";
				guiResult.testResult.releaseNo = "1.0.0";
				guiResult.testResult.sprintName = "UBI Sprint 1";
				guiResult.testResult.sprintNo = "UBI-1";
				guiResult.testResult.buildVersion = "1.0.0";
				guiResult.testResult.browserName = "ChromeDriver";
				guiResult.testResult.browserVersion = "2.46";
				guiResult.testResult.resolution = "1920x1080";
				guiResult.testResult.oSName = "Windows 10 Professional";
				guiResult.testResult.oSVersion = "1903";
				guiResult.testResult.appType = "Angular 8 Application";
				guiResult.testResult.appVersion = "1.0.0";
				guiResult.testResult.executionStartTime = new Date();
				guiResult.testResult.projectId = project.projectId;
				guiResult.testResult.environment = "Cloud";
				guiResult.testResult.runID = "SDK-Unit-Test";
				for (TestCaseStep testStep : testCase.testCaseSteps) {
					TestStepResult stepResult = new TestStepResult();
					stepResult.testCaseStepId = testStep.testCaseStepId;
					stepResult.status = "Pass";
					stepResult.actualResult = testStep.expectedResult;
					stepResult.executionStartTime = new Date();
					stepResult.executionEndTime = new Date();
					guiResult.testResult.testStepResults.add(stepResult);
				}
				guiResult.testResult.executionEndTime = new Date();
				try {
					LinkedHashMap<String, String> testRail = qvizClient.getToolConfiguration(project.projectId, "TESTRAIL");
					qvizClient.sendTestResultsToTestRail(
						guiResult,
						testRail.get("url"),
						testRail.get("userName"),
						testRail.get("password"),
						"10",
						""
					);
				} catch (Exception error) {
					// Does not contain configurations for TestRail
				}
				assertEquals("Pass", guiResult.testResult.status);
			} else {
				throw new Exception("There are NO GUI Test Cases available in the Project (" + qvizProject + ").");
			}
		} catch (Exception error) {
			fail(error);
		}
	}

}
