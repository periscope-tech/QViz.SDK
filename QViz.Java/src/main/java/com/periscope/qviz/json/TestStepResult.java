package com.periscope.qviz.json;

import java.util.Date;

/**
 * JSON Model for GUI Test Step Result Details
 */
public class TestStepResult {

	/**
	 * Identifier of the Test Case Step
	 */
	public String testCaseStepId;

	/**
	 * Actual result of the Test Case Step execution
	 */
	public String actualResult;

	/**
	 * URL of the Screen shot taken when exception occurred during the execution of the Test Case Step
	 */
	public String screenshotURL;

	/**
	 * Status of the Test Case Step execution (Pass, Fail, Broken)
	 */
	public String status;

	/**
	 * Error message from the execution of the Test Case Step
	 */
	public String error;

	/**
	 * Date and Time on which the execution of the Test Case Step was started
	 */
	public Date executionStartTime;

	/**
	 * Date nad Time on which the execution of the Test Case Step was finished
	 */
	public Date executionEndTime;

	/**
	 * Default Constructor
	 */
	public TestStepResult() {
		this.testCaseStepId = "";
		this.actualResult = "";
		this.screenshotURL = "";
		this.status = "";
		this.error = "";
		this.executionStartTime = null;
		this.executionEndTime = null;
	}

}
