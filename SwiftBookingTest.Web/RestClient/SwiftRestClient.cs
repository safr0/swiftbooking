using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using RestSharp.Deserializers;
using System.Net;

namespace SwiftBookingTest.Web.RestClient
{
    public class SwiftRestClient : ISwiftRestClient
    {
        private readonly IRestClient restClient;
        public SwiftRestClient(IRestClient restClient)
        {
            if (restClient == null)
            {
                throw new ArgumentNullException("restClient");
            }
            this.restClient = restClient;
            restClient.AddHandler("application/json", new JsonDeserializer());
        }
        public IRestResponse Execute(string serviceHostName, RestRequest request)
        {
            if (string.IsNullOrEmpty(serviceHostName) || request == null)
            {
                throw new ArgumentNullException("serviceHostName", "Service hostname required.");
            }
            restClient.BaseUrl = new Uri(serviceHostName);
            var response = restClient.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpException((int)response.StatusCode, "Rest client service exception");
            }
            return response;
        }
    }
}