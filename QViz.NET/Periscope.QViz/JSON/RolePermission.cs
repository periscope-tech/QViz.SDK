using System;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for User Role Permissions
	/// </summary>
	public class RolePermission
	{
		/// <summary>
		/// Identifier of the User Role Permission Object
		/// </summary>
		public string rolePermissionId;
		
		/// <summary>
		/// Identifier of the User Role Object
		/// </summary>
		public string roleId;
		
		/// <summary>
		/// Identifier of the Resource Object
		/// </summary>
		public string resourceId;
		
		/// <summary>
		/// Identifier of the User Permission Object
		/// </summary>
		public string permissionId;
		
		/// <summary>
		/// Is this User Role Permission Active?
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
		/// User Role Object associated with the User Role Permission
		/// </summary>
		public Role role;
		
		/// <summary>
		/// Resource Object associated with the User Role Permission
		/// </summary>
		public Resource resource;
		
		/// <summary>
		/// User Permission Object associated with the User Role Permission
		/// </summary>
		public Permission permission;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public RolePermission()
		{
			this.rolePermissionId = "";
			this.roleId = "";
			this.resourceId = "";
			this.permissionId = "";
			this.isActive = false;
			this.createdOn = DateTime.Now;
			this.updatedOn = DateTime.Now;
			this.role = new Role();
			this.resource = new Resource();
			this.permission = new Permission();
		}

	}
}
