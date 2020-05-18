namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Test Case Step Tag Details
	/// </summary>
	public class TestStepTag
	{
		/// <summary>
		/// Identifier of the Test Case Step Tag Details
		/// </summary>
		public string testStepTagId;

		/// <summary>
		/// Tag Object of the Test Case Step
		/// </summary>
		public Tag tag;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public TestStepTag()
		{
			this.testStepTagId = "";
			this.tag = new Tag();
		}
	}
}