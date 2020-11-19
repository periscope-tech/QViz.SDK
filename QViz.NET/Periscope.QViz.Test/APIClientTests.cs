using System;
using System.Collections.Generic;
using NUnit.Framework;
using Periscope.QViz.JSON;
using Periscope.QViz.Clients;

namespace Periscope.QViz.Test
{
	[TestFixture]
	public class APIClientTests
	{
		private const string APIURL = "https://api-demo.qviz.io";
		private const string CompanyId = "05a0ab39-5198-4ae4-aa29-0ae346db03e2";
		private static AccessUser _apiUser;
		private static User _user;

		[OneTimeSetUp]
		public static void GetAccessToken()
		{
			var authentication = new Authentication("admin", "password");
			var apiClient = new APIClient(APIURL);
			apiClient.Headers.Add(new KeyValue("Content-Type", "application/json"));
			apiClient.Body = authentication;
			_apiUser = apiClient.Post<AccessUser>("/api/authentication");
			if (!apiClient.Response.IsSuccessful)
			{
				throw apiClient.GetError();
			}
		}

		[Test(Description = "Get all the Users from QViz")]
		[Order(1)]
		public void GetAllUsers()
		{
			var apiClient = new APIClient(APIURL);
			apiClient.Queries.Add(new KeyValue("companyId", CompanyId));
			apiClient.Headers.Add(new KeyValue("Content-Type", "application/json"));
			apiClient.Headers.Add(new KeyValue("Authorization", "Bearer " + _apiUser.access_token));
			var allUsers = apiClient.Get<List<User>>("/api/Users");
			if (apiClient.Response.IsSuccessful)
			{
				Assert.True(allUsers.Count > 0, "There should at least be one User");
			}
			else
			{
				Assert.Fail("API Status Code (" + apiClient.Response.StatusCode + ") does not match 200." +
							"\nAPI Error Message: " + apiClient.GetError().Message);
			}
		}

		[Test(Description = "Add a new User to QViz")]
		[Order(2)]
		public void AddUser()
		{
			_user = new User
			{
				userId = Guid.NewGuid().ToString(),
				companyId = CompanyId,
				userName = "Annamalai4",
				name = "Annamalai4",
				password = "Sri@2019",
				firstName = "Srinivasan",
				lastName = "Annamalai",
				email = "srinivasan.annamalai@qviz.io"
			};
			var apiClient = new APIClient(APIURL);
			apiClient.Headers.Add(new KeyValue("Content-Type", "application/json"));
			apiClient.Headers.Add(new KeyValue("Authorization", "Bearer " + _apiUser.access_token));
			apiClient.Headers.Add(new KeyValue("userId", _apiUser.userId));
			apiClient.Body = _user;
			var userResponse = apiClient.Post<UserResponse>("/api/Users");
			if (apiClient.Response.IsSuccessful)
			{
				_user = userResponse.value;
				Assert.AreEqual(
					"User created successfully",
					userResponse.message,
					"User addition should be successful"
				);
			}
			else
			{
				Assert.Fail("API Status Code (" + apiClient.Response.StatusCode + ") does not match 200." +
							"\nAPI Error Message: " + apiClient.GetError().Message);
			}
		}

		[Test(Description = "Get an existing User from QViz")]
		[Order(3)]
		public void GetUser()
		{
			var apiClient = new APIClient(APIURL);
			apiClient.Headers.Add(new KeyValue("Content-Type", "application/json"));
			apiClient.Headers.Add(new KeyValue("Authorization", "Bearer " + _apiUser.access_token));
			var oldUser = apiClient.Get<User>("/api/Users/" + _user.userId);
			if (apiClient.Response.IsSuccessful)
			{
				Assert.AreEqual(
					_user.userId,
					oldUser.userId,
					"Fetched User ID should match the one provided"
				);
			}
			else
			{
				Assert.Fail("API Status Code (" + apiClient.Response.StatusCode + ") does not match 200." +
							"\nAPI Error Message: " + apiClient.GetError().Message);
			}
		}

		[Test(Description = "Update an existing User from QViz")]
		[Order(4)]
		public void UpdateUser()
		{
			var apiClient = new APIClient(APIURL);
			apiClient.Headers.Add(new KeyValue("Content-Type", "application/json"));
			apiClient.Headers.Add(new KeyValue("Authorization", "Bearer " + _apiUser.access_token));
			apiClient.Headers.Add(new KeyValue("userId", _apiUser.userId));
			_user.email = "srinivasan.annamalai@qviz.io";
			_user.userName = string.IsNullOrEmpty(_user.name) ? "Sri" : _user.name;
			_user.name = string.IsNullOrEmpty(_user.userName) ? "Sri" : _user.userName;
			apiClient.Body = _user;
			QVizResponseObject<User> qVizResponse = apiClient.Put<QVizResponseObject<User>>("/api/Users/" + _user.userId);

			if (apiClient.Response.IsSuccessful)
			{
				Assert.AreEqual(
					_user.email,
					qVizResponse.Value.email,
					"Updated User Email should match the one provided"
				);
			}
			else
			{
				Assert.Fail("API Status Code (" + apiClient.Response.StatusCode + ") does not match 200." +
							"\nAPI Error Message: " + apiClient.GetError().Message);
			}
		}

		[Test(Description = "Delete an existing User from QViz")]
		[Order(5)]
		public void DeleteUser()
		{
			var apiClient = new APIClient(APIURL);
			apiClient.Headers.Add(new KeyValue("Content-Type", "application/json"));
			apiClient.Headers.Add(new KeyValue("Authorization", "Bearer " + _apiUser.access_token));
			var userResponse = apiClient.Delete<UserResponse>("/api/Users/" + _user.userId);
			if (apiClient.Response.IsSuccessful)
			{
				Assert.AreEqual(
					"User deleted successfully",
					userResponse.message,
					"User deletion should be successful"
				);
			}
			else
			{
				Assert.Fail("API Status Code (" + apiClient.Response.StatusCode + ") does not match 200." +
							"\nAPI Error Message: " + apiClient.GetError().Message);
			}
		}
	}
}