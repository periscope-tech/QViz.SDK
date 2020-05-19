package com.periscope.qviz.json;

/**
 * JSON Model for Test Result Count Details
 */
public class TestCount {

	/**
	 * Type of the Test Case
	 */
	public String testCaseType;

	/**
	 * Total number of all Test Cases
	 */
	public Integer totalTestCount;

	/**
	 * Total number of automated Test Cases only
	 */
	public Integer automatedTestCount;

	/**
	 * Default Constructor
	 */
	public TestCount() {
		this.testCaseType = "";
		this.totalTestCount = 0;
		this.automatedTestCount = 0;
	}

}
