namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for User Authentication
	/// </summary>
	public class Authentication
	{
		/// <summary>
		/// Unique Name of the User for Authentication
		/// </summary>
		public string username;
		
		/// <summary>
		/// Password of the User for Authentication
		/// </summary>
		public string password;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public Authentication()
		{
			this.username = "";
			this.password = "";
		}

		/// <summary>
		/// Create a new Authentication instance with provided User Name and Password
		/// </summary>
		/// <param name="username">Unique Name of the User for Authentication</param>
		/// <param name="password">Password of the User for Authentication</param>
		public Authentication(string username, string password)
		{
			this.username = username;
			this.password = password;
		}
	}
}