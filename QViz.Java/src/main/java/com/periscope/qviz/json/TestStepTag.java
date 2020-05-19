package com.periscope.qviz.json;

/**
 * JSON Model for Test Case Step Tag Details
 */
public class TestStepTag {

	/**
	 * Identifier of the Test Case Step Tag Details
	 */
	public String testStepTagId;

	/**
	 * Tag Object of the Test Case Step
	 */
	public Tag tag;

	/**
	 * Default Constructor
	 */
	public TestStepTag() {
		this.testStepTagId = "";
		this.tag = new Tag();
	}

}
