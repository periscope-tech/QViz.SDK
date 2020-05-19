package com.periscope.qviz.json;

/**
 * JSON Model for User Access Details
 */
public class AccessUser {

	/**
	 * OAuth 2.0 Bearer Token of the Authentication
	 */
	public String access_token;

	/**
	 * Identifier of the User
	 */
	public String userId;

	/**
	 * Unique Name of the User
	 */
	public String username;

	/**
	 * First Name of the User
	 */
	public String firstname;

	/**
	 * Last Name of the User
	 */
	public String lastname;

	/**
	 * Default Constructor
	 */
	public AccessUser() {
		this.access_token = "";
		this.userId = "";
		this.username = "";
		this.firstname = "";
		this.lastname = "";
	}

}
