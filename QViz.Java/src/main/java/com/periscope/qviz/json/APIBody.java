package com.periscope.qviz.json;

import java.util.Date;

/**
 * JSON Model for the Test API Body Details
 */
public class APIBody {

	/**
	 * Identifier of the API Body Object
	 */
	public String apiBodyId;

	/**
	 * Serial Number of the API Body Object
	 */
	public Integer srNo;

	/**
	 * Identifier of the linked API Object
	 */
	public String apiId;

	/**
	 * Identifier of the linked API Body Value Object
	 */
	public String bodyValueId;

	/**
	 * Date and Time on which this Model was Created
	 */
	public Date createdOn;

	/**
	 * Date and Time on which this Model was last Updated
	 */
	public Date updatedOn;

	/**
	 * Value of the API Body Object
	 */
	public APIBodyValue bodyValue;

	/**
	 * Default Constructor
	 */
	public APIBody() {
		this.apiBodyId = "";
		this.srNo = 0;
		this.apiId = "";
		this.bodyValueId = "";
		this.createdOn = null;
		this.updatedOn = null;
		this.bodyValue = new APIBodyValue();
	}

}
