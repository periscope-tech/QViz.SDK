using System;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Sub Module Details
	/// </summary>
	public class SubModule
	{
		/// <summary>
		/// Identifier of the Project Sub Module
		/// </summary>
		public string subModuleId;
		
		/// <summary>
		/// Name of the Project Sub Module
		/// </summary>
		public string name;
		
		/// <summary>
		/// Identifier of the parent Module for the Project Sub Module
		/// </summary>
		public string moduleId;
		
		/// <summary>
		/// Is this Project Sub Module Active?
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
		/// Parent Module Object of the Project Sub Module
		/// </summary>
		public Module module;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public SubModule()
		{
			this.subModuleId = "";
			this.name = "";
			this.moduleId = "";
			this.isActive = false;
			this.createdOn = DateTime.Now;
			this.updatedOn = DateTime.Now;
			this.module = new Module();
		}
	}
}