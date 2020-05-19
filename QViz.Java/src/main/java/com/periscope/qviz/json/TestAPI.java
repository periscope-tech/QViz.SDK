package com.periscope.qviz.json;

import java.util.Date;

/**
 * JSON Model for API Test Case Details
 */
public class TestAPI {

	/**
	 * Identifier of the Test API Object
	 */
	public String testAPIId;

	/**
	 * Identifier of the Test Case Object
	 */
	public String testCaseId;

	/**
	 * Identifier of the API Object
	 */
	public String apiId;

	/**
	 * Serial number of the Test API Object
	 */
	public Integer srNo;

	/**
	 * Date and Time on which this Model was Created
	 */
	public Date createdOn;

	/**
	 * Date and Time on which this Model was last Updated
	 */
	public Date updatedOn;

	/**
	 * API Object associated with this Test API
	 */
	public API api;

	/**
	 * Default Constructor
	 */
	public TestAPI() {
		this.testAPIId = "";
		this.testCaseId = "";
		this.apiId = "";
		this.srNo = 0;
		this.createdOn = null;
		this.updatedOn = null;
		this.api = new API();
	}

}
