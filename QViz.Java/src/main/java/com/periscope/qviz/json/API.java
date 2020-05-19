package com.periscope.qviz.json;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 * JSON Model for Test API Details
 */
public class API {

	/**
	 * Identifier of the API
	 */
	public String apiId;

	/**
	 * Uniform Resource Identifier of the API
	 */
	public String uri;

	/**
	 * HTTP Method of the API (GET, POST, PUT, DELETE)
	 */
	public String method;

	/**
	 * Identifier of the Project Module for the API
	 */
	public String moduleId;

	/**
	 * Identifier of the Project Sub Module for the API
	 */
	public String subModuleId;

	/**
	 * Expected HTTP Status Code from the API Response
	 */
	public Integer expectedHTTPStatus;

	/**
	 * Expected JSON Data from the API Response
	 */
	public String expectedJSONResult;

	/**
	 * Date and Time on which this Model was Created
	 */
	public Date createdOn;

	/**
	 * Date and Time on which this Model was last Updated
	 */
	public Date updatedOn;

	/**
	 * List of API Test Cases linked with this API
	 */
	public List<TestAPI> testAPIs;

	/**
	 * List of HTTP Header Key-Value pairs for the API Request
	 */
	public List<APIHeader> apiHeaders;

	/**
	 * List of Query String Key-Value pairs for the API Request
	 */
	public List<APIQuery> apiQueries;

	/**
	 * HTTP Body Data for the API Request
	 */
	public APIBody apiBody;

	/**
	 * List of Tags associated with this API Request
	 */
	public List<Tag> apiTags;

	/**
	 * Default Constructor
	 */
	public API() {
		this.apiId = "";
		this.uri = "";
		this.method = "";
		this.moduleId = "";
		this.subModuleId = "";
		this.expectedHTTPStatus = 0;
		this.expectedJSONResult = "";
		this.createdOn = null;
		this.updatedOn = null;
		this.testAPIs = new ArrayList<>();
		this.apiHeaders = new ArrayList<>();
		this.apiQueries = new ArrayList<>();
		this.apiBody = new APIBody();
		this.apiTags = new ArrayList<>();
	}

}
