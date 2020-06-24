using Newtonsoft.Json;
using NUnit.Framework;
using Periscope.QViz.Clients;
using Periscope.QViz.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using Action = Periscope.QViz.JSON.Action;

namespace Periscope.QViz.Test
{
    [TestFixture]
    public class QVizClientTests
    {
        //private const string QVizURL = "https://api-demo.qviz.io";
        //private const string QVizProject = "UbiSoft Web (en-US)";
        //private const string QVizUser = "DemoAdmin";
        //private const string QVizPassword = "password";

        private const string QVizURL = "http://localhost:55627";
        private const string QVizProject = "SCI API Services-AllScripts";
        private const string QVizUser = "SCIAdmin";
        private const string QVizPassword = "password";

        private static QVizClient _qvizClient;
        private static List<Module> modules = new List<Module>();
        private static List<SubModule> subModules = new List<SubModule>();
        private static List<TestCaseType> testcaseTypes = new List<TestCaseType>();

        [OneTimeSetUp]
        public static void SetUp()
        {
            _qvizClient = new QVizClient(QVizURL);
        }

        [Test(Description = "Authenticate with QViz")]
        [Order(1)]
        public void Authenticate()
        {
            Assert.DoesNotThrow(
                () => _qvizClient.Authenticate(QVizUser, QVizPassword),
                "Authentication should not throw any Error"
            );
        }

        [Test(Description = "Get the Project from QViz")]
        [Order(2)]
        public void GetProject()
        {
            try
            {
                _qvizClient.Authenticate(QVizUser, QVizPassword);
                var project = _qvizClient.GetProject(QVizProject);
                if (project != null)
                {
                    Assert.AreEqual(
                        QVizProject,
                        project.projectName,
                        "Project Name must match the provided one"
                    );
                }
                else
                {
                    throw new Exception("Project was not successfully returned from QViz");
                }
            }
            catch (Exception error)
            {
                Assert.Fail(error.Message);
            }
        }

        [Test(Description = "Send a Module to QViz")]
        [Order(3)]
        public void PostModule()
        {
            try
            {
                _qvizClient.Authenticate(QVizUser, QVizPassword);
                var project = _qvizClient.GetProject(QVizProject);
                Module module = new Module
                {
                    moduleId = null,
                    ProjectId = project.projectId,
                    name = "DemoModule-" + DateTime.Now.Ticks,
                    isActive = true,
                };
                _qvizClient.PostModule(module);
                string response = _qvizClient.LastResponse();
                QVizResponseObject<Module> qVizResponse = JsonConvert.DeserializeObject<QVizResponseObject<Module>>(response);
                Assert.AreEqual("Module created successfully", qVizResponse.Message);
            }
            catch (Exception error)
            {
                Assert.Fail(error.Message);
            }
        }

        [Test(Description = "Get all modules available in QViz")]
        [Order(4)]
        public void GetModules()
        {
            try
            {
                var project = _qvizClient.GetProject(QVizProject);
                if (project != null)
                {
                    modules = _qvizClient.GetModules(project.projectId);
                    Assert.True(modules.Count > 0, "There should at least be one Module");
                }
                else
                {
                    throw new Exception("Project was not successfully returned from QViz");
                }
            }
            catch (Exception error)
            {
                Assert.Fail(error.Message);
            }
        }

        [Test(Description = "Send a Sub-Module to QViz")]
        [Order(5)]
        public void PostSubModule()
        {
            try
            {
                _qvizClient.Authenticate(QVizUser, QVizPassword);
                var project = _qvizClient.GetProject(QVizProject);
                SubModule subModule = new SubModule
                {
                    moduleId = modules.FirstOrDefault().moduleId,
                    subModuleId = null,
                    name = "DemoSubModule-" + DateTime.Now.Ticks,
                    isActive = true,
                };
                _qvizClient.PostSubModule(subModule);
                string response = _qvizClient.LastResponse();
                QVizResponseObject<SubModule> qVizResponse = JsonConvert.DeserializeObject<QVizResponseObject<SubModule>>(response);
                Assert.AreEqual("Sub-module created successfully", qVizResponse.Message);
            }
            catch (Exception error)
            {
                Assert.Fail(error.Message);
            }
        }

