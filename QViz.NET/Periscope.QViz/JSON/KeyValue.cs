namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model for basic Key-Value Pair Details
	/// </summary>
	public class KeyValue
	{
		/// <summary>
		/// Key of the JSON Pair Object
		/// </summary>
		public string key;
		
		/// <summary>
		/// Value of the JSON Pair Object
		/// </summary>
		public string value;

		/// <summary>
		/// Initialize the Key-Value Pair for JSON Object
		/// </summary>
		public KeyValue()
		{
			this.key = "";
			this.value = "";
		}

		/// <summary>
		/// Create a new Key-Value Pair with the provided details
		/// </summary>
		/// <param name="key">Key of the JSON Pair Object</param>
		/// <param name="value">Value of the JSON Pair Object</param>
		public KeyValue(string key, string value)
		{
			this.key = key;
			this.value = value;
		}
	}
}