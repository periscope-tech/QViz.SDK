package com.periscope.qviz.json;

import com.fasterxml.jackson.annotation.JsonRawValue;

/**
 * JSON Model for Tool Integration Details
 */
public class Tool {

	/**
	 * Identifier of the third-party Tool Integration
	 */
	public String toolId;

	/**
	 * Name of the third-party Tool Integration
	 */
	public String toolName;

	/**
	 * Description of the third-party Tool Integration
	 */
	public String description;

	/**
	 * Type of the third-party Tool Integration
	 */
	public String toolType;

	/**
	 * JSON Value of the Configuration Template for the third-party Tool Integration
	 */
	@JsonRawValue
	public String configTemplate;

	/**
	 * Is this third-party Tool Integration Active?
	 */
	public boolean isActive;

	/**
	 * Default Constructor
	 */
	public Tool() {
		this.toolId = "";
		this.toolName = "";
		this.description = "";
		this.toolType = "";
		this.configTemplate = "";
	}

}
