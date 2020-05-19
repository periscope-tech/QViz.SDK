package com.periscope.qviz.json;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 * JSON Model for Test Case Details
 */
public class TestCase {

	/**
	 * Identifier for the Test Case
	 */
	public String testCaseId;

	/**
	 * Identifier for the Project Module
	 */
	public String moduleId;

	/**
	 * Identifier for the Project Sub Module
	 */
	public String subModuleId;

	/**
	 * Description of the Test Case
	 */
	public String description;

	/**
	 * Expected Result from the Test Case execution
	 */
	public String expectedResult;

	/**
	 * Is this Test Case Automated?
	 */
	public Boolean isAutomated;

	/**
	 * Identifier of the Test Case Type
	 */
	public String testCaseTypeId;

	/**
	 * Priority of the Test Case
	 */
	public String priority;

	/**
	 * User defined Priority of the Test Case
	 */
	public String userDefinedPriority;

	/**
	 * Severity of the Test Case
	 */
	public String severity;

	/**
	 * User defined Severity of the Test Case
	 */
	public String userDefinedSeverity;

	/**
	 * Identifier of the Project
	 */
	public String projectId;

	/**
	 * Identifier of the third-party Tool integrated
	 */
	public String testToolID;

	/**
	 * Date and Time on which this Model was Created
	 */
	public Date createdOn;

	/**
	 * Date and Time on which this Model was last Updated
	 */
	public Date updatedOn;

	/**
	 * Project Object associated with the Test Case
	 */
	public Project project;

	/**
	 * Project Module Object associated with the Test Case
	 */
	public Module module;

	/**
	 * Project Sub Module Object associated with the Test Case
	 */
	public SubModule subModule;

	/**
	 * Latest Execution Finished Date and Time for easy Reference
	 */
	public String lastExecutionEndDate;

	/**
	 * Test Case Type Object associated with the Test Case
	 */
	public TestCaseType testCaseType;

	/**
	 * List of mapping Objects between Test Suite and Test Cases
	 */
	public List<TestSuiteTestCaseMapping> testsuiteTestcaseMappings;

	/**
	 * List of third-party Tools integrated with the Test Case
	 */
	public List<TestCaseTool> testCaseTools;

	/**
	 * List of Test Result Objects associated with the Test Case
	 */
	public List<TestResult> testResults;

	/**
	 * List of Test Case Tag Objects associated with the Test Case
	 */
	public List<TestCaseTag> testCaseTags;

	/**
	 * Execution Status of the Test Case
	 */
	public ExecutionStatus executionStatus;

	/**
	 * List of Test Suites associated with the Test Case
	 */
	public List<String> listOfSuiteNameForTestCase;

	/**
	 * List of Tags associated with the Test Case
	 */
	public List<String> listOfTagNameForTestCase;

	/**
	 * List of third-party Tool identifiers associated with the Test Case
	 */
	public List<String> listToolIds;

	/**
	 * Default Constructor
	 */
	public TestCase() {
		this.testCaseId = "";
		this.moduleId = "";
		this.subModuleId = "";
		this.description = "";
		this.expectedResult = "";
		this.isAutomated = false;
		this.testCaseTypeId = "";
		this.priority = "";
		this.userDefinedPriority = "";
		this.severity = "";
		this.userDefinedSeverity = "";
		this.projectId = "";
		this.testToolID = "";
		this.createdOn = null;
		this.updatedOn = null;
		this.project = new Project();
		this.module = new Module();
		this.subModule = new SubModule();
		this.lastExecutionEndDate = "";
		this.testCaseType = new TestCaseType();
		this.testsuiteTestcaseMappings = new ArrayList<>();
		this.testCaseTools = new ArrayList<>();
		this.testResults = new ArrayList<>();
		this.testCaseTags = new ArrayList<>();
		this.executionStatus = new ExecutionStatus();
		this.listOfSuiteNameForTestCase = new ArrayList<>();
		this.listOfTagNameForTestCase = new ArrayList<>();
		this.listToolIds = new ArrayList<>();
	}

}
