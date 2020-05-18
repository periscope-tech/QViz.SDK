namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for GUI Test Result Details
	/// </summary>
	public class GUITestResult
	{
		/// <summary>
		/// GUI Test Result Object
		/// </summary>
		public GUIResult testResult;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public GUITestResult()
		{
			this.testResult = new GUIResult();
		}
	}
}