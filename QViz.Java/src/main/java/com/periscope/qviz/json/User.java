package com.periscope.qviz.json;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 * JSON Model for User Details
 */
public class User {

	/**
	 * Identifier of the User
	 */
	public String userId;

	/**
	 * Identifier of the Company that the User belongs to
	 */
	public String companyId;

	/**
	 * Unique name of the User
	 */
	public String userName;

	/**
	 * Alternative Name of the User
	 */
	public String name;

	/**
	 * Password of the User
	 */
	public String password;

	/**
	 * First Name of the User
	 */
	public String firstName;

	/**
	 * Last Name of the User
	 */
	public String lastName;

	/**
	 * Email Identifier of the User
	 */
	public String email;

	/**
	 * Number of times the User failed to log into the System properly
	 */
	public Integer failedLoginAttempts;

	/**
	 * Is this User Active?
	 */
	public Boolean isActive;

	/**
	 * Is this User Deleted?
	 */
	public Boolean isDeleted;

	/**
	 * Date and Time on which this Model was Created
	 */
	public Date createdOn;

	/**
	 * Date and Time on which this Model was last Updated
	 */
	public Date updatedOn;

	public List<UserProfile> userProfiles;

	/**
	 * Default Constructor
	 */
	public User() {
		this.userId = "";
		this.companyId = "";
		this.userName = "";
		this.name = "";
		this.password = "";
		this.firstName = "";
		this.lastName = "";
		this.email = "";
		this.failedLoginAttempts = 0;
		this.isActive = false;
		this.isDeleted = false;
		this.createdOn = null;
		this.updatedOn = null;
		this.userProfiles = new ArrayList<>();
	}

}
