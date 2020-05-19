package com.periscope.qviz.json;

import java.util.Date;

/**
 * JSON Model for Test Step Action Details
 */
public class TestStepAction {

	/**
	 * Identifier of the Test Step Action
	 */
	public String testStepActionId;

	/**
	 * Serial number of the Test Step Action
	 */
	public Integer srNo;

	/**
	 * Date and Time on which this Model was Created
	 */
	public Date createdOn;

	/**
	 * Date and Time on which this Model was last Updated
	 */
	public Date updatedOn;

	/**
	 * Action Object associated with the Test Step Action
	 */
	public Action action;

	/**
	 * Default Constructor
	 */
	public TestStepAction() {
		this.testStepActionId = "";
		this.srNo = 0;
		this.createdOn = null;
		this.updatedOn = null;
		this.action = new Action();
	}

}
