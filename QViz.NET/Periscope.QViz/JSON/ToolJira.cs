namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Tool Configuration Data for JIRA Software
	/// </summary>
	public class ToolJira
	{
		/// <summary>
		/// Name of the Tool Configuration (JIRA)
		/// </summary>
		public string toolName;

		/// <summary>
		/// URL of the JIRA REST v2 API Instance
		/// </summary>
		public string url;

		/// <summary>
		/// Unique Name of the JIRA User
		/// </summary>
		public string userName;

		/// <summary>
		/// JIRA REST v2 API Access Token of the User
		/// </summary>
		public string password;

		/// <summary>
		/// Unique Key of the JIRA Project
		/// </summary>
		public string jiraProjectKey;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public ToolJira()
		{
			this.toolName = "";
			this.url = "";
			this.userName = "";
			this.password = "";
			this.jiraProjectKey = "";
		}
	}
}