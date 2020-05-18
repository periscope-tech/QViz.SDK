using System;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Test API Query Parameter Value Details
	/// </summary>
	public class APIQueryValue
	{
		/// <summary>
		/// Identifier of the API Query Value Object
		/// </summary>
		public string queryValueId;
		
		/// <summary>
		/// Key of the API HTTP Query String Object
		/// </summary>
		public string key;
		
		/// <summary>
		/// Value of the API HTTP Query String Object
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
		public APIQueryValue()
		{
			this.queryValueId = "";
			this.key = "";
			this.value = "";
			this.createdOn = DateTime.Now;
			this.updatedOn = DateTime.Now;
		}
	}
}