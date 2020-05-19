package com.periscope.qviz.json;

import java.util.Date;

/**
 * JSON Model for Test Result Details
 */
public class TestResult {

	/**
	 * Identifier of the Test Case associated with the Test Result
	 */
	public String testCaseId;

	/**
	 * Identifier of the Project Module associated with the Test Result
	 */
	public String moduleId;

	/**
	 * Identifier of the Project Sub Module associated with the Test Result
	 */
	public String subModuleId;

	/**
	 * Actual result from the execution of the Test Case
	 */
	public String actualResult;

	/**
	 * Status of the Test Case execution (Pass, Fail, Broken)
	 */
	public String status;

	/**
	 * Error message from the execution of the Test Case
	 */
	public String error;

	/**
	 * URL of the Screen shot taken when exception occurred during the execution of the Test Case
	 */
	public String errorScreen;

	/**
	 * System/Project that was tested in the Test Result
	 */
	public String sUT;

	/**
	 * Name of the Release that was tested in the Test Result
	 */
	public String releaseName;

	/**
	 * Version number of the Release that was tested in the Test Result
	 */
	public String releaseNo;

	/**
	 * Name of the Scrum Sprint in which the Release was made that was tested in the Test Result
	 */
	public String sprintName;

	/**
	 * Number of the Scrum Sprint in which the Release was made that was tested in the Test Result
	 */
	public String sprintNo;

	/**
	 * Version number of the Build that was tested in the Test Result
	 */
	public String buildVersion;

	/**
	 * Name of the Browser in which the Release was tested in the Test Result
	 */
	public String browserName;

	/**
	 * Version of the Browser in which the Release was tested in the Test Result
	 */
	public String browserVersion;

	/**
	 * Resolution of the Screen in which the Release was tested in the Test Result
	 */
	public String resolution;

	/**
	 * Name of the Operating System in which the Release was tested in the Test Result
	 */
	public String oSName;

	/**
	 * Version of the Operating System in which the Release was tested in the Test Result
	 */
	public String oSVersion;

	/**
	 * Type of the Application that was tested in the Test Result
	 */
	public String appType;

	/**
	 * Version of the Application that was tested in the Test Result
	 */
	public String appVersion;

	/**
	 * Date and Time on which the execution of the Test Case was started
	 */
	public Date executionStartTime;

	/**
	 * Date nad Time on which the execution of the Test Case was finished
	 */
	public Date executionEndTime;

	/**
	 * Identifier of the Project associated with the Test Result
	 */
	public String projectId;

	/**
	 * Environment in which the Release was tested in the Test Result
	 */
	public String environment;

	/**
	 * Identifier of the execution instance for the Test Result
	 */
	public String runID;

	/**
	 * Default Constructor
	 */
	public TestResult() {
		this.testCaseId = "";
		this.moduleId = "";
		this.subModuleId = "";
		this.actualResult = "";
		this.status = "";
		this.error = "";
		this.errorScreen = "";
		this.sUT = "";
		this.releaseName = "";
		this.releaseNo = "";
		this.sprintName = "";
		this.sprintNo = "";
		this.buildVersion = "";
		this.browserName = "";
		this.browserVersion = "";
		this.resolution = "";
		this.oSName = "";
		this.oSVersion = "";
		this.appType = "";
		this.appVersion = "";
		this.executionStartTime = null;
		this.executionEndTime = null;
		this.projectId = "";
		this.environment = "";
		this.runID = "";
	}

}
