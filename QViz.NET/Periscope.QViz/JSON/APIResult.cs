using System;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Test API Result Values
	/// </summary>
	public class APIResult
	{
		/// <summary>
		/// Identifier of the API Object
		/// </summary>
		public string apiId;
		
		/// <summary>
		/// Actual HTTP Status Code returned from the API Response
		/// </summary>
		public int actualHTTPStatus;
		
		/// <summary>
		/// Actual JSON String returned from the API Response
		/// </summary>
		public string actualJSONResult;
		
		/// <summary>
		/// Status of the Test Result (Pass, Fail, Broken)
		/// </summary>
		public string status;
		
		/// <summary>
		/// Error Message of the Test Result if it failed/broken
		/// </summary>
		public string error;
		
		/// <summary>
		/// Exception JSON String returned from the API Response
		/// </summary>
		public string errorJSONString;
		
		/// <summary>
		/// Version of the API
		/// </summary>
		public string apiVersion;
		
		/// <summary>
		/// Date and Time on which the Test execution was started
		/// </summary>
		public DateTime executionStartTime;
		
		/// <summary>
		/// Date and Time on which the Test execution was finished
		/// </summary>
		public DateTime executionEndTime;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public APIResult()
		{
			this.apiId = "";
			this.actualHTTPStatus = 0;
			this.actualJSONResult = "";
			this.status = "";
			this.error = "";
			this.errorJSONString = "";
			this.apiVersion = "";
			this.executionStartTime = DateTime.Now;
			this.executionEndTime = DateTime.Now;
		}
	}
}