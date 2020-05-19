package com.periscope.qviz.json;

import java.util.ArrayList;
import java.util.List;

/**
 * JSON Model for Configuration Keys
 */
public class ConfigurationKey {

	/**
	 * Identifier of the Configuration Key Object
	 */
	public String configurationKeyId;

	/**
	 * Key of the Configuration
	 */
	public String configurationKey;

	/**
	 * Group of the Configuration
	 */
	public String configurationGroup;

	/**
	 * Description of the Configuration
	 */
	public String description;

	/**
	 * Is this Configuration Active?
	 */
	public Boolean isActive;

	/**
	 * Is this Configuration for a third-party Tool integration?
	 */
	public Boolean isTool;

	/**
	 * Is this Configuration holds sensitive data
	 */
	public Boolean isSensitiveData;

	/**
	 * Regular expression for validating the Configuration
	 */
	public String validationRegex;

	/**
	 * List of Project Configuration Objects
	 */
	public List<ProjectConfiguration> projectConfigurations;

	/**
	 * Default Constructor
	 */
	public ConfigurationKey() {
		this.configurationKeyId = "";
		this.configurationKey = "";
		this.configurationGroup = "";
		this.description = "";
		this.isActive = false;
		this.isTool = false;
		this.isSensitiveData = false;
		this.validationRegex = "";
		this.projectConfigurations = new ArrayList<>();
	}

}
