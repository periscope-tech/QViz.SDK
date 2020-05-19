package com.periscope.qviz.json;

import java.util.Date;

/**
 * JSON Model for Project Module Details
 */
public class Module {

	/**
	 * Identifier of the Project Module
	 */
	public String moduleId;

	/**
	 * Name of the Project Module
	 */
	public String name;

	/**
	 * Is this Project Module Active?
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
	 * Default Constructor
	 */
	public Module() {
		this.moduleId = "";
		this.name = "";
		this.isActive = false;
		this.createdOn = null;
		this.updatedOn = null;
	}

}
