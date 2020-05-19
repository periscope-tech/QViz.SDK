package com.periscope.qviz.json;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 * JSON Model for Test Case Step Details
 */
public class TestCaseStep {

	/**
	 * Identifier of the Test Case Step
	 */
	public String testCaseStepId;

	/**
	 * Serial Number of the Test Case Step
	 */
	public Integer srNo;

	/**
	 * Description of the Test Case Step
	 */
	public String stepDescription;

	/**
	 * Expected result from the Test Case Step execution
	 */
	public String expectedResult;

	/**
	 * Date and Time on which this Model was Created
	 */
	public Date createdOn;

	/**
	 * Date and Time on which this Model was last Updated
	 */
	public Date updatedOn;

	/**
	 * List of Test Step Action Objects associated with the Test Case Step
	 */
	public List<TestStepAction> testStepActions;

	/**
	 * List of Test Step Tag Objects associated with the Test Case Step
	 */
	public List<TestStepTag> testStepTags;

	/**
	 * Default Constructor
	 */
	public TestCaseStep() {
		this.testCaseStepId = "";
		this.srNo = 0;
		this.stepDescription = "";
		this.expectedResult = "";
		this.createdOn = null;
		this.updatedOn = null;
		this.testStepActions = new ArrayList<>();
		this.testStepTags = new ArrayList<>();
	}

}
