using System.Collections.Generic;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for API Test Case Details
	/// </summary>
	public class TestCaseAPI : TestCase
	{
		/// <summary>
		/// List of Test Case Step Objects associated with the Test Case
		/// </summary>
		public IList<TestCaseStep> testCaseSteps;
		
		/// <summary>
		/// Lise of Test Action Objects associated with the Test Case
		/// </summary>
		public IList<Action> testActions;
		
		/// <summary>
		/// List of Test API Objects associated with the Test Case
		/// </summary>
		public IList<TestAPI> testAPI;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public TestCaseAPI() : base()
		{
			this.testCaseSteps = new List<TestCaseStep>();
			this.testActions = new List<Action>();
			this.testAPI = new List<TestAPI>();
		}
	}
}