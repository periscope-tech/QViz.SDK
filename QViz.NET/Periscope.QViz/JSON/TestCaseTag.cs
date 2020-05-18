namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Test Case Tag Details
	/// </summary>
	public class TestCaseTag
	{
		/// <summary>
		/// Identifier of the Test Case Tag Details
		/// </summary>
		public string testCaseTagId;

		/// <summary>
		/// Tag Object of the Test Case
		/// </summary>
		public Tag tag;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public TestCaseTag()
		{
			this.testCaseTagId = "";
			this.tag = new Tag();
		}
	}
}