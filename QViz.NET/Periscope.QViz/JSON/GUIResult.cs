using System.Collections.Generic;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for GUI Test Result Details
	/// </summary>
	public class GUIResult : TestResult
	{
		/// <summary>
		/// List of Test Step Result Objects
		/// </summary>
		public IList<TestStepResult> testStepResults;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public GUIResult() : base()
		{
			this.testStepResults = new List<TestStepResult>();
		}
	}
}