﻿using System.Collections.Generic;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for GUI Test Case Details
	/// </summary>
	public class TestCaseGUI : TestCase
	{
		/// <summary>
		/// List of Test Case Step Objects associated with the Test Case
		/// </summary>
		public IList<TestCaseStep> testCaseSteps;
		
		/// <summary>
		/// GET List of Test Action Objects associated with the Test Case
		/// </summary>
		public IList<TestAction> testActions { get; }

		/// <summary>
		/// POST List of Test Action Objects associated with the Test Case
		/// </summary>
		public IList<Action> testCaseActions;
		/// <summary>
		/// List of Test API Objects associated with the Test Case
		/// </summary>
		public IList<TestAPI> testAPIs;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public TestCaseGUI() : base()
		{
			this.testCaseSteps = new List<TestCaseStep>();
			this.testActions = new List<TestAction>();
			this.testAPIs = new List<TestAPI>();
			this.testCaseActions = new List<Action>();
		}
	}
}