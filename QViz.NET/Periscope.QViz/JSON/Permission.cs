using System;
using System.Collections.Generic;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for User Permissions
	/// </summary>
	public class Permission
	{
		/// <summary>
		/// Serial Number of the User Permission Object
		/// </summary>
		public int srno;
		
		/// <summary>
		/// Identifier of the User Permission Object
		/// </summary>
		public string permissionId;
		
		/// <summary>
		/// Name of the User Permission Object
		/// </summary>
		public string name;
		
		/// <summary>
		/// Date and Time on which this Model was Created
		/// </summary>
		public DateTime createdOn;
		
		/// <summary>
		/// Date and Time on which this Model was last Updated
		/// </summary>
		public DateTime updatedOn;
		
		/// <summary>
		/// Is this User Permission Active?
		/// </summary>
		public bool isActive;
		
		/// <summary>
		/// List of User Role Permission Objects
		/// </summary>
		public IList<RolePermission> rolePermissions;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public Permission()
		{
			this.srno = 0;
			this.permissionId = "";
			this.name = "";
			this.createdOn = DateTime.Now;
			this.updatedOn = DateTime.Now;
			this.isActive = false;
			this.rolePermissions = new List<RolePermission>();
		}
	}
}
