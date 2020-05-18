using System;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Project Module Details
	/// </summary>
	public class Module
	{
		/// <summary>
		/// Identifier of the Project Module
		/// </summary>
		public string moduleId;
		
		/// <summary>
		/// Name of the Project Module
		/// </summary>
		public string name;
		
		/// <summary>
		/// Is this Project Module Active?
		/// </summary>
		public bool isActive;
		
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
		public Module()
		{
			this.moduleId = "";
			this.name = "";
			this.isActive = false;
			this.createdOn = DateTime.Now;
			this.updatedOn = DateTime.Now;
		}
	}
}