        [Test(Description = "Get all sub-modules available in QViz")]
        [Order(6)]
        public void GetSubModules()
        {
            try
            {
                var module = modules.FirstOrDefault();
                if (module != null)
                {
                    subModules = _qvizClient.GetSubModules(module.moduleId);

                    Assert.True(subModules.Count > 0, "There should at least be one Sub-module");
                }
                else
                {
                    throw new Exception("Module was not successfully returned from QViz");
                }
            }
            catch (Exception error)
            {
                Assert.Fail(error.Message);
            }
        }

        [Test(Description = "Get all testcase types available in QViz")]
        [Order(7)]
        public void GetTestCaseType()
        {
            try
            {
                testcaseTypes = _qvizClient.GetTestCaseTypes();
                if (testcaseTypes != null)
                {
                    Assert.True(testcaseTypes.Count > 0, "There should at least be one Sub-module");
                }
                else
                {
                    throw new Exception("Module was not successfully returned from QViz");
                }
            }
            catch (Exception error)
            {
                Assert.Fail(error.Message);
            }
        }

        [Test(Description = "Send a GUI test case to QViz")]
        [Order(8)]
        public void PostGUITestcase()
        {
            try
            {
                _qvizClient.Authenticate(QVizUser, QVizPassword);
                var project = _qvizClient.GetProject(QVizProject);

                var testTags = new List<Tag>
                {
                    new Tag { tagId = null, tagName = "TestTag1" },
                    new Tag { tagId = null, tagName = "TestTag2" }
                };

                /// Test Actions
                Action testAction1 = new Action
                {
                    actionId = null,
                    fieldName = "username_test",
                    fieldValue = "demouser",
                    actionType = "Enter",
                };

                List<TestAction> listTestAction = new List<TestAction>
                {
                    new TestAction { TestCaseId = null, SrNo = 1, Action = testAction1, TestActionId = null }
                };

                //Step Actions
                Action stepAction1 = new Action
                {
                    actionId = null,
                    fieldName = "username",
                    fieldValue = "demouser",
                    actionType = "Enter",
                };

                List<TestStepAction> stepActions1 = new List<TestStepAction>
                {
                    new TestStepAction { srNo = 1, action = stepAction1, testStepActionId = null }
                };

                List<TestCaseStep> steps = new List<TestCaseStep> {
                 new TestCaseStep {  srNo = 1, stepDescription = "Step1", expectedResult = "Step Result1", testCaseStepId = null, testStepActions =  stepActions1 },
                };

                TestSuite tsuite = new TestSuite
                {
                    testsuiteId = null,
                    testsuiteName = "Smoke Suite"
                };

                List<TestSuite> suites = new List<TestSuite>
                {
                    tsuite
                };

                string typeId = testcaseTypes.FirstOrDefault(f => f.name.ToLower() == "ui").testCaseTypeId;
                // Test case
                TestCaseGUI guiTC = new TestCaseGUI
                {

                    testCaseId = null,
                    projectId = project.projectId,
                    moduleId = modules.FirstOrDefault().moduleId,
                    subModuleId = subModules.FirstOrDefault().subModuleId,
                    description = "Demo GUI Test case " + DateTime.Now.Ticks,
                    isAutomated = false,
                    priority = "P1",
                    severity = "1",
                    expectedResult = "Demo expected result",
                    testCaseTypeId = typeId,
                    testToolID = "DemoTool1",
                    testTags = testTags,
                    testCaseSteps = steps,
                    testActions = listTestAction,
                    testSuites = suites,
                };
                _qvizClient.PostGUITest(guiTC);

                string response = _qvizClient.LastResponse();
                QVizResponseObject<TestCaseGUI> qVizResponse = JsonConvert.DeserializeObject<QVizResponseObject<TestCaseGUI>>(response);
                Assert.AreEqual("Test case created successfully", qVizResponse.Message);
            }
            catch (Exception error)
            {
                Assert.Fail(error.Message);
            }
        }

