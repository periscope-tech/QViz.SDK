package com.periscope.qviz.json;

import java.util.Date;

/**
 * JSON Model for Test API Header Value Details
 */
public class APIHeaderValue {

	/**
	 * Identifier of the API Header Value Object
	 */
	public String headerValueId;

	/**
	 * Key of the API HTTP Header Object
	 */
	public String key;

	/**
	 * Value of the API HTTP Header Object
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
	public APIHeaderValue() {
		this.headerValueId = "";
		this.key = "";
		this.value = "";
		this.createdOn = null;
		this.updatedOn = null;
	}

}
