package com.periscope.qviz.json;

import java.util.Date;

/**
 * JSON Model for GUI Action Details
 */
public class Action {

	/**
	 * Identifier of the GUI Action
	 */
	public String actionId;

	/**
	 * Type of the GUI Action
	 */
	public String actionType;

	/**
	 * Name of the Field to perform the GUI Action
	 */
	public String fieldName;

	/**
	 * Value of the Field to provide for in the GUI Action
	 */
	public String fieldValue;

	/**
	 * Date and Time on which this Model was Created
	 */
	public Date createdOn;

	/**
	 * Date and Time on which this Model was last Updated
	 */
	public Date updatedOn;

	public boolean isSensitive;

	public boolean isEncrypted;

	/**
	 * Default Constructor
	 */
	public Action() {
		this.actionId = "";
		this.actionType = "";
		this.fieldName = "";
		this.fieldValue = "";
		this.createdOn = null;
		this.updatedOn = null;
		this.isSensitive = false;
		this.isEncrypted = false;
	}

}
