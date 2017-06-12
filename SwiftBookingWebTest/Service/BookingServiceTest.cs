using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RestSharp;
using SwiftBookingTest.Web.Models;
using SwiftBookingTest.Web.Repository;
using SwiftBookingTest.Web.RestClient;
using SwiftBookingTest.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace SwiftBookingWebTest.Service
{
    /// <summary>
    /// Test class for BookingService
    /// <seealso cref="BookingService"/>
    /// </summary>
    [TestClass]
    public class BookingServiceTest
    {
        private Mock<ISwiftRestClient> swiftRestClientMock;
        private Mock<ISwiftBookingRepository> bookingRepositoryMock;
        private BookingService testSubject;

        /// <summary>
        /// Test initializer
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            swiftRestClientMock = new Mock<ISwiftRestClient>();
            bookingRepositoryMock = new Mock<ISwiftBookingRepository>(MockBehavior.Strict);
            testSubject = new BookingService(swiftRestClientMock.Object, bookingRepositoryMock.Object);
        }

        /// <summary>
        /// Null value constructor
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullValueConstructorTest()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new BookingService(null, bookingRepositoryMock.Object);
        }
        /// <summary>
        /// Null value constructor
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullRepositoryValueConstructorTest()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new BookingService(swiftRestClientMock.Object, null);
        }
        /// <summary>
        /// Get all booking test
        /// </summary>
        [TestMethod]
        public void GetAllBookingTest()
        {
            //Setup
            IList<SwiftBooking> bookings = new List<SwiftBooking>();
            IQueryable<SwiftBooking> queryableCountries = bookings.AsQueryable();
            bookingRepositoryMock.Setup(br => br.GetAll()).Returns(queryableCountries);

            //Act
            var results = testSubject.GetBookings();

            //Assert
            bookingRepositoryMock.VerifyAll();
            swiftRestClientMock.VerifyAll();
            Assert.AreNotEqual(null, results);
        }
        /// <summary>
        /// Save Booking test
        /// </summary>
        [TestMethod]
        public void SaveBookingTest()
        {
            //Setup
            var booking = new SwiftBooking
            {
                Address = "Perennial Dr",
                Id = 0,
                Name = "test"
            };
            bookingRepositoryMock.Setup(br => br.Add(booking));
            bookingRepositoryMock.Setup(br => br.SaveChanges());

            //Act
            var results = testSubject.SaveBooking(booking);

            //Assert
            bookingRepositoryMock.VerifyAll();
            swiftRestClientMock.VerifyAll();
            Assert.AreEqual(results.Name, booking.Name);
            Assert.AreEqual(results.Address, booking.Address);
        }

        //Service integration test remainings
    }
}
