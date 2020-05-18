using System.Collections.Generic;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Test Execution Status Details
	/// </summary>
	public class ExecutionStatus
	{
		/// <summary>
		/// Number of Test executions that are successful
		/// </summary>
		public int passCount;
		
		/// <summary>
		/// Number of Test executions that are failed
		/// </summary>
		public int failCount;
		
		/// <summary>
		/// Number of Test executions that are broken
		/// </summary>
		public int brokenCount;
		
		/// <summary>
		/// List of Test Cases that are successful in Test execution
		/// </summary>
		public IList<TestCase> passTestCases;
		
		/// <summary>
		/// List of Test Cases that are failed in Test execution
		/// </summary>
		public IList<TestCase> failTestCases;
		
		/// <summary>
		/// List of Test Cases that are broken in Test execution
		/// </summary>
		public IList<TestCase> brokenTestCases;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public ExecutionStatus()
		{
			this.passCount = 0;
			this.failCount = 0;
			this.brokenCount = 0;
			this.passTestCases = new List<TestCase>();
			this.failTestCases = new List<TestCase>();
			this.brokenTestCases = new List<TestCase>();
		}
	}
}