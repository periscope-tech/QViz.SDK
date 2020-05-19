package com.periscope.qviz.json;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 * JSON Model for Resource Details
 */
public class Resource {

	/**
	 * Identifier of the Resource
	 */
	public String resourceId;

	/**
	 * Name of the Resource
	 */
	public String name;

	/**
	 * Type of the Resource
	 */
	public String type;

	/**
	 * Is this Resource Active?
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
	 * List of User Role Permission Objects
	 */
	public List<RolePermission> rolePermissions;

	/**
	 * Default Constructor
	 */
	public Resource() {
		this.resourceId = "";
		this.name = "";
		this.type = "";
		this.isActive = false;
		this.createdOn = null;
		this.updatedOn = null;
		this.rolePermissions = new ArrayList<>();
	}

}
