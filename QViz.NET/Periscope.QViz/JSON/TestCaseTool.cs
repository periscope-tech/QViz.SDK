using System;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Test Case Tool Details
	/// </summary>
	public class TestCaseTool
	{
		/// <summary>
		/// Identifier of the third-party Tool integrated with the Test Case
		/// </summary>
		public string testCaseToolId;

		/// <summary>
		/// Identifier of the Test Case associated with the third-party Tool
		/// </summary>
		public string testCaseId;

		/// <summary>
		/// Identifier of the third-party Tool
		/// </summary>
		public string toolId;

		/// <summary>
		/// Value of the third-party Tool integrated with the Test Case
		/// </summary>
		public string value;

		/// <summary>
		/// Date and Time on which this Model was Created
		/// </summary>
		public DateTime createdOn;

		/// <summary>
		/// Date and Time on which this Model was last Updated
		/// </summary>
		public DateTime updatedOn;

		/// <summary>
		/// Third-party Tool Integration Object associated with the Test Case
		/// </summary>
		public Tool tool;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public TestCaseTool()
		{
			this.testCaseToolId = "";
			this.testCaseId = "";
			this.toolId = "";
			this.value = "";
			this.createdOn = DateTime.Now;
			this.updatedOn = DateTime.Now;
			this.tool = new Tool();
		}
	}
}