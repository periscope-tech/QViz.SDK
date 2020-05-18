using System;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for API Test Case Details
	/// </summary>
	public class TestAPI
	{
		/// <summary>
		/// Identifier of the Test API Object
		/// </summary>
		public string testAPIId;
		
		/// <summary>
		/// Identifier of the Test Case Object
		/// </summary>
		public string testCaseId;
		
		/// <summary>
		/// Identifier of the API Object
		/// </summary>
		public string apiId;
		
		/// <summary>
		/// Serial number of the Test API Object
		/// </summary>
		public int srNo;
		
		/// <summary>
		/// Date and Time on which this Model was Created
		/// </summary>
		public DateTime createdOn;
		
		/// <summary>
		/// Date and Time on which this Model was last Updated
		/// </summary>
		public DateTime updatedOn;
		
		/// <summary>
		/// API Object associated with this Test API
		/// </summary>
		public API api;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public TestAPI()
		{
			this.testAPIId = "";
			this.testCaseId = "";
			this.apiId = "";
			this.srNo = 0;
			this.createdOn = DateTime.Now;
			this.updatedOn = DateTime.Now;
			this.api = new API();
		}
	}
}