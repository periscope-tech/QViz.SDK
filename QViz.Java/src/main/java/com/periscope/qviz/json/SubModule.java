package com.periscope.qviz.json;

import java.util.Date;

/**
 * JSON Model for Sub Module Details
 */
public class SubModule {

	/**
	 * Identifier of the Project Sub Module
	 */
	public String subModuleId;

	/**
	 * Name of the Project Sub Module
	 */
	public String name;

	/**
	 * Identifier of the parent Module for the Project Sub Module
	 */
	public String moduleId;

	/**
	 * Is this Project Sub Module Active?
	 */
	public Boolean isActive;

	/**
	 * Date and Time on which this Model was Created
	 */
	public Date createdOn;

	/**
	 * Date and Time on which this Model was last Updated
	 */
	public Date updatedOn;

	/**
	 * Parent Module Object of the Project Sub Module
	 */
	public Module module;

	/**
	 * Default Constructor
	 */
	public SubModule() {
		this.subModuleId = "";
		this.name = "";
		this.moduleId = "";
		this.isActive = false;
		this.createdOn = null;
		this.updatedOn = null;
		this.module = new Module();
	}

}
