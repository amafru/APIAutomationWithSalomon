
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace TaskManagementApiAutomation.StepsDefinition
{
    public class ServiceContext
    {
        string url = "https://reqres.in";
        public string responseContent;
        public string responseStatusCode;
        public string responseDescription;

        public void GetEndpoint(string resource)
        {
            var client = new RestClient(url);
            var request = new RestRequest(resource, Method.GET);
            var queryResult = client.Execute(request);
            responseContent = queryResult.Content;
            // assert on the result
            responseStatusCode = queryResult.StatusCode.ToString();
            responseDescription = queryResult.StatusDescription;
        }

        public void PostEndpoint(string resource, string body)
        {
            var client = new RestClient(url);
            var request = new RestRequest(resource, Method.POST);
            request.AddBody(body);
            var queryResult = client.Execute(request);
            // assert on the result
            responseStatusCode = queryResult.ResponseStatus.ToString();
            responseDescription = queryResult.StatusDescription;
        }

        public void PutEndpoint(string resource, Dictionary<string, string> body)
        {
            var client = new RestClient(url);
            var request = new RestRequest(resource, Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(body);
            var queryResult = client.Execute(request);
            // assert on the result
            responseStatusCode = queryResult.ResponseStatus.ToString();
            responseDescription = queryResult.StatusDescription;
        }

        public void DeleteEndpoint(string resource)
        {
            var client = new RestClient(url);
            var request = new RestRequest(resource, Method.DELETE);
            var queryResult = client.Execute(request);
            // assert on the result
            responseStatusCode = queryResult.StatusCode.ToString();
            responseDescription = queryResult.StatusDescription;
        }
    }
}
