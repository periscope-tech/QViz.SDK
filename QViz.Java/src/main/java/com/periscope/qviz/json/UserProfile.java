package com.periscope.qviz.json;

import java.util.Date;

/**
 * JSON Model for User Profiles
 */
public class UserProfile {

	/**
	 * Identifier of the User Profile
	 */
	public String userProfilesId;

	/**
	 * Identifier of the User with the Profile
	 */
	public String userId;

	/**
	 * Identifier of the Project associated with the User Profile
	 */
	public String projectId;

	/**
	 * Identifier of the Role associated with the User Profile
	 */
	public String roleId;

	/**
	 * Is this User Profile Active?
	 */
	public Boolean isActive;

	/**
	 * Is this User has access to Sensitive data?
	 */
	public Boolean allowSensetiveData;

	/**
	 * Date and Time on which this Model was Created
	 */
	public Date createdOn;

	/**
	 * Date and Time on which this Model was last Updated
	 */
	public Date updatedOn;

	/**
	 * User Object associated with the Profile
	 */
	public User user;

	/**
	 * Role Object associated with the User Profile
	 */
	public Role role;

	/**
	 * Project Object associated with the User Profile
	 */
	public Project project;

	/**
	 * Default Constructor
	 */
	public UserProfile() {
		this.userProfilesId = "";
		this.userId = "";
		this.projectId = "";
		this.roleId = "";
		this.isActive = false;
		this.allowSensetiveData = false;
		this.createdOn = null;
		this.updatedOn = null;
		this.user = new User();
		this.role = new Role();
		this.project = new Project();
	}

}
