using System;
using System.Collections.Generic;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Resource Details
	/// </summary>
	public class Resource
	{
		/// <summary>
		/// Identifier of the Resource
		/// </summary>
		public string resourceId;
		
		/// <summary>
		/// Name of the Resource
		/// </summary>
		public string name;
		
		/// <summary>
		/// Type of the Resource
		/// </summary>
		public string type;
		
		/// <summary>
		/// Is this Resource Active?
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
		/// List of User Role Permission Objects
		/// </summary>
		public IList<RolePermission> rolePermissions;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public Resource()
		{
			this.resourceId = "";
			this.name = "";
			this.type = "";
			this.isActive = false;
			this.createdOn = DateTime.Now;
			this.updatedOn = DateTime.Now;
			this.rolePermissions = new List<RolePermission>();
		}
	}
}
