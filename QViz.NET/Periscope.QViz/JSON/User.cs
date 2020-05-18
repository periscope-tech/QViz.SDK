using System;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for User Details
	/// </summary>
	public class User
	{
		/// <summary>
		/// Identifier of the User
		/// </summary>
		public string userId;
		
		/// <summary>
		/// Identifier of the Company that the User belongs to
		/// </summary>
		public string companyId;
		
		/// <summary>
		/// Unique Name of the User
		/// </summary>
		public string username;

		/// <summary>
		/// Alternative Name of the User
		/// </summary>
		public string name;
		
		/// <summary>
		/// Password of the User
		/// </summary>
		public string password;
		
		/// <summary>
		/// First Name of the User
		/// </summary>
		public string firstName;
		
		/// <summary>
		/// Last Name of the User
		/// </summary>
		public string lastName;
		
		/// <summary>
		/// Email Identifier of the User
		/// </summary>
		public string email;
		
		/// <summary>
		/// Number of times the User failed to log into the System properly
		/// </summary>
		public int failedLoginAttempts;
		
		/// <summary>
		/// Is this User Active?
		/// </summary>
		public bool isActive;
		
		/// <summary>
		/// Is this User Deleted?
		/// </summary>
		public bool isDeleted;
		
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
		public User()
		{
			this.userId = "";
			this.companyId = "";
			this.username = "";
			this.name = "";
			this.password = "";
			this.firstName = "";
			this.lastName = "";
			this.email = "";
			this.failedLoginAttempts = 0;
			this.isActive = false;
			this.isDeleted = false;
			this.createdOn = DateTime.Now;
			this.updatedOn = DateTime.Now;
		}
	}
}