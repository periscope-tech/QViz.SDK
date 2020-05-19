package com.periscope.qviz.json;

import java.util.Date;

/**
 * JSON Model for Test API Query Parameter Value Details
 */
public class APIQueryValue {

	/**
	 * Identifier of the API Query Value Object
	 */
	public String queryValueId;

	/**
	 * Key of the API HTTP Query String Object
	 */
	public String key;

	/**
	 * Value of the API HTTP Query String Object
	 */
	public String value;

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
	public APIQueryValue() {
		this.queryValueId = "";
		this.key = "";
		this.value = "";
		this.createdOn = null;
		this.updatedOn = null;
	}

}
