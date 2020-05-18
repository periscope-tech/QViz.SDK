using System;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Test Result Details
	/// </summary>
	public class TestResult
	{
		/// <summary>
		/// Identifier of the Test Case associated with the Test Result
		/// </summary>
		public string testCaseId;
		
		/// <summary>
		/// Identifier of the Project Module associated with the Test Result
		/// </summary>
		public string moduleId;
		
		/// <summary>
		/// Identifier of the Project Sub Module associated with the Test Result
		/// </summary>
		public string subModuleId;
		
		/// <summary>
		/// Actual result from the execution of the Test Case
		/// </summary>
		public string actualResult;
		
		/// <summary>
		/// Status of the Test Case execution (Pass, Fail, Broken)
		/// </summary>
		public string status;
		
		/// <summary>
		/// Error message from the execution of the Test Case
		/// </summary>
		public string error;
		
		/// <summary>
		/// URL of the Screen shot taken when exception occurred during the execution of the Test Case
		/// </summary>
		public string errorScreen;
		
		/// <summary>
		/// System/Project that was tested in the Test Result
		/// </summary>
		public string sUT;
		
		/// <summary>
		/// Name of the Release that was tested in the Test Result
		/// </summary>
		public string releaseName;
		
		/// <summary>
		/// Version number of the Release that was tested in the Test Result
		/// </summary>
		public string releaseNo;
		
		/// <summary>
		/// Name of the Scrum Sprint in which the Release was made that was tested in the Test Result
		/// </summary>
		public string sprintName;
		
		/// <summary>
		/// Number of the Scrum Sprint in which the Release was made that was tested in the Test Result
		/// </summary>
		public string sprintNo;
		
		/// <summary>
		/// Version number of the Build that was tested in the Test Result
		/// </summary>
		public string buildVersion;
		
		/// <summary>
		/// Name of the Browser in which the Release was tested in the Test Result
		/// </summary>
		public string browserName;
		
		/// <summary>
		/// Version of the Browser in which the Release was tested in the Test Result
		/// </summary>
		public string browserVersion;
		
		/// <summary>
		/// Resolution of the Screen in which the Release was tested in the Test Result
		/// </summary>
		public string resolution;
		
		/// <summary>
		/// Name of the Operating System in which the Release was tested in the Test Result
		/// </summary>
		public string oSName;
		
		/// <summary>
		/// Version of the Operating System in which the Release was tested in the Test Result
		/// </summary>
		public string oSVersion;
		
		/// <summary>
		/// Type of the Application that was tested in the Test Result
		/// </summary>
		public string appType;
		
		/// <summary>
		/// Version of the Application that was tested in the Test Result
		/// </summary>
		public string appVersion;
		
		/// <summary>
		/// Date and Time on which the execution of the Test Case was started
		/// </summary>
		public DateTime executionStartTime;
		
		/// <summary>
		/// Date nad Time on which the execution of the Test Case was finished
		/// </summary>
		public DateTime executionEndTime;
		
		/// <summary>
		/// Identifier of the Project associated with the Test Result
		/// </summary>
		public string projectId;
		
		/// <summary>
		/// Environment in which the Release was tested in the Test Result
		/// </summary>
		public string environment;
		
		/// <summary>
		/// Identifier of the execution instance for the Test Result
		/// </summary>
		public string runID;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public TestResult()
		{
			this.testCaseId = "";
			this.moduleId = "";
			this.subModuleId = "";
			this.actualResult = "";
			this.status = "";
			this.error = "";
			this.errorScreen = "";
			this.sUT = "";
			this.releaseName = "";
			this.releaseNo = "";
			this.sprintName = "";
			this.sprintNo = "";
			this.buildVersion = "";
			this.browserName = "";
			this.browserVersion = "";
			this.resolution = "";
			this.oSName = "";
			this.oSVersion = "";
			this.appType = "";
			this.appVersion = "";
			this.executionStartTime = DateTime.Now;
			this.executionEndTime = DateTime.Now;
			this.projectId = "";
			this.environment = "";
			this.runID = "";
		}
	}
}