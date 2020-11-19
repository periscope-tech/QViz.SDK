namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Tool Integration Details
	/// </summary>
	public class Tool
	{
		/// <summary>
		/// Identifier of the third-party Tool Integration
		/// </summary>
		public string toolId;

		/// <summary>
		/// Name of the third-party Tool Integration
		/// </summary>
		public string toolName;

		/// <summary>
		/// Description of the third-party Tool Integration
		/// </summary>
		public string description;

		/// <summary>
		/// Type of the third-party Tool Integration
		/// </summary>
		public string toolType;

		/// <summary>
		/// JSON Value of the Configuration Template for the third-party Tool Integration
		/// </summary>
		public string configTemplate;

		/// <summary>
		/// Is this third-party Tool Integration Active?
		/// </summary>
		public bool isActive;
		/// <summary>
		/// Associated value for tool
		/// </summary>
		public string value { get; set; }

		/// <summary>
		/// Default Constructor
		/// </summary>
		public Tool()
		{
			this.toolId = "";
			this.toolName = "";
			this.description = "";
			this.toolType = "";
			this.configTemplate = "";
			this.value = "";
		}
	}
}