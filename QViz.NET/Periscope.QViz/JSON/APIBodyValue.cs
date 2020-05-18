using System;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Test API Body Value Details
	/// </summary>
	public class APIBodyValue
	{
		/// <summary>
		/// Identifier of the API Body Value Object
		/// </summary>
		public string bodyValueId;

		/// <summary>
		/// API Body Value as JSON String
		/// </summary>
		public string jsonString;

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
		public APIBodyValue()
		{
			this.bodyValueId = "";
			this.jsonString = "";
			this.createdOn = DateTime.Now;
			this.updatedOn = DateTime.Now;
		}
	}
}