package com.periscope.qviz.json;

import java.util.Date;

/**
 * JSON Model for Test Case Tool Details
 */
public class TestCaseTool {

	/**
	 * Identifier of the third-party Tool integrated with the Test Case
	 */
	public String testCaseToolId;

	/**
	 * Identifier of the Test Case associated with the third-party Tool
	 */
	public String testCaseId;

	/**
	 * Identifier of the third-party Tool
	 */
	public String toolId;

	/**
	 * Value of the third-party Tool integrated with the Test Case
	 */
	public String value;

	/**
	 * Date and Time on which this Model was Created
	 */
	public Date createdOn;

	/**
	 * Date and Time on which this Model was last Updated
	 */
	public Date updatedOn;

	/**
	 * Third-party Tool Integration Object associated with the Test Case
	 */
	public Tool tool;

	/**
	 * Default Constructor
	 */
	public TestCaseTool() {
		this.testCaseToolId = "";
		this.testCaseId = "";
		this.toolId = "";
		this.value = "";
		this.createdOn = null;
		this.updatedOn = null;
		this.tool = new Tool();
	}

}
