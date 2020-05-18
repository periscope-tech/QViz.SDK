namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Test Result Count Details
	/// </summary>
	public class TestCount
	{
		/// <summary>
		/// Type of the Test Case
		/// </summary>
		public string testCaseType;
		
		/// <summary>
		/// Total number of all Test Cases
		/// </summary>
		public int totalTestCount;
		
		/// <summary>
		/// Total number of automated Test Cases only
		/// </summary>
		public int automatedTestCount;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public TestCount()
		{
			this.testCaseType = "";
			this.totalTestCount = 0;
			this.automatedTestCount = 0;
		}
	}
}