namespace Periscope.QViz.JSON
{
	/// <summary>
	/// JSON Model Class for Tag Details
	/// </summary>
	public class Tag
	{
		/// <summary>
		/// Identifier of the Tag
		/// </summary>
		public string tagId;
		
		/// <summary>
		/// Name of the Tag
		/// </summary>
		public string tagName;

		/// <summary>
		/// Default Constructor
		/// </summary>
		public Tag()
		{
			this.tagId = "";
			this.tagName = "";
		}

		/// <summary>
		/// Create a new Tag with the provided values
		/// </summary>
		/// <param name="id">Identifier of the Tag</param>
		/// <param name="name">Name of the Tag</param>
		public Tag(string id, string name)
		{
			this.tagId = id;
			this.tagName = name;
		}
	}
}
