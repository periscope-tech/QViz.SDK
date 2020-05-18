namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Test Suite Details
	/// </summary>
	public class TestSuite
	{
		/// <summary>
		/// Identifier of the Test Suite
		/// </summary>
		public string testsuiteId;
		
		/// <summary>
		/// Name of the Test Suite
		/// </summary>
		public string testsuiteName;
		
		/// <summary>
		/// Is this Test Suite Active?
		/// </summary>
		public bool isActive;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public TestSuite()
		{
			this.testsuiteId = "";
			this.testsuiteName = "";
			this.isActive = false;
		}
	}
}