namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Response from User APIs
	/// </summary>
	public class UserResponse
	{
		/// <summary>
		/// Message returned from the User APIs
		/// </summary>
		public string message;
		
		/// <summary>
		/// User Object returned from the User APIs
		/// </summary>
		public User value;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public UserResponse()
		{
			this.message = "";
			this.value = new User();
		}
	}
}
