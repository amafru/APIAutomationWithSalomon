using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TaskManagementApiAutomation.Model;

namespace TaskManagementApiAutomation.StepsDefinition
{
    [Binding]
    public class TestsSteps
    {
        ServiceContext serviceContext;
        public TestsSteps(ServiceContext _serviceContext)
        {
            serviceContext = _serviceContext;
        }

        [Given(@"that reqres service is started with GET endpoint (.*)")]
        public void GivenThatReqresServiceIsStartedWithGETEndpointUsersPage(string resource)
        {
            serviceContext.GetEndpoint(resource);
        }

        [Given(@"that reqres service is started with POST endpoint (.*)")]
        public void GivenThatReqresServiceIsStartedWithPOSTEndpointApiUsers(string resource)
        {
            serviceContext.PostEndpoint(resource, File.ReadAllText(@"PostSingleUser.json"));
        }

        [Given(@"that reqres service is started with PUT endpoint (.*)")]
        public void GivenThatReqresServiceIsStartedWithPUTEndpointApiUsers(string resource)
        {
            //List<string> names = new List<string>();
            //names.Add("Kolade");
            //names.Add("Kaz");
            //names.Remove("Kolade");            

            Dictionary<string, string> dataToPut = new Dictionary<string, string>();
            //dataToPut["name"] = "morpheus";
            //dataToPut["job"] = "zion resident";  OR below code

            dataToPut.Add("name", "morpheus");
            dataToPut.Add("job", "zion resident");

            serviceContext.PutEndpoint(resource, dataToPut);
        }

        [Given(@"that reqres service is started with DELETE endpoint (.*)")]
        public void GivenThatReqresServiceIsStartedWithDELETEEndpointApiUsers(string resource)
        {
            serviceContext.DeleteEndpoint(resource);
        }

        [Then(@"the list of users are returned as below")]
        public void ThenTheListOfUsersAreReturnedAsBelow(Table table)
        {
            var expectedData = table.CreateSet<Data>();
            string actualResultContent = serviceContext.responseContent;
            var actualData = JsonConvert.DeserializeObject<MultipleUsersPage>(actualResultContent).data;
            Assert.IsTrue(CompareTwoLists(expectedData, actualData));
        }

        [Then(@"the user record is as below")]
        public void ThenTheUserRecordIsAsBelow(Table table)
        {
            var expectedData = table.CreateSet<Data>();
            string actualResultContent = serviceContext.responseContent;
            var actualData = JsonConvert.DeserializeObject(actualResultContent);
            Assert.IsTrue(CompareTwoLists(expectedData, actualData));
        }


        public bool CompareTwoLists(object firstList, object secondList)
        {
            var firstObject = JsonConvert.SerializeObject(firstList);
            var secondObject = JsonConvert.SerializeObject(secondList);
            return firstObject == secondObject;
        }

        [Then(@"the StatusCode is equal to (.*)")]
        public void ThenTheStatusCodeIsEqualToOK(string expectedCode)
        {
            string actualResultStatusCode = serviceContext.responseStatusCode;
            Assert.IsTrue(actualResultStatusCode.Equals(expectedCode));
        }

        [Then(@"the ResponseDescription is equal to (.*)")]
        public void ThenTheResponseDescriptionIsEqualToOK(string expectedCode)
        {
            string actualResultResponseDescription = serviceContext.responseDescription;
            Assert.IsTrue(actualResultResponseDescription.Equals(expectedCode));
        }

        [Then(@"the status code for Post is equal to (.*)")]
        public void ThenTheStatusCodeForPostIsEqualToCreated(string expectedCode)
        {
            string actualResultStatusCode = serviceContext.responseStatusCode;
            Assert.IsTrue(actualResultStatusCode.Equals(expectedCode));
        }

        [Then(@"the response status for Post is equal to (.*)")]
        public void ThenTheResponseStatusForPostIsEqualToCompleted(string expectedCode)
        {
            string actualResultStatusCode = serviceContext.responseDescription;
            Assert.IsTrue(actualResultStatusCode.Equals(expectedCode));
        }

        [Then(@"the status code for Put is equal to (.*)")]
        public void ThenTheStatusCodeForPutIsEqualToCreated(string expectedCode)
        {
            string actualResultStatusCode = serviceContext.responseStatusCode;
            Assert.IsTrue(actualResultStatusCode.Equals(expectedCode));
        }

        [Then(@"the response status for Put is equal to (.*)")]
        public void ThenTheResponseStatusForPutIsEqualToCompleted(string expectedCode)
        {

            string actualResultStatusCode = serviceContext.responseDescription;
            Assert.IsTrue(actualResultStatusCode.Equals(expectedCode));
        }

        [Then(@"the status code for Delete is equal to (.*)")]
        public void ThenTheStatusCodeForDeleteIsEqualToNoContent(string expectedCode)
        {
            string actualResultStatusCode = serviceContext.responseStatusCode;
            Assert.IsTrue(actualResultStatusCode.Equals(expectedCode));
        }

        [Then(@"the response status for Delete is equal to (.*)")]
        public void ThenTheResponseStatusForDeleteIsEqualToCompleted(string expectedCode)
        {
            string actualResultStatusCode = serviceContext.responseDescription;
            Assert.IsTrue(actualResultStatusCode.Equals(expectedCode));
        }
    }
}
