using System;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Test API Header Details
	/// </summary>
	public class APIHeader
	{
		/// <summary>
		/// Identifier of the API Header Object
		/// </summary>
		public string apiHeaderId;

		/// <summary>
		/// Serial Number of the API Header Object
		/// </summary>
		public int srNo;

		/// <summary>
		/// Identifier of the API Object
		/// </summary>
		public string apiId;

		/// <summary>
		/// Identifier of the API Header Value Object
		/// </summary>
		public string headerValueId;

		/// <summary>
		/// Date and Time on which this Model was Created
		/// </summary>
		public DateTime createdOn;

		/// <summary>
		/// Date and Time on which this Model was last Updated
		/// </summary>
		public DateTime updatedOn;

		/// <summary>
		/// Value of the API Header Object
		/// </summary>
		public APIHeaderValue headerValue;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public APIHeader()
		{
			this.apiHeaderId = "";
			this.srNo = 0;
			this.apiId = "";
			this.headerValueId = "";
			this.createdOn = DateTime.Now;
			this.updatedOn = DateTime.Now;
			this.headerValue = new APIHeaderValue();
		}
	}
}