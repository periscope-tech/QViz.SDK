using System;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for the Test API Body Details
	/// </summary>
	public class APIBody
	{
		/// <summary>
		/// Identifier of the API Body Object
		/// </summary>
		public string apiBodyId;

		/// <summary>
		/// Serial Number of the API Body Object
		/// </summary>
		public int srNo;

		/// <summary>
		/// Identifier of the linked API Object
		/// </summary>
		public string apiId;

		/// <summary>
		/// Identifier of the linked API Body Value Object
		/// </summary>
		public string bodyValueId;

		/// <summary>
		/// Date and Time on which this Model was Created
		/// </summary>
		public DateTime createdOn;

		/// <summary>
		/// Date and Time on which this Model was last Updated
		/// </summary>
		public DateTime updatedOn;

		/// <summary>
		/// Value of the API Body Object
		/// </summary>
		public APIBodyValue bodyValue;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public APIBody()
		{
			this.apiBodyId = "";
			this.srNo = 0;
			this.apiId = "";
			this.bodyValueId = "";
			this.createdOn = DateTime.Now;
			this.updatedOn = DateTime.Now;
			this.bodyValue = new APIBodyValue();
		}
	}
}