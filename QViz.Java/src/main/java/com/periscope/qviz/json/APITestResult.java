package com.periscope.qviz.json;

import java.util.ArrayList;
import java.util.List;

/**
 * JSON Model for Test API Result Details
 */
public class APITestResult {

	/**
	 * Test Result Object associated with the API Test
	 */
	public TestResult testResult;

	/**
	 * List of API Test Result Objects
	 */
	public List<APIResult> apiResults;

	/**
	 * Default Constructor
	 */
	public APITestResult() {
		this.testResult = new TestResult();
		this.apiResults = new ArrayList<>();
	}

}
