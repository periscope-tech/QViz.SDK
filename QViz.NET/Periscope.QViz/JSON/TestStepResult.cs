using System;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for GUI Test Step Result Details
	/// </summary>
	public class TestStepResult
	{
		/// <summary>
		/// Identifier of the Test Case Step
		/// </summary>
		public string testCaseStepId;
		
		/// <summary>
		/// Actual result of the Test Case Step execution
		/// </summary>
		public string actualResult;
		
		/// <summary>
		/// URL of the Screen shot taken when exception occurred during the execution of the Test Case Step
		/// </summary>
		public string screenshotURL;
		
		/// <summary>
		/// Status of the Test Case Step execution (Pass, Fail, Broken)
		/// </summary>
		public string status;
		
		/// <summary>
		/// Error message from the execution of the Test Case Step
		/// </summary>
		public string error;
		
		/// <summary>
		/// Date and Time on which the execution of the Test Case Step was started
		/// </summary>
		public DateTime executionStartTime;
		
		/// <summary>
		/// Date nad Time on which the execution of the Test Case Step was finished
		/// </summary>
		public DateTime executionEndTime;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public TestStepResult()
		{
			this.testCaseStepId = "";
			this.actualResult = "";
			this.screenshotURL = "";
			this.status = "";
			this.error = "";
			this.executionStartTime = DateTime.Now;
			this.executionEndTime = DateTime.Now;
		}
	}
}