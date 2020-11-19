using System;
using System.Collections.Generic;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Test Case Details
	/// </summary>
	public class TestCase
	{
		/// <summary>
		/// Identifier for the Test Case
		/// </summary>
		public string testCaseId;

		/// <summary>
		/// Identifier for the Project Module
		/// </summary>
		public string moduleId;

		/// <summary>
		/// Identifier for the Project Sub Module
		/// </summary>
		public string subModuleId;

		/// <summary>
		/// Description of the Test Case
		/// </summary>
		public string description;

		/// <summary>
		/// Expected Result from the Test Case execution
		/// </summary>
		public string expectedResult;

		/// <summary>
		/// Is this Test Case Automated?
		/// </summary>
		public bool? isAutomated;

		/// <summary>
		/// Identifier of the Test Case Type
		/// </summary>
		public string testCaseTypeId;

		/// <summary>
		/// Priority of the Test Case
		/// </summary>
		public string priority;

		/// <summary>
		/// User defined Priority of the Test Case
		/// </summary>
		public string userDefinedPriority;

		/// <summary>
		/// Severity of the Test Case
		/// </summary>
		public string severity;

		/// <summary>
		/// User defined Severity of the Test Case
		/// </summary>
		public string userDefinedSeverity;

		/// <summary>
		/// Identifier of the Project
		/// </summary>
		public string projectId;

		/// <summary>
		/// Identifier of the third-party Tool integrated
		/// </summary>
		public string testToolID;

		/// <summary>
		/// Date and Time on which this Model was Created
		/// </summary>
		public DateTime createdOn;

		/// <summary>
		/// Date and Time on which this Model was last Updated
		/// </summary>
		public DateTime updatedOn;

		/// <summary>
		/// Project Object associated with the Test Case
		/// </summary>
		public Project project;

		/// <summary>
		/// Project Module Object associated with the Test Case
		/// </summary>
		public Module module;

		/// <summary>
		/// Project Sub Module Object associated with the Test Case
		/// </summary>
		public SubModule subModule;

		/// <summary>
		/// Test Case Type Object associated with the Test Case
		/// </summary>
		public TestCaseType testCaseType;

		/// <summary>
		/// Latest Execution Finished Date and Time for easy Reference
		/// </summary>
		public string lastExecutionEndDate;

		/// <summary>
		/// List of mapping Objects between Test Suite and Test Cases
		/// </summary>
		public IList<TestSuiteTestCaseMapping> testsuiteTestcaseMappings;

		/// <summary>
		/// GET List of third-party Tools integrated with the Test Case
		/// </summary>
		public IList<TestCaseTool> testCaseTools;


		/// <summary>
		/// POST List of third-party Tools integrated with the Test Case
		/// </summary>
		public virtual List<Tool> testTools { get; set; }


		/// <summary>
		/// List of Test Result Objects associated with the Test Case
		/// </summary>
		public IList<TestResult> testResults;

		/// <summary>
		/// List of Test Case Tag Objects associated with the Test Case
		/// </summary>
		public IList<TestCaseTag> testCaseTags;

		/// <summary>
		/// Execution Status of the Test Case
		/// </summary>
		public ExecutionStatus executionStatus;

		/// <summary>
		/// GET List of Test Suites associated with the Test Case
		/// </summary>
		public IList<string> listOfSuiteNameForTestCase;

		/// <summary>
		/// GET List of Tags associated with the Test Case
		/// </summary>
		public IList<string> listOfTagNameForTestCase;

		/// <summary>
		/// GET List of third-party Tool identifiers associated with the Test Case
		/// </summary>
		public IList<string> listToolIds;


		/// <summary>
		/// List of test suites to post
		/// </summary>
		public IList<TestSuite> testSuites;

		/// <summary>
		/// List of test tags used while POST
		/// </summary>
		public IList<Tag> testTags;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public TestCase()
		{
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
			this.createdOn = DateTime.Now;
			this.updatedOn = DateTime.Now;
			this.project = new Project();
			this.module = new Module();
			this.subModule = new SubModule();
			this.testCaseType = new TestCaseType();
			this.lastExecutionEndDate = "";
			this.testsuiteTestcaseMappings = new List<TestSuiteTestCaseMapping>();
			this.testCaseTools = new List<TestCaseTool>();
			this.testTools = new List<Tool>();
			this.testResults = new List<TestResult>();
			this.testCaseTags = new List<TestCaseTag>();
			this.executionStatus = new ExecutionStatus();
			this.listOfSuiteNameForTestCase = new List<string>();
			this.listOfTagNameForTestCase = new List<string>();
			this.listToolIds = new List<string>();
			this.testSuites = new List<TestSuite>();
			this.testTags = new List<Tag>();
		}
	}
}