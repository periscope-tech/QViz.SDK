using System;
using System.Collections.Generic;
using Periscope.QViz.JSON;
using RestSharp;

namespace Periscope.QViz.Clients
{
	/// <summary>
	/// Client Library for RESTful API Request/Response cycles
	/// </summary>
	public class APIClient
	{
		#region Public Properties
		/// <summary>
		/// Base URL for the API Instance
		/// </summary>
		public Uri BaseURL { get; set; }

		/// <summary>
		/// REST Client Object for the API Request/Response cycles
		/// </summary>
		public IRestClient Client { get; set; }

		/// <summary>
		/// REST API Request Object
		/// </summary>
		public IRestRequest Request { get; set; }

		/// <summary>
		/// REST API Response Object
		/// </summary>
		public IRestResponse Response { get; set; }

		/// <summary>
		/// List of Header Key-Value Pairs for the REST API Request
		/// </summary>
		public List<KeyValue> Headers { get; set; }

		/// <summary>
		/// List of Query String Key-Value Pairs for the REST API Request
		/// </summary>
		public List<KeyValue> Queries { get; set; }

		/// <summary>
		/// REST API Body Object
		/// </summary>
		public object Body { get; set; }
		#endregion

		#region Private Proprties
		private Exception _exception;
		#endregion

		#region Constructors
		/// <summary>
		/// Create a new API Client with default values
		/// </summary>
		public APIClient()
		{
			BaseURL = new Uri("https://api.qviz.io");
			Initialize();
		}

		/// <summary>
		/// Create a new API Client with provided Base URL as String
		/// </summary>
		/// <param name="baseURL">Base URL for the API Client as String</param>
		public APIClient(string baseURL)
		{
			BaseURL = new Uri(baseURL);
			Initialize();
		}

		/// <summary>
		/// Create a new API Client with provided Base URL as URI Object
		/// </summary>
		/// <param name="baseURL">Base URL for the API Client as URI Object</param>
		public APIClient(Uri baseURL)
		{
			BaseURL = baseURL;
			Initialize();
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// Initialize the API Client with provided values
		/// </summary>
		private void Initialize()
		{
			Client = new RestClient(BaseURL).UseSerializer<Serializer>();
			Request = null;
			Response = null;
			Headers = new List<KeyValue>();
			Queries = new List<KeyValue>();
			Body = string.Empty;
			_exception = new Exception();
		}

		/// <summary>
		/// Add the HTTP Headers to the API Request
		/// </summary>
		private void AddHeaders()
		{
			if (Headers == null || Headers.Count == 0) return;
			foreach (var header in Headers)
			{
				Request.AddHeader(header.key, header.value);
			}
		}

		/// <summary>
		/// Add the HTTP Query Parameters to the API Request
		/// </summary>
		private void AddQueries()
		{
			if (Queries == null || Queries.Count == 0) return;
			foreach (var query in Queries)
			{
				Request.AddQueryParameter(query.key, query.value);
			}
		}

		/// <summary>
		/// Add the HTTP Body to the API Request
		/// </summary>
		private void AddBody()
		{
			if (Body == null) return;
			Request.AddJsonBody(Body);
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Get the Error details from latest API Response
		/// </summary>
		/// <returns>Exception Object with Error details from API Response</returns>
		public Exception GetError()
		{
			// Check whether any API Error was returned as part of the Response Content
			if (Response.Content.Length > 0)
			{
				_exception = new Exception(Response.Content);
			}
			// Check whether any API Error is available
			else if (!string.IsNullOrEmpty(Response.ErrorException.Message))
			{
				_exception = Response.ErrorException;
			}

			return _exception;
		}

		/// <summary>
		/// Execute the HTTP GET API Request and return the JSON Object(s)
		/// </summary>
		/// <typeparam name="T">Type of the JSON Object(s) expected from API Response</typeparam>
		/// <param name="resource">Resource Path of the API Request</param>
		/// <returns>JSON Object(s) from API Response</returns>
		public T Get<T>(string resource) where T : new()
		{
			// Initialize the API Request
			Request = new RestRequest(resource, Method.GET);
			// Add HTTP Query Parameters (if any)
			AddQueries();
			// Add HTTP Headers (if any)
			AddHeaders();
			// Execute the API Request and return the Response
			try
			{
				var response = Client.Execute<T>(Request);
				Response = response;
				return response.Data;
			}
			catch (Exception error)
			{
				_exception = error;
				return default;
			}
		}

		/// <summary>
		/// Execute the HTTP GET API Request and return the JSON Object(s)
		/// </summary>
		/// <typeparam name="T">Type of the JSON Object(s) expected from API Response</typeparam>
		/// <param name="resource">Resource Path of the API Request</param>
		/// <returns>JSON Object(s) from API Response</returns>
		public T Post<T>(string resource) where T : new()
		{
			// Initialize the API Request
			Request = new RestRequest(resource, Method.POST);
			// Add HTTP Query Parameters (if any)
			AddQueries();
			// Add HTTP Headers (if any)
			AddHeaders();
			// Add HTTP Body (if any)
			AddBody();
			// Execute the API Request and return the Response
			try
			{
				var response = Client.Execute<T>(Request);
				Response = response;
				return response.Data;
			}
			catch (Exception error)
			{
				_exception = error;
				return default;
			}
		}

		/// <summary>
		/// Execute the HTTP GET API Request and return the JSON Object(s)
		/// </summary>
		/// <typeparam name="T">Type of the JSON Object(s) expected from API Response</typeparam>
		/// <param name="resource">Resource Path of the API Request</param>
		/// <returns>JSON Object(s) from API Response</returns>
		public T Put<T>(string resource) where T : new()
		{
			// Initialize the API Request
			Request = new RestRequest(resource, Method.PUT);
			// Add HTTP Query Parameters (if any)
			AddQueries();
			// Add HTTP Headers (if any)
			AddHeaders();
			// Add HTTP Body (if any)
			AddBody();
			// Execute the API Request and return the Response
			try
			{
				var response = Client.Execute<T>(Request);
				Response = response;
				return response.Data;
			}
			catch (Exception error)
			{
				_exception = error;
				return default;
			}
		}

		/// <summary>
		/// Execute the HTTP GET API Request and return the JSON Object(s)
		/// </summary>
		/// <typeparam name="T">Type of the JSON Object(s) expected from API Response</typeparam>
		/// <param name="resource">Resource Path of the API Request</param>
		/// <returns>JSON Object(s) from API Response</returns>
		public T Delete<T>(string resource) where T : new()
		{
			// Initialize the API Request
			Request = new RestRequest(resource, Method.DELETE);
			// Add HTTP Query Parameters (if any)
			AddQueries();
			// Add HTTP Headers (if any)
			AddHeaders();
			// Execute the API Request and return the Response
			try
			{
				var response = Client.Execute<T>(Request);
				Response = response;
				return response.Data;
			}
			catch (Exception error)
			{
				_exception = error;
				return default;
			}
		}
		#endregion
	}
}