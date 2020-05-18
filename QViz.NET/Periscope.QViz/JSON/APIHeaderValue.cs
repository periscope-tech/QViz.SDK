using System;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Test API Header Value Details
	/// </summary>
	public class APIHeaderValue
	{
		/// <summary>
		/// Identifier of the API Header Value Object
		/// </summary>
		public string headerValueId;
		
		/// <summary>
		/// Key of the API HTTP Header Object
		/// </summary>
		public string key;
		
		/// <summary>
		/// Value of the API HTTP Header Object
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
		/// Default Constructor
		/// </summary>
		public APIHeaderValue()
		{
			this.headerValueId = "";
			this.key = "";
			this.value = "";
			this.createdOn = DateTime.Now;
			this.updatedOn = DateTime.Now;
		}
	}
}