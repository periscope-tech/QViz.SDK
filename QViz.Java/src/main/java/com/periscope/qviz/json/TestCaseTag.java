package com.periscope.qviz.json;

/**
 * JSON Model for Test Case Tag Details
 */
public class TestCaseTag {

	/**
	 * Identifier of the Test Case Tag Details
	 */
	public String testCaseTagId;

	/**
	 * Tag Object of the Test Case
	 */
	public Tag tag;

	/**
	 * Default Constructor
	 */
	public TestCaseTag() {
		this.testCaseTagId = "";
		this.tag = new Tag();
	}

}
