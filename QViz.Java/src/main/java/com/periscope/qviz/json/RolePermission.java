package com.periscope.qviz.json;

import java.util.Date;

/**
 * JSON Model for User Role Permissions
 */
public class RolePermission {

	/**
	 * Identifier of the User Role Permission Object
	 */
	public String rolePermissionId;

	/**
	 * Identifier of the User Role Object
	 */
	public String roleId;

	/**
	 * Identifier of the Resource Object
	 */
	public String resourceId;

	/**
	 * Identifier of the User Permission Object
	 */
	public String permissionId;

	/**
	 * Is this User Role Permission Active?
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
	 * User Role Object associated with the User Role Permission
	 */
	public Role role;

	/**
	 * Resource Object associated with the User Role Permission
	 */
	public Resource resource;

	/**
	 * User Permission Object associated with the User Role Permission
	 */
	public Permission permission;

	/**
	 * Default Constructor
	 */
	public RolePermission() {
		this.rolePermissionId = "";
		this.roleId = "";
		this.resourceId = "";
		this.permissionId = "";
		this.isActive = false;
		this.createdOn = null;
		this.updatedOn = null;
		this.role = new Role();
		this.resource = new Resource();
		this.permission = new Permission();
	}

}
