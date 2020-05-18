using System;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for User Profiles
	/// </summary>
	public class UserProfile
	{
		/// <summary>
		/// Identifier of the User Profile
		/// </summary>
		public string userProfilesId;
		
		/// <summary>
		/// Identifier of the User with the Profile
		/// </summary>
		public string userId;
		
		/// <summary>
		/// Identifier of the Project associated with the User Profile
		/// </summary>
		public string projectId;
		
		/// <summary>
		/// Identifier of the Role associated with the User Profile
		/// </summary>
		public string roleId;
		
		/// <summary>
		/// Is this User Profile Active?
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
		/// User Object associated with the Profile
		/// </summary>
		public User user;
		
		/// <summary>
		/// Role Object associated with the User Profile
		/// </summary>
		public Role role;
		
		/// <summary>
		/// Project Object associated with the User Profile
		/// </summary>
		public Project project;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public UserProfile()
		{
			this.userProfilesId = "";
			this.userId = "";
			this.projectId = "";
			this.roleId = "";
			this.isActive = false;
			this.createdOn = DateTime.Now;
			this.updatedOn = DateTime.Now;
			this.user = new User();
			this.role = new Role();
			this.project = new Project();
		}
	}
}