package com.periscope.qviz.json;

import com.fasterxml.jackson.annotation.JsonRawValue;

/**
 * JSON Model for Project Configuration Details
 */
public class ProjectConfiguration {

	/**
	 * Identifier of the Project Configuration Object
	 */
	public String projectConfigurationId;

	/**
	 * Identifier of the Project
	 */
	public String projectId;

	/**
	 * Name of the Project
	 */
	public String projectName;

	/**
	 * Identifier of the Project Configuration Key Object
	 */
	public String configurationKeyId;

	/**
	 * Key of the Project Configuration Object
	 */
	public String key;

	/**
	 * Taxonomy Group of the Project Configuration Object
	 */
	public String group;

	/**
	 * Description of the Project Configuration Object
	 */
	public String description;

	/**
	 * JSON Value of the Project Configuration Object
	 */
	@JsonRawValue
	public String value;

	/**
	 * Is this a Tool Configuration?
	 */
	public boolean isTool;

	/**
	 * Is this Configuration holds sensitive data
	 */
	public Boolean isSensitiveData;

	/**
	 * Regular Expression for Validating the Value of this Project Configuration Object
	 */
	public String validationRegex;

	/**
	 * Project Object associated with the Project Configuration
	 */
	public Project project;

	/**
	 * Project Configuration Key Object associated with the Project Configuration
	 */
	public ConfigurationKey configurationKey;

	/**
	 * Default Constructor
	 */
	public ProjectConfiguration() {
		this.projectConfigurationId = "";
		this.projectId = "";
		this.projectName = "";
		this.configurationKeyId = "";
		this.key = "";
		this.group = "";
		this.description = "";
		this.value = "";
		this.isTool = false;
		this.isSensitiveData = false;
		this.validationRegex = "";
		this.project = new Project();
		this.configurationKey = new ConfigurationKey();
	}

}
