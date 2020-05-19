package com.periscope.qviz.json;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 * JSON Model for Project Details
 */
public class Project {

	/**
	 * Identifier of the Project
	 */
	public String projectId;

	/**
	 * Name of the Project
	 */
	public String projectName;

	/**
	 * Is this Project Active?
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
	 * Identifier of the Company associated with the Project
	 */
	public String companyId;

	/**
	 * Type of the Project
	 */
	public String projectType;

	/**
	 * List of Test Case Counts under the Project
	 */
	public List<Count> counts;

	/**
	 * List of User Profile Objects associated with the Project
	 */
	public List<UserProfile> userProfiles;

	/**
	 * List of Configurations for the Project
	 */
	public List<ProjectConfiguration> projectConfigurations;

	/**
	 * Default Constructor
	 */
	public Project() {
		this.projectId = "";
		this.projectName = "";
		this.isActive = false;
		this.createdOn = null;
		this.updatedOn = null;
		this.companyId = "";
		this.projectType = "";
		this.counts = new ArrayList<>();
		this.userProfiles = new ArrayList<>();
		this.projectConfigurations = new ArrayList<>();
	}

}
