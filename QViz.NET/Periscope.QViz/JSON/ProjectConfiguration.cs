namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Project Configuration Details
	/// </summary>
	public class ProjectConfiguration
	{
		/// <summary>
		/// Identifier of the Project Configuration Object
		/// </summary>
		public string projectConfigurationId;

		/// <summary>
		/// Identifier of the Project
		/// </summary>
		public string projectId;

		/// <summary>
		/// Name of the Project
		/// </summary>
		public string projectName;

		/// <summary>
		/// Identifier of the Project Configuration Key Object
		/// </summary>
		public string configurationKeyId;

		/// <summary>
		/// Key of the Project Configuration Object
		/// </summary>
		public string key;

		/// <summary>
		/// Taxonomy Group of the Project Configuration Object
		/// </summary>
		public string group;

		/// <summary>
		/// Description of the Project Configuration Object
		/// </summary>
		public string description;

		/// <summary>
		/// Value of the Project Configuration Object
		/// </summary>
		public string value;

		/// <summary>
		/// Is this a Tool Configuration?
		/// </summary>
		public bool isTool;

		/// <summary>
		/// Is this Configuration contain any sensitive information?
		/// </summary>
		public bool isSensitiveData;

		/// <summary>
		/// Regular Expression for Validating the Value of this Project Configuration Object
		/// </summary>
		public string validationRegex;

		/// <summary>
		/// Project Object associated with the Project Configuration
		/// </summary>
		public Project project;

		/// <summary>
		/// Project Configuration Key Object associated with the Project Configuration
		/// </summary>
		public ConfigurationKey configurationKey;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public ProjectConfiguration()
		{
			this.projectConfigurationId = "";
			this.projectId = "";
			this.projectName = "";
			this.configurationKeyId = "";
			this.key = "";
			this.group = "";
			this.description = "";
			this.value = "";
			this.isTool = false;
			this.isSensitiveData = false;
			this.validationRegex = "";
			this.project = new Project();
			this.configurationKey = new ConfigurationKey();
		}
	}
}