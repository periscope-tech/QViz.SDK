package com.periscope.qviz.test;

import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.periscope.qviz.client.APIClient;
import com.periscope.qviz.json.*;
import org.apache.http.util.EntityUtils;
import org.junit.jupiter.api.*;

import java.text.SimpleDateFormat;
import java.util.List;
import java.util.UUID;

import static org.junit.jupiter.api.Assertions.*;

@TestMethodOrder(MethodOrderer.OrderAnnotation.class)
public class APIClientTests {

	private static String apiURL = "https://api-demo.qviz.io";
	private static AccessUser apiUser;
	private static ObjectMapper apiMapper;
	private static String apiResponse;
	private static String companyId = "05a0ab39-5198-4ae4-aa29-0ae346db03e2";
	private static User user;

	@BeforeAll
	public static void getAccessToken() throws Exception {
		SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss.SSS");
		apiMapper = new ObjectMapper();
		apiMapper.setDateFormat(dateFormat);
		Authentication authentication = new Authentication("admin", "password");
		APIClient apiClient = new APIClient(apiURL);
		apiClient.headers.add(new KeyValue("Content-Type", "application/json"));
		apiClient.body = apiMapper.writeValueAsString(authentication);
		if (apiClient.post("/api/authentication") == 200) {
			apiResponse = EntityUtils.toString(apiClient.response.getEntity());
			apiUser = apiMapper.readValue(apiResponse, AccessUser.class);
		} else {
			throw apiClient.getError();
		}
	}

	@Test
	@Order(1)
	@DisplayName("Get all the Users from QViz")
	public void getAllUsers() throws Exception {
		APIClient apiClient = new APIClient(apiURL);
		apiClient.queries.add(new KeyValue("companyId", companyId));
		apiClient.headers.add(new KeyValue("Content-Type", "application/json"));
		apiClient.headers.add(new KeyValue("Authorization", "Bearer " + apiUser.access_token));
		if (apiClient.get("/api/Users") == 200) {
			apiResponse = EntityUtils.toString(apiClient.response.getEntity());
			List<User> allUsers = apiMapper.readValue(apiResponse, new TypeReference<List<User>>() {
			});
			assertTrue(allUsers.size() > 0, "There should at least be one User");
		} else {
			fail("API Status Code (" +
				apiClient.response.getStatusLine().getStatusCode() +
				") does not match 200.\nAPI Error Message: " +
				apiClient.getError().getMessage()
			);
		}
	}

	@Test
	@Order(2)
	@DisplayName("Add a new User to QViz")
	public void addUser() throws Exception {
		user = new User();
		user.userId = UUID.randomUUID().toString();
		user.companyId = companyId;
		user.username = "Sri";
		user.password = "Sri@2019";
		user.firstName = "Srinivasan";
		user.lastName = "Annamalai";
		user.email = "email@sri.ink";
		APIClient apiClient = new APIClient(apiURL);
		apiClient.headers.add(new KeyValue("Content-Type", "application/json"));
		apiClient.headers.add(new KeyValue("Authorization", "Bearer " + apiUser.access_token));
		apiClient.headers.add(new KeyValue("userId", apiUser.userId));
		apiClient.body = apiMapper.writeValueAsString(user);
		if (apiClient.post("/api/Users") == 200) {
			apiResponse = EntityUtils.toString(apiClient.response.getEntity());
			UserResponse response = apiMapper.readValue(apiResponse, UserResponse.class);
			user = response.value;
			user.username = user.name;
			assertEquals(
				"User created successfully",
				response.message,
				"User addition should be successful"
			);
		} else {
			fail("API Status Code (" +
				apiClient.response.getStatusLine().getStatusCode() +
				") does not match 200.\nAPI Error Message: " +
				apiClient.getError().getMessage()
			);
		}
	}

	@Test
	@Order(3)
	@DisplayName("Get an existing User from QViz")
	public void getUser() throws Exception {
		APIClient apiClient = new APIClient(apiURL);
		apiClient.headers.add(new KeyValue("Content-Type", "application/json"));
		apiClient.headers.add(new KeyValue("Authorization", "Bearer " + apiUser.access_token));
		if (apiClient.get("/api/Users/" + user.userId) == 200) {
			apiResponse = EntityUtils.toString(apiClient.response.getEntity());
			User oldUser = apiMapper.readValue(apiResponse, User.class);
			assertEquals(
				user.userId,
				oldUser.userId,
				"Fetched User ID should match the one provided"
			);
		} else {
			fail("API Status Code (" +
				apiClient.response.getStatusLine().getStatusCode() +
				") does not match 200.\nAPI Error Message: " +
				apiClient.getError().getMessage()
			);
		}
	}

	@Test
	@Order(4)
	@DisplayName("Update an existing User from QViz")
	public void updateUser() throws Exception {
		APIClient apiClient = new APIClient(apiURL);
		apiClient.headers.add(new KeyValue("Content-Type", "application/json"));
		apiClient.headers.add(new KeyValue("Authorization", "Bearer " + apiUser.access_token));
		apiClient.headers.add(new KeyValue("userId", apiUser.userId));
		user.email = "email@srinivasan.pro";
		apiClient.body = apiMapper.writeValueAsString(user);
		if (apiClient.put("/api/Users/" + user.userId) == 200) {
			apiClient.get("/api/Users/" + user.userId); //Put not returning the user object hence calling the get
			apiResponse = EntityUtils.toString(apiClient.response.getEntity());
			User updatedUser = apiMapper.readValue(apiResponse, User.class);
			assertEquals(
				user.email,
				updatedUser.email,
				"Updated User Email should match the one provided"
			);
		} else {
			fail("API Status Code (" +
				apiClient.response.getStatusLine().getStatusCode() +
				") does not match 200.\nAPI Error Message: " +
				apiClient.getError().getMessage()
			);
		}
	}

	@Test
	@Order(5)
	@DisplayName("Delete an existing User from QViz")
	public void deleteUser() throws Exception {
		APIClient apiClient = new APIClient(apiURL);
		apiClient.headers.add(new KeyValue("Content-Type", "application/json"));
		apiClient.headers.add(new KeyValue("Authorization", "Bearer " + apiUser.access_token));
		if (apiClient.delete("/api/Users/" + user.userId) == 200) {
			apiResponse = EntityUtils.toString(apiClient.response.getEntity());
			UserResponse response = apiMapper.readValue(apiResponse, UserResponse.class);
			assertEquals(
				"User deleted successfully",
				response.message,
				"User deletion should be successful"
			);
		} else {
			fail("API Status Code (" +
				apiClient.response.getStatusLine().getStatusCode() +
				") does not match 200.\nAPI Error Message: " +
				apiClient.getError().getMessage()
			);
		}
	}

}
