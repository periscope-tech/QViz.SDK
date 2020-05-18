namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Test Suite and Test Case Mapping Details
	/// </summary>
	public class TestSuiteTestCaseMapping
	{
		/// <summary>
		/// Identifier of the mapping between Test Suite and Test Case
		/// </summary>
		public string testsuiteTestcaseMappingId;
		
		/// <summary>
		/// Identifier of the Test Suite
		/// </summary>
		public string testsuiteId;
		
		/// <summary>
		/// Identifier of the Test Case
		/// </summary>
		public string testcaseId;
		
		/// <summary>
		/// Is this mapping between Test Suite and Test Case Active?
		/// </summary>
		public bool isActive;
		
		/// <summary>
		/// Serial number of the mapping between Test Suite and Test Case
		/// </summary>
		public int srNo;
		
		/// <summary>
		/// Test Suite Object in the mapping between Test Suite and Test Case
		/// </summary>
		public TestSuite testsuite;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public TestSuiteTestCaseMapping()
		{
			this.testsuiteTestcaseMappingId = "";
			this.testsuiteId = "";
			this.testcaseId = "";
			this.isActive = false;
			this.srNo = 0;
			this.testsuite = new TestSuite();
		}
	}
}