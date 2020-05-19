package com.periscope.qviz.json;

import java.util.Date;

/**
 * JSON Model for Test API Body Value Details
 */
public class APIBodyValue {

	/**
	 * Identifier of the API Body Value Object
	 */
	public String bodyValueId;

	/**
	 * API Body Value as JSON String
	 */
	public String jsonString;

	/**
	 * Date and Time on which this Model was Created
	 */
	public Date createdOn;

	/**
	 * Date and Time on which this Model was last Updated
	 */
	public Date updatedOn;

	/**
	 * Default Constructor
	 */
	public APIBodyValue() {
		this.bodyValueId = "";
		this.jsonString = "";
		this.createdOn = null;
		this.updatedOn = null;
	}

}
