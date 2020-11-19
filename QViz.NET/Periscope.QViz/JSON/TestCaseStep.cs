using System;
using System.Collections.Generic;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Test Case Step Details
	/// </summary>
	public class TestCaseStep
	{
		/// <summary>
		/// Identifier of the Test Case Step
		/// </summary>
		public string testCaseStepId;

		/// <summary>
		/// Serial Number of the Test Case Step
		/// </summary>
		public int srNo;

		/// <summary>
		/// Description of the Test Case Step
		/// </summary>
		public string stepDescription;

		/// <summary>
		/// Expected result from the Test Case Step execution
		/// </summary>
		public string expectedResult;

		/// <summary>
		/// Date and Time on which this Model was Created
		/// </summary>
		public DateTime createdOn;

		/// <summary>
		/// Date and Time on which this Model was last Updated
		/// </summary>
		public DateTime updatedOn;

		/// <summary>
		/// GET List of Test Step Actions Objects associated with the Test Case Step
		/// </summary>
		public IList<TestStepAction> testStepActions { get; }

		/// <summary>
		/// POST List of Test Step Actions Objects associated with the Test Case Step
		/// </summary>
		public List<Action> stepActions;

		/// <summary>
		/// List of Test Step Tag Objects associated with the Test Case Step
		/// </summary>
		public IList<TestStepTag> testStepTags;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public TestCaseStep()
		{
			this.testCaseStepId = "";
			this.srNo = 0;
			this.stepDescription = "";
			this.expectedResult = "";
			this.createdOn = DateTime.Now;
			this.updatedOn = DateTime.Now;
			this.testStepActions = new List<TestStepAction>();
			this.testStepTags = new List<TestStepTag>();
			this.stepActions = new List<Action>();
		}
	}
}