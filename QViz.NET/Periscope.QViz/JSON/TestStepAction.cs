using System;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for Test Step Action Details
	/// </summary>
	public class TestStepAction
	{
		/// <summary>
		/// Identifier of the Test Step Action
		/// </summary>
		public string testStepActionId;
		
		/// <summary>
		/// Serial number of the Test Step Action
		/// </summary>
		public int srNo;
		
		/// <summary>
		/// Date and Time on which this Model was Created
		/// </summary>
		public DateTime createdOn;
		
		/// <summary>
		/// Date and Time on which this Model was last Updated
		/// </summary>
		public DateTime updatedOn;
		
		/// <summary>
		/// Action Object associated with the Test Step Action
		/// </summary>
		public Action action;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public TestStepAction()
		{
			this.testStepActionId = "";
			this.srNo = 0;
			this.createdOn = DateTime.Now;
			this.updatedOn = DateTime.Now;
			this.action = new Action();
		}
	}
}