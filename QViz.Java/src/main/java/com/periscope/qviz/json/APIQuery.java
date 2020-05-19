package com.periscope.qviz.json;

import java.util.Date;

/**
 * JSON Model for Test API Query Parameter Details
 */
public class APIQuery {

	/**
	 * Identifier of the API Query Object
	 */
	public String apiQueryId;

	/**
	 * Serial Number of the API Query Object
	 */
	public Integer srNo;

	/**
	 * Identifier of the API Object
	 */
	public String apiId;

	/**
	 * Identifier of the API Query Value Object
	 */
	public String queryValueId;

	/**
	 * Date and Time on which this Model was Created
	 */
	public Date createdOn;

	/**
	 * Date and Time on which this Model was last Updated
	 */
	public Date updatedOn;

	/**
	 * Value of the API Query Object
	 */
	public APIQueryValue queryValue;

	/**
	 * Default Constructor
	 */
	public APIQuery() {
		this.apiQueryId = "";
		this.srNo = 0;
		this.apiId = "";
		this.queryValueId = "";
		this.createdOn = null;
		this.updatedOn = null;
		this.queryValue = new APIQueryValue();
	}

}
