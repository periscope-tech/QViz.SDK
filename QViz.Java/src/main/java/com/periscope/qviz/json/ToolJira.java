package com.periscope.qviz.json;

/**
 * JSON Model for Tool Configuration Data for JIRA Software
 */
public class ToolJira {

	/**
	 * Name of the Tool Configuration (JIRA)
	 */
	public String toolName;

	/**
	 * URL of the JIRA REST v2 API Instance
	 */
	public String url;

	/**
	 * Unique Name of the JIRA User
	 */
	public String userName;

	/**
	 * JIRA REST v2 API Access Token of the User
	 */
	public String password;

	/**
	 * Unique Key of the JIRA Project
	 */
	public String jiraProjectKey;

	/**
	 * Default Constructor
	 */
	public ToolJira() {
		this.toolName = "";
		this.url = "";
		this.userName = "";
		this.password = "";
		this.jiraProjectKey = "";
	}

}
