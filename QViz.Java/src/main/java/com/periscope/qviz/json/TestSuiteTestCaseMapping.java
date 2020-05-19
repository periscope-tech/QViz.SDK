package com.periscope.qviz.json;

/**
 * JSON Model for Test Suite and Test Case Mapping Details
 */
public class TestSuiteTestCaseMapping {

	/**
	 * Identifier of the mapping between Test Suite and Test Case
	 */
	public String testsuiteTestcaseMappingId;

	/**
	 * Identifier of the Test Suite
	 */
	public String testsuiteId;

	/**
	 * Identifier of the Test Case
	 */
	public String testcaseId;

	/**
	 * Is this mapping between Test Suite and Test Case Active?
	 */
	public Boolean isActive;

	/**
	 * Serial number of the mapping between Test Suite and Test Case
	 */
	public Integer srNo;

	/**
	 * Test Suite Object in the mapping between Test Suite and Test Case
	 */
	public TestSuite testsuite;

	/**
	 * Default Constructor
	 */
	public TestSuiteTestCaseMapping() {
		this.testsuiteTestcaseMappingId = "";
		this.testsuiteId = "";
		this.testcaseId = "";
		this.isActive = false;
		this.srNo = 0;
		this.testsuite = new TestSuite();
	}

}
