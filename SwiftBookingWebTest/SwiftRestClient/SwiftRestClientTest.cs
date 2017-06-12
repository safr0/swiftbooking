using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;
using RestSharp.Deserializers;
using SwiftBookingTest.Web.RestClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SwiftBookingWebTest.SwiftRestClientTest
{
    [TestClass]
    public class SwiftRestClientTest
    {
        private Mock<IRestClient> restClientMock;
        private SwiftRestClient testSubject;
        private const string contentTypes = "application/json";
        private readonly string ApiHostname = ConfigurationManager.AppSettings["SwiftApiHostname"];
        private readonly string ApiEndpoint = ConfigurationManager.AppSettings["SwiftApiDeliveriesEndpoint"];

        [TestInitialize]
        public void TestInitialize()
        {
            restClientMock = new Mock<IRestClient>(MockBehavior.Strict);
            restClientMock.Setup(rcm => rcm.AddHandler(contentTypes, It.IsAny<JsonDeserializer>()));
            testSubject = new SwiftRestClient(restClientMock.Object);
        }

        /// <summary>
        /// Null value constructor
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullValueConstructorTest()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new SwiftRestClient(null);
        }
        
        /// <summary>
        /// Constructor test
        /// </summary>
        [TestMethod]
        public void ConstructorTest()
        {
            //Act
            var restClient = new SwiftRestClient(restClientMock.Object);

            //Assert
            Assert.IsNotNull(restClient);
        }

        /// <summary>
        /// Parameter as null value test
        /// </summary>
        /// <exception cref="HttpException">!= HttpStatusCode.OK</exception>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SwiftRestClientExecuteWithNullParamTest()
        {
            //Act
            testSubject.Execute(null, new RestRequest());
        }

        /// <summary>
        /// Parameter as null value test
        /// </summary>
        /// <exception cref="HttpException">!= HttpStatusCode.OK</exception>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SwiftRestClientExecuteWithNullParamRequestTest()
        {
            //Arrange
            const string hostName = "https://maps.googleapis.com/maps/api";

            //Act
            testSubject.Execute(hostName, null);
        }

        /// <exception cref="HttpException">!= HttpStatusCode.OK</exception>
        [TestMethod]
        [ExpectedException(typeof(HttpException))]
        public void SwiftRestClientExecuteBadRequestTest()
        {
            //Arrange
            const string hostName = "https://maps.googleapis.com/maps/api";
            restClientMock.SetupAllProperties();
            restClientMock.Setup(rcm => rcm.Execute(It.IsAny<RestRequest>()))
                .Returns(new RestResponse { Content = string.Empty, StatusCode = HttpStatusCode.BadRequest });

            //Act
            testSubject.Execute(hostName, new RestRequest());
        }

        /// <summary>
        /// Execute test for rest client
        /// </summary>
        /// <exception cref="MockException">At least one expectation was not met.</exception>
        /// <exception cref="HttpException">!= HttpStatusCode.OK</exception>
        [TestMethod]
        public void SwiftRestClientExecuteTest()
        {
            //Arrange
            const string hostName = "https://maps.googleapis.com/maps/api";
            const string responseContents = "ResponseContents";
            restClientMock.SetupSet<Uri>(a => a.BaseUrl = It.IsAny<Uri>());
            restClientMock.Setup(rcm => rcm.Execute(It.IsAny<RestRequest>()))
                .Returns(new RestResponse { Content = responseContents, StatusCode = HttpStatusCode.OK });

            //Act
            var results = testSubject.Execute(hostName, new RestRequest());

            //Assert
            restClientMock.VerifyAll();
            Assert.IsNotNull(results);
            Assert.AreEqual(results.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(results.Content, responseContents);
        }

        /// <summary>
        /// Service integration 
        /// </summary>
        /// <exception cref="HttpException">!= HttpStatusCode.OK</exception>
        [ExpectedException(typeof (HttpException))]
        [TestMethod]
        public void ServiceIntegrationTest()
        {
            //Arrange
            const string hostName = "https://app.getswift.co/api/v2/deliveries"; //TODO: Add to configuration
            SwiftRestClient client = new SwiftRestClient(new RestSharp.RestClient(hostName));

            //Act
            var results = client.Execute(hostName, new RestRequest());

            //Assert 
            Assert.IsNotNull(results);
            Assert.AreEqual(results.StatusCode, HttpStatusCode.OK);
            Assert.AreNotEqual(results.Content, string.Empty);
        }

        //TODO: status codes test based on types of status codes returned by hosted service
        //Examples: https://github.com/restsharp/RestSharp/blob/master/RestSharp.IntegrationTests/StatusCodeTests.cs
    }
}
