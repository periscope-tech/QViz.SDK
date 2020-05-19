package com.periscope.qviz.client;

import com.periscope.qviz.json.KeyValue;
import org.apache.http.HttpEntityEnclosingRequest;
import org.apache.http.HttpRequest;
import org.apache.http.client.methods.*;
import org.apache.http.client.utils.URIBuilder;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.CloseableHttpClient;
import org.apache.http.impl.client.HttpClients;
import org.apache.http.util.EntityUtils;

import java.net.URI;
import java.util.ArrayList;
import java.util.List;

/**
 * Client Library for RESTful API Request/Response cycles
 *
 * <script src="https://cdn.jsdelivr.net/gh/google/code-prettify/loader/run_prettify.js"></script>
 */
public class APIClient {

	/**
	 * Base URL for the API Instance
	 */
	public URI baseURL;

	/**
	 * Base URL for the API Instance
	 */
	public URI fullURL;

	/**
	 * REST Client Object for the API Request/Response cycles
	 */
	public CloseableHttpClient client;

	/**
	 * REST API Response Object
	 */
	public CloseableHttpResponse response;

	/**
	 * List of Header Key-Value Pairs for the REST API Request
	 */
	public List<KeyValue> headers;

	/**
	 * List of Query String Key-Value Pairs for the REST API Request
	 */
	public List<KeyValue> queries;

	/**
	 * REST API Body Object
	 */
	public String body;

	/**
	 * Create a new API Client with default values
	 *
	 * @throws Exception In case of any failures
	 */
	public APIClient() throws Exception {
		this.baseURL = new URI("https://api.qviz.io");
		initialize();
	}

	/**
	 * Create a new API Client with the provided Base URL as String
	 *
	 * @param baseURL Base URL for the API Client as a String
	 * @throws Exception In case of any failures
	 */
	public APIClient(String baseURL) throws Exception {
		this.baseURL = new URI(baseURL);
		initialize();
	}

	/**
	 * Create a new API Client with the provided Base URL as URI Object
	 *
	 * @param baseURL Base URL for the API Client as an URI Object
	 * @throws Exception In case of any failures
	 */
	public APIClient(URI baseURL) throws Exception {
		this.baseURL = baseURL;
		initialize();
	}

	/**
	 * Initialize the API Properties to start fresh
	 */
	private void initialize() {
		client = HttpClients.createDefault();
		response = null;
		headers = new ArrayList<>();
		queries = new ArrayList<>();
		fullURL = baseURL;
		body = "";
	}

	/**
	 * Get the Error details from latest API Response
	 *
	 * @return Exception Object with Error details from API Response
	 * @throws Exception In case of failures
	 */
	public Exception getError() throws Exception {
		String content = EntityUtils.toString(response.getEntity());
		if (content.isEmpty()) {
			return new Exception("HTTP Error #" + response.getStatusLine().getStatusCode() + ": " +
				response.getStatusLine().getReasonPhrase());
		} else {
			return new Exception(content);
		}
	}

	/**
	 * Add the HTTP Headers to the API Request
	 *
	 * @param request HTTP Request Object to add Headers
	 */
	private void addHeaders(HttpRequest request) {
		if (headers != null && headers.size() > 0) {
			for (KeyValue header : headers) {
				request.addHeader(header.key, header.value);
			}
		}
	}

	/**
	 * Add the HTTP Query Parameters to the API Request
	 *
	 * @param resource API Resource to be Queried
	 * @throws Exception In case of any failures
	 */
	private void addQueries(String resource) throws Exception {
		URIBuilder builder = new URIBuilder(this.baseURL);
		builder.setPath(resource);
		if (queries != null && queries.size() > 0) {
			for (KeyValue query : queries) {
				builder.addParameter(query.key, query.value);
			}
		}
		this.fullURL = builder.build();
	}

	/**
	 * Add the HTTP Body to the API Request
	 *
	 * @param request HTTP Entity Enclosing Request Object to add the Body
	 * @throws Exception In case of any failures
	 */
	private void addBody(HttpEntityEnclosingRequest request) throws Exception {
		if (body != null && body.length() > 0) {
			request.setEntity(new StringEntity(body));
		}
	}

