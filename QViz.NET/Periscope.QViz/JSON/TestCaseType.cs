using System;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Test Case Type Details
	/// </summary>
	public class TestCaseType
	{
		/// <summary>
		/// Identifier of the Test Case Type
		/// </summary>
		public string testCaseTypeId;
		
		/// <summary>
		/// Name of the Test Case Type
		/// </summary>
		public string name;
		
		/// <summary>
		/// Date and Time on which this Model was Created
		/// </summary>
		public DateTime createdOn;
		
		/// <summary>
		/// Date and Time on which this Model was last Updated
		/// </summary>
		public DateTime updatedOn;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public TestCaseType()
		{
			this.testCaseTypeId = "";
			this.name = "";
			this.createdOn = DateTime.Now;
			this.updatedOn = DateTime.Now;
		}
	}
}