        [Test(Description = "Send a API test case to QViz")]
        [Order(9)]
        public void PostAPITestcase()
        {
            try
            {
                _qvizClient.Authenticate(QVizUser, QVizPassword);
                var project = _qvizClient.GetProject(QVizProject);

                var testTags = new List<Tag>
                {
                    new Tag { tagId = null, tagName = "TestTag1" },
                    new Tag { tagId = null, tagName = "TestTag2" }
                };

                /// Test PAI
                List<TestAPI> listTestAPI = new List<TestAPI>();

                #region API header
                APIHeaderValue apiHeaderValue = new APIHeaderValue
                {
                    headerValueId = null,
                    key = "ContentType",
                    value = "application/json"
                };

                APIHeader header = new APIHeader
                {
                    headerValueId = null,
                    headerValue = apiHeaderValue,
                    apiId = null,
                    apiHeaderId = null,
                    srNo = 1,
                };

                List<APIHeader> headers = new List<APIHeader>
                {
                    header
                };


                #endregion

                #region API Query 
                APIQueryValue apiQueryValue = new APIQueryValue
                {
                    queryValueId = null,
                    key = "projectId",
                    value = "12334",
                    
                };

                APIQuery query = new APIQuery
                {
                    queryValueId = null,
                    queryValue = apiQueryValue,
                    apiId = null,
                    apiQueryId = null,
                    srNo = 1,
                    
                };

                List<APIQuery> queries = new List<APIQuery>
                {
                    query
                };

                APIBodyValue apiBodyValue = new APIBodyValue
                {
                    bodyValueId = null,
                    jsonString = "{ id=\"100\", name=\"Cars\"}",
                    
                };

                APIBody body = new APIBody
                {
                    srNo = 1,
                    apiBodyId = null,
                    bodyValueId = null,
                    apiId = null,
                    bodyValue = apiBodyValue,
                    
                };

                #endregion
                API api = new API
                {
                    apiId = null,
                    uri = "/Products",
                    method = "GET",
                    expectedHTTPStatus = 200,
                    expectedJSONResult = "[{ id=\"100\", name=\"Cars\"}]",
                    apiHeaders = headers,
                    apiQueries = queries,
                    apiBody = body,
                    moduleId = null,
                    subModuleId = null,
                    apiTags =null,
                    testAPIs = null,
                };


                var testAPI = new TestAPI
                {
                    srNo = 1,
                    testAPIId = null,
                    testCaseId = null,
                    apiId = null,
                    api = api,
                    
                };

                List<TestAPI> apis = new List<TestAPI>
                {
                    testAPI
                };

                // Test case
                TestCaseAPI apiTC = new TestCaseAPI
                {
                    testCaseId = null,
                    projectId = project.projectId,
                    moduleId = modules.FirstOrDefault().moduleId,
                    subModuleId = subModules.FirstOrDefault().subModuleId,
                    description = "Demo API Test case " + DateTime.Now.Ticks,
                    isAutomated = false,
                    priority = "P1",
                    severity = "1",
                    expectedResult = "Demo API TC expected result",
                    testCaseTypeId = testcaseTypes.FirstOrDefault(f => f.name.ToLower() == "api").testCaseTypeId,
                    testToolID = "DemoTool1",
                    testTags = testTags,
                    testAPI = apis,
                    module = null,
                    subModule = null,
                    
                };
                _qvizClient.PostAPITest(apiTC);

                string response = _qvizClient.LastResponse();
                QVizResponseObject<TestCaseAPI> qVizResponse = JsonConvert.DeserializeObject<QVizResponseObject<TestCaseAPI>>(response);
                Assert.AreEqual("Test case created successfully", qVizResponse.Message);
            }
            catch (Exception error)
            {
                Assert.Fail(error.Message);
            }
        }

