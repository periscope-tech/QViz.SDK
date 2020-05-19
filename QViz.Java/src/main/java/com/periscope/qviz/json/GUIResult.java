package com.periscope.qviz.json;

import java.util.ArrayList;
import java.util.List;

/**
 * JSON Model for GUI Test Result Details
 */
public class GUIResult extends TestResult {

	/**
	 * List of Test Step Result Objects
	 */
	public List<TestStepResult> testStepResults;

	/**
	 * Default Constructor
	 */
	public GUIResult() {
		super();
		this.testStepResults = new ArrayList<>();
	}

}
