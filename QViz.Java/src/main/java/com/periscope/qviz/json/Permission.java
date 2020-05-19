package com.periscope.qviz.json;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 * JSON Model for User Permissions
 */
public class Permission {

	/**
	 * Serial Number of the User Permission Object
	 */
	public Integer srno;

	/**
	 * Identifier of the User Permission Object
	 */
	public String permissionId;

	/**
	 * Name of the User Permission Object
	 */
	public String name;

	/**
	 * Date and Time on which this Model was Created
	 */
	public Date createdOn;

	/**
	 * Date and Time on which this Model was last Updated
	 */
	public Date updatedOn;

	/**
	 * Is this User Permission Active?
	 */
	public Boolean isActive;

	/**
	 * List of User Role Permission Objects
	 */
	public List<RolePermission> rolePermissions;

	/**
	 * Default Constructor
	 */
	public Permission() {
		this.srno = 0;
		this.permissionId = "";
		this.name = "";
		this.createdOn = null;
		this.updatedOn = null;
		this.isActive = false;
		this.rolePermissions = new ArrayList<>();
	}

}
