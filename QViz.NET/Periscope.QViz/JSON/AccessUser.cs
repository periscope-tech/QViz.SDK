namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for User Access Details
	/// </summary>
	public class AccessUser
	{
		/// <summary>
		/// OAuth 2.0 Bearer Token of the Authentication
		/// </summary>
		public string access_token;

		/// <summary>
		/// Identifier of the User
		/// </summary>
		public string userId;

		/// <summary>
		/// Unique Name of the User
		/// </summary>
		public string username;

		/// <summary>
		/// First Name of the User
		/// </summary>
		public string firstname;

		/// <summary>
		/// Last Name of the User
		/// </summary>
		public string lastname;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public AccessUser()
		{
			this.access_token = "";
			this.userId = "";
			this.username = "";
			this.firstname = "";
			this.lastname = "";
		}
	}
}
