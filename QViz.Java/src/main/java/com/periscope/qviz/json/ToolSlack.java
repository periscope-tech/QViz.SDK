package com.periscope.qviz.json;

/**
 * JSON Model for Tool Configuration Data for Slack Communicator
 */
public class ToolSlack {

	/**
	 * Name of the Tool Configuration (SLACK)
	 */
	public String toolName;

	/**
	 * URL of the Slack Hooks for sending Messages
	 */
	public String url;

	/**
	 * Default Constructor
	 */
	public ToolSlack() {
		this.toolName = "";
		this.url = "";
	}

}
