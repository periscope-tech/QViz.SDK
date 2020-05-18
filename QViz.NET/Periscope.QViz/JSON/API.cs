using System;
using System.Collections.Generic;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Test API Details
	/// </summary>
	public class API
	{
		/// <summary>
		/// Identifier of the API
		/// </summary>
		public string apiId;

		/// <summary>
		/// Uniform Resource Identifier of the API
		/// </summary>
		public string uri;

		/// <summary>
		/// HTTP Method of the API (GET, POST, PUT, DELETE)
		/// </summary>
		public string method;

		/// <summary>
		/// Identifier of the Project Module for the API
		/// </summary>
		public string moduleId;

		/// <summary>
		/// Identifier of the Project Sub Module for the API
		/// </summary>
		public string subModuleId;

		/// <summary>
		/// Expected HTTP Status Code from the API Response
		/// </summary>
		public int expectedHTTPStatus;

		/// <summary>
		/// Expected JSON Data from the API Response
		/// </summary>
		public string expectedJSONResult;

		/// <summary>
		/// Date and Time on which this Model was Created
		/// </summary>
		public DateTime createdOn;

		/// <summary>
		/// Date and Time on which this Model was last Updated
		/// </summary>
		public DateTime updatedOn;

		/// <summary>
		/// List of API Test Cases linked with this API
		/// </summary>
		public IList<TestAPI> testAPIs;

		/// <summary>
		/// List of HTTP Header Key-Value pairs for the API Request
		/// </summary>
		public IList<APIHeader> apiHeaders;

		/// <summary>
		/// List of Query String Key-Value pairs for the API Request
		/// </summary>
		public IList<APIQuery> apiQueries;

		/// <summary>
		/// HTTP Body Data for the API Request
		/// </summary>
		public APIBody apiBody;

		/// <summary>
		/// List of Tags associated with this API Request
		/// </summary>
		public IList<Tag> apiTags;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public API()
		{
			this.apiId = "";
			this.uri = "";
			this.method = "";
			this.moduleId = "";
			this.subModuleId = "";
			this.expectedHTTPStatus = 0;
			this.expectedJSONResult = "";
			this.createdOn = DateTime.Now;
			this.updatedOn = DateTime.Now;
			this.testAPIs = new List<TestAPI>();
			this.apiHeaders = new List<APIHeader>();
			this.apiQueries = new List<APIQuery>();
			this.apiBody = new APIBody();
			this.apiTags = new List<Tag>();
		}
	}
}