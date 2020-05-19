package com.periscope.qviz.json;

import java.util.ArrayList;
import java.util.List;

/**
 * JSON Model for GUI Test Case Details
 */
public class TestCaseGUI extends TestCase {

	/**
	 * List of Test Case Step Objects associated with the Test Case
	 */
	public List<TestCaseStep> testCaseSteps;

	/**
	 * Lise of Test Action Objects associated with the Test Case
	 */
	public List<Action> testActions;

	/**
	 * List of Test API Objects associated with the Test Case
	 */
	public List<TestAPI> testAPIs;

	/**
	 * Default Constructor
	 */
	public TestCaseGUI() {
		super();
		this.testCaseSteps = new ArrayList<>();
		this.testActions = new ArrayList<>();
		this.testAPIs = new ArrayList<>();
	}

}
