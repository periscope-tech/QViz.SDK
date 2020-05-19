package com.periscope.qviz.json;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 * JSON Model for User Roles
 */
public class Role {

	/**
	 * Identifier of the User Role
	 */
	public String roleId;

	/**
	 * Name of the User Role
	 */
	public String name;

	/**
	 * Is this User Role Active?
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
	 * Identifier of the Company that the User Role belongs to
	 */
	public String companyId;

	/**
	 * List of User Profile Objects associated with the User Role
	 */
	public List<UserProfile> userProfiles;

	/**
	 * List of Role Permission Objects associated with the User Role
	 */
	public List<RolePermission> rolePermissions;

	/**
	 * Default Constructor
	 */
	public Role() {
		this.roleId = "";
		this.name = "";
		this.isActive = false;
		this.createdOn = null;
		this.updatedOn = null;
		this.companyId = "";
		this.userProfiles = new ArrayList<>();
		this.rolePermissions = new ArrayList<>();
	}

}
