using RestSharp;

namespace SwiftBookingTest.Web.RestClient
{
    /// <summary>
    /// Interface for swift rest client
    /// </summary>
    public interface ISwiftRestClient
    {
        /// <summary>
        /// Executes the request
        /// </summary>
        IRestResponse Execute(string serviceHostName, RestRequest request);
    }
}
