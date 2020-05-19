package com.periscope.qviz.json;

/**
 * JSON Model for Tool Configuration Data for TestRail Software
 */
public class ToolTestRail {

	/**
	 * Name of the Tool Configuration (TESTRAIL)
	 */
	public String toolName;

	/**
	 * URL of the TestRail Instance
	 */
	public String url;

	/**
	 * Unique Name of the TestRail User
	 */
	public String userName;

	/**
	 * API Access Key of the TestRail User
	 */
	public String password;

	/**
	 * Default Constructor
	 */
	public ToolTestRail() {
		this.toolName = "";
		this.url = "";
		this.userName = "";
		this.password = "";
	}

}
