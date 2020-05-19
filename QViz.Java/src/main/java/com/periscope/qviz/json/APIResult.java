package com.periscope.qviz.json;

import java.util.Date;

/**
 * JSON Model for Test API Result Values
 */
public class APIResult {

	/**
	 * Identifier of the API Object
	 */
	public String apiId;

	/**
	 * Actual HTTP Status Code returned from the API Response
	 */
	public Integer actualHTTPStatus;

	/**
	 * Actual JSON String returned from the API Response
	 */
	public String actualJSONResult;

	/**
	 * Status of the Test Result (Pass, Fail, Broken)
	 */
	public String status;

	/**
	 * Error Message of the Test Result if it failed/broken
	 */
	public String error;

	/**
	 * Exception JSON String returned from the API Response
	 */
	public String errorJSONString;

	/**
	 * Version of the API
	 */
	public String apiVersion;

	/**
	 * Date and Time on which the Test execution was started
	 */
	public Date executionStartTime;

	/**
	 * Date and Time on which the Test execution was finished
	 */
	public Date executionEndTime;

	/**
	 * Default Constructor
	 */
	public APIResult() {
		this.apiId = "";
		this.actualHTTPStatus = 0;
		this.actualJSONResult = "";
		this.status = "";
		this.error = "";
		this.errorJSONString = "";
		this.apiVersion = "";
		this.executionStartTime = null;
		this.executionEndTime = null;
	}

}
