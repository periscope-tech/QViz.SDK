namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Tool Configuration Data for TestRail Software
	/// </summary>
	public class ToolTestRail
	{
		/// <summary>
		/// Name of the Tool Configuration (TESTRAIL)
		/// </summary>
		public string toolName;

		/// <summary>
		/// URL of the TestRail Instance
		/// </summary>
		public string url;

		/// <summary>
		/// Unique Name of the TestRail User
		/// </summary>
		public string userName;

		/// <summary>
		/// API Access Key of the TestRail User
		/// </summary>
		public string password;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public ToolTestRail()
		{
			this.toolName = "";
			this.url = "";
			this.userName = "";
			this.password = "";
		}
	}
}