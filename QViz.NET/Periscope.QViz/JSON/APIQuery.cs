using System;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Test API Query Parameter Details
	/// </summary>
	public class APIQuery
	{
		/// <summary>
		/// Identifier of the API Query Object
		/// </summary>
		public string apiQueryId;
		
		/// <summary>
		/// Serial Number of the API Query Object
		/// </summary>
		public int srNo;
		
		/// <summary>
		/// Identifier of the API Object
		/// </summary>
		public string apiId;
		
		/// <summary>
		/// Identifier of the API Query Value Object
		/// </summary>
		public string queryValueId;
		
		/// <summary>
		/// Date and Time on which this Model was Created
		/// </summary>
		public DateTime createdOn;
		
		/// <summary>
		/// Date and Time on which this Model was last Updated
		/// </summary>
		public DateTime updatedOn;
		
		/// <summary>
		/// Value of the API Query Object
		/// </summary>
		public APIQueryValue queryValue;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public APIQuery()
		{
			this.apiQueryId = "";
			this.srNo = 0;
			this.apiId = "";
			this.queryValueId = "";
			this.createdOn = DateTime.Now;
			this.updatedOn = DateTime.Now;
			this.queryValue = new APIQueryValue();
		}
	}
}