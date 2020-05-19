package com.periscope.qviz.json;

import java.util.Date;

/**
 * JSON Model for Test API Header Details
 */
public class APIHeader {

	/**
	 * Identifier of the API Header Object
	 */
	public String apiHeaderId;

	/**
	 * Serial Number of the API Header Object
	 */
	public Integer srNo;

	/**
	 * Identifier of the API Object
	 */
	public String apiId;

	/**
	 * Identifier of the API Header Value Object
	 */
	public String headerValueId;

	/**
	 * Date and Time on which this Model was Created
	 */
	public Date createdOn;

	/**
	 * Date and Time on which this Model was last Updated
	 */
	public Date updatedOn;

	/**
	 * Value of the API Header Object
	 */
	public APIHeaderValue headerValue;

	/**
	 * Default Constructor
	 */
	public APIHeader() {
		this.apiHeaderId = "";
		this.srNo = 0;
		this.apiId = "";
		this.headerValueId = "";
		this.createdOn = null;
		this.updatedOn = null;
		this.headerValue = new APIHeaderValue();
	}

}
