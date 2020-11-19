using System;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for GUI Action Details
	/// </summary>
	public class Action
	{
		/// <summary>
		/// Identifier of the GUI Action
		/// </summary>
		public string actionId;

		/// <summary>
		/// Type of the GUI Action
		/// </summary>
		public string actionType;

		/// <summary>
		/// Name of the Field to perform the GUI Action
		/// </summary>
		public string fieldName;

		/// <summary>
		/// Value of the Field to provide for in the GUI Action
		/// </summary>
		public string fieldValue;

		/// <summary>
		/// Date and Time on which this Model was Created
		/// </summary>
		public DateTime createdOn;

		/// <summary>
		/// Date and Time on which this Model was last Updated
		/// </summary>
		public DateTime updatedOn;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public Action()
		{
			this.actionId = "";
			this.actionType = "";
			this.fieldName = "";
			this.fieldValue = "";
			this.createdOn = DateTime.Now;
			this.updatedOn = DateTime.Now;
		}
	}
}