	/**
	 * Make an API Request using HTTP GET Method and return the result as HTTP Status Code
	 *
	 * <pre class="prettyprint">
	 * APIClient client = new APIClient();
	 * // Add any HTTP Headers required
	 * client.headers.add(new KeyValue("Content-Type", "application/json"));
	 * if (client.get("/api/Test") == 200) {
	 *     // Success (return Response)
	 *     client.response.getEntity();
	 * } else {
	 *     // Failed (return Error)
	 *     client.getError();
	 * }</pre>
	 *
	 * @param resource Resource Path of the API Request
	 * @return API Response result as HTTP Status Code
	 * @throws Exception In case of failures
	 */
	public int get(String resource) throws Exception {
		// Add HTTP Query Parameters (if any)
		addQueries(resource);
		// Initialize the Request
		HttpGet httpGet = new HttpGet(this.fullURL);
		// Add HTTP Headers (if any)
		addHeaders(httpGet);
		// Execute the Request and get the Response
		try {
			response = client.execute(httpGet);
		} catch (Exception error) {
			return 400;
		}

		return response.getStatusLine().getStatusCode();
	}

	/**
	 * Make an API Request using HTTP POST Method and return the result as HTTP Status Code
	 *
	 * <pre class="prettyprint">
	 * APIClient client = new APIClient();
	 * User user = new User();
	 * user.firstName = "Test";
	 * user.lastName = "User";
	 * // Add any HTTP Headers required
	 * client.headers.add(new KeyValue("Content-Type", "application/json"));
	 * client.body = new ObjectMapper().writeValueAsString(user);
	 * if (client.post("/api/Test") == 200) {
	 *     // Success (return Response)
	 *     client.response.getEntity();
	 * } else {
	 *     // Failed (return Error)
	 *     client.getError();
	 * }</pre>
	 *
	 * @param resource Resource Path of the API Request
	 * @return API Response result as HTTP Status Code
	 * @throws Exception In case of failures
	 */
	public int post(String resource) throws Exception {
		// Add HTTP Query Parameters (if any)
		addQueries(resource);
		// Initialize the Request
		HttpPost httpPost = new HttpPost(this.fullURL);
		// Add HTTP Headers (if any)
		addHeaders(httpPost);
		// Add HTTP Body (if any)
		addBody(httpPost);
		// Execute the Request and get the Response
		try {
			response = client.execute(httpPost);
		} catch (Exception error) {
			return 400;
		}

		return response.getStatusLine().getStatusCode();
	}

	/**
	 * Make an API Request using HTTP PUT Method and return the result as HTTP Status Code
	 *
	 * <pre class="prettyprint">
	 * APIClient client = new APIClient();
	 * User user = new User();
	 * user.firstName = "Updated";
	 * user.lastName = "User";
	 * // Add any HTTP Headers required
	 * client.headers.add(new KeyValue("Content-Type", "application/json"));
	 * client.body = new ObjectMapper().writeValueAsString(user);
	 * if (client.put("/api/Test") == 200) {
	 *     // Success (return Response)
	 *     client.response.getEntity();
	 * } else {
	 *     // Failed (return Error)
	 *     client.getError();
	 * }</pre>
	 *
	 * @param resource Resource Path of the API Request
	 * @return API Response result as HTTP Status Code
	 * @throws Exception In case of failures
	 */
	public int put(String resource) throws Exception {
		// Add HTTP Query Parameters (if any)
		addQueries(resource);
		// Initialize the Request
		HttpPut httpPut = new HttpPut(this.fullURL);
		// Add HTTP Headers (if any)
		addHeaders(httpPut);
		// Add HTTP Body (if any)
		addBody(httpPut);
		// Execute the Request and get the Response
		try {
			response = client.execute(httpPut);
		} catch (Exception error) {
			return 400;
		}

		return response.getStatusLine().getStatusCode();
	}

	/**
	 * Make an API Request using HTTP DELETE Method and return the result as HTTP Status Code
	 *
	 * <pre class="prettyprint">
	 * APIClient client = new APIClient();
	 * // Add any HTTP Headers required
	 * client.headers.add(new KeyValue("Content-Type", "application/json"));
	 * if (client.delete("/api/Test") == 200) {
	 *     // Success (return Response)
	 *     client.response.getEntity();
	 * } else {
	 *     // Failed (return Error)
	 *     client.getError();
	 * }</pre>
	 *
	 * @param resource Resource Path of the API Request
	 * @return API Response result as HTTP Status Code
	 * @throws Exception In case of failures
	 */
	public int delete(String resource) throws Exception {
		// Add HTTP Query Parameters (if any)
		addQueries(resource);
		// Initialize the Request
		HttpDelete httpDelete = new HttpDelete(this.fullURL);
		// Add HTTP Headers (if any)
		addHeaders(httpDelete);
		// Execute the Request and get the Response
		try {
			response = client.execute(httpDelete);
		} catch (Exception error) {
			return 400;
		}

		return response.getStatusLine().getStatusCode();
	}

}
