package com.periscope.qviz.json;

/**
 * JSON Model for Test Suite Details
 */
public class TestSuite {

	/**
	 * Identifier of the Test Suite
	 */
	public String testsuiteId;

	/**
	 * Name of the Test Suite
	 */
	public String testsuiteName;

	/**
	 * Is this Test Suite Active?
	 */
	public Boolean isActive;

	/**
	 * Default Constructor
	 */
	public TestSuite() {
		this.testsuiteId = "";
		this.testsuiteName = "";
		this.isActive = false;
	}

}
