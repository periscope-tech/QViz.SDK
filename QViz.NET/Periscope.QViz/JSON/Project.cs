using System;
using System.Collections.Generic;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Project Details
	/// </summary>
	public class Project
	{
		/// <summary>
		/// Identifier of the Project
		/// </summary>
		public string projectId;
		
		/// <summary>
		/// Name of the Project
		/// </summary>
		public string projectName;
		
		/// <summary>
		/// Is this Project Active?
		/// </summary>
		public bool isActive;
		
		/// <summary>
		/// Date and Time on which this Model was Created
		/// </summary>
		public DateTime createdOn;
		
		/// <summary>
		/// Date and Time on which this Model was last Updated
		/// </summary>
		public DateTime updatedOn;
		
		/// <summary>
		/// Identifier of the Company associated with the Project
		/// </summary>
		public string companyId;
		
		/// <summary>
		/// Type of the Project
		/// </summary>
		public string projectType;
		
		/// <summary>
		/// List of Test Case Counts under the Project
		/// </summary>
		public IList<Count> counts;
		
		/// <summary>
		/// List of User Profile Objects associated with the Project
		/// </summary>
		public IList<UserProfile> userProfiles;
		
		/// <summary>
		/// List of Configurations for the Project
		/// </summary>
		public IList<ProjectConfiguration> projectConfigurations;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public Project()
		{
			this.projectId = "";
			this.projectName = "";
			this.isActive = false;
			this.createdOn = DateTime.Now;
			this.updatedOn = DateTime.Now;
			this.companyId = "";
			this.projectType = "";
			this.counts = new List<Count>();
			this.userProfiles = new List<UserProfile>();
			this.projectConfigurations = new List<ProjectConfiguration>();
		}
	}
}