package com.periscope.qviz.json;

/**
 * JSON Model for User Authentication
 */
public class Authentication {

	/**
	 * Unique Name of the User for Authentication
	 */
	public String username;

	/**
	 * Password of the User for Authentication
	 */
	public String password;

	/**
	 * Default Constructor
	 */
	public Authentication() {
		this.username = "";
		this.password = "";
	}

	/**
	 * Create a new Authentication instance with provided User Name and Password
	 *
	 * @param username Unique Name of the User for Authentication
	 * @param password Password of the User for Authentication
	 */
	public Authentication(String username, String password) {
		this.username = username;
		this.password = password;
	}

}