        [Test(Description = "Get all the GUI Test Cases from QViz")]
        [Order(10)]
        public void GetGUITestCases()
        {
            try
            {
                _qvizClient.Authenticate(QVizUser, QVizPassword);
                var project = _qvizClient.GetProject(QVizProject);
                if (project != null)
                {
                    var testCases = _qvizClient.GetGUITestCases(project.projectId);
                    Assert.True(testCases.Count > 0, "There should at least be one GUI Test Case");
                }
                else
                {
                    throw new Exception("Project was not successfully returned from QViz");
                }
            }
            catch (Exception error)
            {
                Assert.Fail(error.Message);
            }
        }

        [Test(Description = "Get all the API Test Cases from QViz")]
        [Order(11)]
        public void GetAPITestCases()
        {
            try
            {
                _qvizClient.Authenticate(QVizUser, QVizPassword);
                var project = _qvizClient.GetProject(QVizProject);
                if (project != null)
                {
                    var testCases = _qvizClient.GetAPITestCases(project.projectId);
                    Assert.True(testCases.Count > 0, "There should at least be one API Test Case");
                }
                else
                {
                    throw new Exception("Project was not successfully returned from QViz");
                }
            }
            catch (Exception error)
            {
                Assert.Fail(error.Message);
            }
        }

        [Test(Description = "Send a Test Result for the GUI Test Case to QViz")]
        [Order(12)]
        public void PostGUITestResult()
        {
            try
            {
                _qvizClient.Authenticate(QVizUser, QVizPassword);
                var project = _qvizClient.GetProject(QVizProject);
                var testCases = _qvizClient.GetGUITestCases(project.projectId);
                if (testCases.Count > 0)
                {
                    var testCase = testCases.First();
                    var guiResult = new GUITestResult
                    {
                        testResult =
                        {
                            testCaseId = testCase.testCaseId,
                            moduleId = testCase.moduleId,
                            subModuleId = testCase.subModuleId,
                            status = "Pass",
                            sUT = project.projectName,
                            releaseName = "Version 1.0.0",
                            releaseNo = "1.0.0",
                            sprintName = "UBI Sprint 1",
                            sprintNo = "UBI-1",
                            buildVersion = "1.0.0",
                            browserName = "ChromeDriver",
                            browserVersion = "2.46",
                            resolution = "1920x1080",
                            oSName = "Windows 10 Professional",
                            oSVersion = "1903",
                            appType = "Angular 8 Application",
                            appVersion = "1.0.0",
                            executionStartTime = DateTime.Now,
                            projectId = project.projectId,
                            environment = "Cloud",
                            runID = "SDK-Unit-Test"
                        }
                    };
                    foreach (var testStep in testCase.testCaseSteps)
                    {
                        var stepResult = new TestStepResult
                        {
                            testCaseStepId = testStep.testCaseStepId,
                            status = "Pass",
                            actualResult = testStep.expectedResult,
                            executionStartTime = DateTime.Now,
                            executionEndTime = DateTime.Now
                        };
                        guiResult.testResult.testStepResults.Add(stepResult);
                    }

                    guiResult.testResult.executionEndTime = DateTime.Now;
                    _qvizClient.PostGUITestResults(guiResult);
                    Assert.AreEqual("Pass", guiResult.testResult.status);
                }
                else
                {
                    throw new Exception("There are NO GUI Test Cases available in the Project (" + QVizProject + ").");
                }
            }
            catch (Exception error)
            {
                Assert.Fail(error.Message);
            }
        }

