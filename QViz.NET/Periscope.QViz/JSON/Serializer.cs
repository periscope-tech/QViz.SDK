using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization;

namespace Periscope.QViz.JSON
{
	/// <summary>
	/// Class for using JSON.NET Serializer with RestSharp Library
	/// </summary>
	public class Serializer : IRestSerializer
	{
		/// <summary>
		/// Serialize the given Object as JSON String using JSON.NET Library
		/// </summary>
		/// <param name="obj">Object to be serialized as JSON String</param>
		/// <returns>Serialized JSON as String</returns>
		public string Serialize(object obj) => JsonConvert.SerializeObject(obj);

		/// <summary>
		/// Serialize the given Parameter Object as JSON String using JSON.NET Library
		/// </summary>
		/// <param name="parameter">Parameter Object to be serialized as JSON String</param>
		/// <returns>Serialized JSON as String</returns>
		public string Serialize(Parameter parameter) => JsonConvert.SerializeObject(parameter.Value);

		/// <summary>
		/// Deserialize the given RestSharp API Response content into C# Object
		/// </summary>
		/// <param name="response">RestSharp API Response Object</param>
		/// <typeparam name="T">Type of C# Object to be deserialized into</typeparam>
		/// <returns>Deserialized C# Object in the given Type</returns>
		public T Deserialize<T>(IRestResponse response) => JsonConvert.DeserializeObject<T>(response.Content);

		/// <summary>
		/// List of supported HTTP Content Types
		/// </summary>
		public string[] SupportedContentTypes { get; } =
		{
			"application/json", "text/json", "text/x-json", "text/javascript", "*+json"
		};

		/// <summary>
		/// HTTP Content Type to be used in Serialization/Deserialization
		/// </summary>
		public string ContentType { get; set; } = "application/json";

		/// <summary>
		/// Data Format to be used in Serialization/Deserialization
		/// </summary>
		public DataFormat DataFormat { get; } = DataFormat.Json;
	}
}
