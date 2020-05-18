using System.Collections.Generic;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Configuration Keys
	/// </summary>
	public class ConfigurationKey
	{
		/// <summary>
		/// Identifier of the Configuration Key Object
		/// </summary>
		public string configurationKeyId;

		/// <summary>
		/// Key of the Configuration
		/// </summary>
		public string configurationKey;

		/// <summary>
		/// Group of the Configuration
		/// </summary>
		public string configurationGroup;

		/// <summary>
		/// Description of the Configuration
		/// </summary>
		public string description;

		/// <summary>
		/// Is this Configuration Active?
		/// </summary>
		public bool isActive;

		/// <summary>
		/// Is this Configuration for a third-party Tool integration?
		/// </summary>
		public bool isTool;

		/// <summary>
		/// Is this Configuration contain any sensitive information?
		/// </summary>
		public bool isSensitiveData;

		/// <summary>
		/// Regular expression for validating the Configuration
		/// </summary>
		public string validationRegex;

		/// <summary>
		/// List of Project Configuration Objects
		/// </summary>
		public IList<ProjectConfiguration> projectConfigurations;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public ConfigurationKey()
		{
			this.configurationKeyId = "";
			this.configurationKey = "";
			this.configurationGroup = "";
			this.description = "";
			this.isActive = false;
			this.isTool = false;
			this.isSensitiveData = false;
			this.validationRegex = "";
			this.projectConfigurations = new List<ProjectConfiguration>();
		}
	}
}