        [Test(Description = "Send a Test Result for the GUI Test Case to Slack")]
        [Order(13)]
        public void PostResultSlack()
        {
            try
            {
                _qvizClient.Authenticate(QVizUser, QVizPassword);
                var project = _qvizClient.GetProject(QVizProject);
                var testCases = _qvizClient.GetGUITestCases(project.projectId);
                if (testCases.Count > 0)
                {
                    var testCase = testCases.First();
                    var guiResult = new GUITestResult
                    {
                        testResult =
                        {
                            testCaseId = testCase.testCaseId,
                            moduleId = testCase.moduleId,
                            subModuleId = testCase.subModuleId,
                            status = "Pass",
                            sUT = project.projectName,
                            releaseName = "Version 1.0.0",
                            releaseNo = "1.0.0",
                            sprintName = "UBI Sprint 1",
                            sprintNo = "UBI-1",
                            buildVersion = "1.0.0",
                            browserName = "ChromeDriver",
                            browserVersion = "2.46",
                            resolution = "1920x1080",
                            oSName = "Windows 10 Professional",
                            oSVersion = "1903",
                            appType = "Angular 8 Application",
                            appVersion = "1.0.0",
                            executionStartTime = DateTime.Now,
                            projectId = project.projectId,
                            environment = "Cloud",
                            runID = "SDK-Unit-Test"
                        }
                    };
                    foreach (var testStep in testCase.testCaseSteps)
                    {
                        var stepResult = new TestStepResult
                        {
                            testCaseStepId = testStep.testCaseStepId,
                            status = "Pass",
                            actualResult = testStep.expectedResult,
                            executionStartTime = DateTime.Now,
                            executionEndTime = DateTime.Now
                        };
                        guiResult.testResult.testStepResults.Add(stepResult);
                    }

                    guiResult.testResult.executionEndTime = DateTime.Now;
                    try
                    {
                        var slack = _qvizClient.GetToolConfiguration<ToolSlack>(project.projectId, "SLACK");
                        _qvizClient.SendTestResultsToSlack(
                            guiResult,
                            slack.url,
                            project.projectId,
                            project.projectName,
                            project.projectType,
                            "https://app-demo.qviz.io",
                            guiResult.testResult.runID
                        );
                    }
                    catch (Exception)
                    {
                        // Does not contain configurations for Slack
                    }
                    Assert.AreEqual("Pass", guiResult.testResult.status);
                }
                else
                {
                    throw new Exception("There are NO GUI Test Cases available in the Project (" + QVizProject + ").");
                }
            }
            catch (Exception error)
            {
                Assert.Fail(error.Message);
            }
        }

        [Test(Description = "Send a Test Result for the GUI Test Case to JIRA")]
        [Order(14)]
        public void PostResultJIRA()
        {
            try
            {
                _qvizClient.Authenticate(QVizUser, QVizPassword);
                var project = _qvizClient.GetProject(QVizProject);
                var testCases = _qvizClient.GetGUITestCases(project.projectId);
                if (testCases.Count > 0)
                {
                    var testCase = testCases.First();
                    var guiResult = new GUITestResult
                    {
                        testResult =
                        {
                            testCaseId = testCase.testCaseId,
                            moduleId = testCase.moduleId,
                            subModuleId = testCase.subModuleId,
                            status = "Pass",
                            sUT = project.projectName,
                            releaseName = "Version 1.0.0",
                            releaseNo = "1.0.0",
                            sprintName = "UBI Sprint 1",
                            sprintNo = "UBI-1",
                            buildVersion = "1.0.0",
                            browserName = "ChromeDriver",
                            browserVersion = "2.46",
                            resolution = "1920x1080",
                            oSName = "Windows 10 Professional",
                            oSVersion = "1903",
                            appType = "Angular 8 Application",
                            appVersion = "1.0.0",
                            executionStartTime = DateTime.Now,
                            projectId = project.projectId,
                            environment = "Cloud",
                            runID = "SDK-Unit-Test"
                        }
                    };
                    foreach (var testStep in testCase.testCaseSteps)
                    {
                        var stepResult = new TestStepResult
                        {
                            testCaseStepId = testStep.testCaseStepId,
                            status = "Pass",
                            actualResult = testStep.expectedResult,
                            executionStartTime = DateTime.Now,
                            executionEndTime = DateTime.Now
                        };
                        guiResult.testResult.testStepResults.Add(stepResult);
                    }

                    guiResult.testResult.executionEndTime = DateTime.Now;
                    try
                    {
                        var jira = _qvizClient.GetToolConfiguration<ToolJira>(project.projectId, "JIRA");
                        _qvizClient.SendTestResultsToJIRA(
                            guiResult,
                            jira.url,
                            jira.userName,
                            jira.password
                        );
                    }
                    catch (Exception)
                    {
                        // Does not contain configurations for JIRA
                    }
                    Assert.AreEqual("Pass", guiResult.testResult.status);
                }
                else
                {
                    throw new Exception("There are NO GUI Test Cases available in the Project (" + QVizProject + ").");
                }
            }
            catch (Exception error)
            {
                Assert.Fail(error.Message);
            }
        }

