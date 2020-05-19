package com.periscope.qviz.json;

/**
 * JSON Model for Response from User APIs
 */
public class UserResponse {

	/**
	 * Message returned from the User APIs
	 */
	public String message;

	/**
	 * User Object returned from the User APIs
	 */
	public User value;

	/**
	 * Default Constructor
	 */
	public UserResponse() {
		this.message = "";
		this.value = new User();
	}

}