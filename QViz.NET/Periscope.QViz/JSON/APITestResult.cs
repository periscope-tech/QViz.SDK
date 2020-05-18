using System.Collections.Generic;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Test API Result Details
	/// </summary>
	public class APITestResult
	{
		/// <summary>
		/// Test Result Object associated with the API Test
		/// </summary>
		public TestResult testResult;
		
		/// <summary>
		/// List of API Test Result Objects
		/// </summary>
		public IList<APIResult> apiResults;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public APITestResult()
		{
			this.testResult = new TestResult();
			this.apiResults = new List<APIResult>();
		}
	}
}