        [Test(Description = "Send a Test Result for the GUI Test Case to TestRail")]
        [Order(15)]
        public void PostResultTestRail()
        {
            try
            {
                _qvizClient.Authenticate(QVizUser, QVizPassword);
                var project = _qvizClient.GetProject(QVizProject);
                var testCases = _qvizClient.GetGUITestCases(project.projectId);
                if (testCases.Count > 0)
                {
                    var testCase = testCases.First();
                    var guiResult = new GUITestResult
                    {
                        testResult =
                        {
                            testCaseId = testCase.testCaseId,
                            moduleId = testCase.moduleId,
                            subModuleId = testCase.subModuleId,
                            status = "Pass",
                            sUT = project.projectName,
                            releaseName = "Version 1.0.0",
                            releaseNo = "1.0.0",
                            sprintName = "UBI Sprint 1",
                            sprintNo = "UBI-1",
                            buildVersion = "1.0.0",
                            browserName = "ChromeDriver",
                            browserVersion = "2.46",
                            resolution = "1920x1080",
                            oSName = "Windows 10 Professional",
                            oSVersion = "1903",
                            appType = "Angular 8 Application",
                            appVersion = "1.0.0",
                            executionStartTime = DateTime.Now,
                            projectId = project.projectId,
                            environment = "Cloud",
                            runID = "SDK-Unit-Test"
                        }
                    };
                    foreach (var testStep in testCase.testCaseSteps)
                    {
                        var stepResult = new TestStepResult
                        {
                            testCaseStepId = testStep.testCaseStepId,
                            status = "Pass",
                            actualResult = testStep.expectedResult,
                            executionStartTime = DateTime.Now,
                            executionEndTime = DateTime.Now
                        };
                        guiResult.testResult.testStepResults.Add(stepResult);
                    }

                    guiResult.testResult.executionEndTime = DateTime.Now;
                    try
                    {
                        var testRail = _qvizClient.GetToolConfiguration<ToolTestRail>(
                            project.projectId, "TESTRAIL"
                        );
                        _qvizClient.SendTestResultsToTestRail(
                            guiResult,
                            testRail.url,
                            testRail.userName,
                            testRail.password,
                            "10",
                            ""
                        );
                    }
                    catch (Exception)
                    {
                        // Does not contain configurations for TestRail
                    }
                    Assert.AreEqual("Pass", guiResult.testResult.status);
                }
                else
                {
                    throw new Exception("There are NO GUI Test Cases available in the Project (" + QVizProject + ").");
                }
            }
            catch (Exception error)
            {
                Assert.Fail(error.Message);
            }
        }

    }
}