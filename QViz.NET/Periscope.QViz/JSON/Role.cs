using System;
using System.Collections.Generic;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for User Roles
	/// </summary>
	public class Role
	{
		/// <summary>
		/// Identifier of the User Role
		/// </summary>
		public string roleId;
		
		/// <summary>
		/// Name of the User Role
		/// </summary>
		public string name;
		
		/// <summary>
		/// Is this User Role Active?
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
		/// Identifier of the Company that the User Role belongs to
		/// </summary>
		public string companyId;
		
		/// <summary>
		/// List of User Profile Objects associated with the User Role
		/// </summary>
		public IList<UserProfile> userProfiles;
		
		/// <summary>
		/// List of Role Permission Objects associated with the User Role
		/// </summary>
		public IList<RolePermission> rolePermissions;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public Role()
		{
			this.roleId = "";
			this.name = "";
			this.isActive = false;
			this.createdOn = DateTime.Now;
			this.updatedOn = DateTime.Now;
			this.companyId = "";
			this.userProfiles = new List<UserProfile>();
			this.rolePermissions = new List<RolePermission>();
		}
	}
}
