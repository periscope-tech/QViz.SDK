package com.periscope.qviz.json;

import java.util.Date;

/**
 * JSON Model for Test Case Type Details
 */
public class TestCaseType {

	/**
	 * Identifier of the Test Case Type
	 */
	public String testCaseTypeId;

	/**
	 * Name of the Test Case Type
	 */
	public String name;

	/**
	 * Date and Time on which this Model was Created
	 */
	public Date createdOn;

	/**
	 * Date and Time on which this Model was last Updated
	 */
	public Date updatedOn;

	/**
	 * Default Constructor
	 */
	public TestCaseType() {
		this.testCaseTypeId = "";
		this.name = "";
		this.createdOn = null;
		this.updatedOn = null;
	}

}
