namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Tool Configuration Data for Slack Communicator
	/// </summary>
	public class ToolSlack
	{
		/// <summary>
		/// Name of the Tool Configuration (SLACK)
		/// </summary>
		public string toolName;

		/// <summary>
		/// URL of the Slack Hooks for sending Messages
		/// </summary>
		public string url;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public ToolSlack()
		{
			this.toolName = "";
			this.url = "";
		}
	}
}