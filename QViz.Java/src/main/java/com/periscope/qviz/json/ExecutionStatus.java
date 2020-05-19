package com.periscope.qviz.json;

import java.util.ArrayList;
import java.util.List;

/**
 * JSON Model for Test Execution Status Details
 */
public class ExecutionStatus {

	/**
	 * Number of Test executions that are successful
	 */
	public Integer passCount;

	/**
	 * Number of Test executions that are failed
	 */
	public Integer failCount;

	/**
	 * Number of Test executions that are broken
	 */
	public Integer brokenCount;

	/**
	 * List of Test Cases that are successful in Test execution
	 */
	public List<TestCase> passTestCases;

	/**
	 * List of Test Cases that are failed in Test execution
	 */
	public List<TestCase> failTestCases;

	/**
	 * List of Test Cases that are broken in Test execution
	 */
	public List<TestCase> brokenTestCases;

	/**
	 * Default Constructor
	 */
	public ExecutionStatus() {
		this.passCount = 0;
		this.failCount = 0;
		this.brokenCount = 0;
		this.passTestCases = new ArrayList<>();
		this.failTestCases = new ArrayList<>();
		this.brokenTestCases = new ArrayList<>();
	}

}
