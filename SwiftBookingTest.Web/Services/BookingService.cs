using System;
using System.Linq;
using SwiftBookingTest.Web.Models;
using SwiftBookingTest.Web.Repository;
using SwiftBookingTest.Web.RestClient;
using RestSharp;
using System.Configuration;
using System.IO;
using System.Collections.Generic;

namespace SwiftBookingTest.Web.Services
{
    /// <summary>
    /// Booking Service class
    /// </summary>
    public sealed class BookingService : IBookingService
    {
        private readonly ISwiftRestClient restClient;
        private readonly ISwiftBookingRepository bookingRepository;
        private readonly string ApiHostname = ConfigurationManager.AppSettings["SwiftApiHostname"];
        private readonly string ApiEndpoint = ConfigurationManager.AppSettings["SwiftApiDeliveriesEndpoint"];
        /// <summary>
        /// Constructor
        /// </summary>
        public BookingService(ISwiftRestClient restClient, ISwiftBookingRepository bookingRepository)
        {
            if (restClient == null)
            {
                throw new ArgumentNullException("restClient");
            }
            if(bookingRepository == null)
            {
                throw new ArgumentNullException("bookingRepository");
            }
            this.restClient = restClient;
            this.bookingRepository = bookingRepository;
        }

        public string Deliver(SwiftBooking booking)
        {
            RestRequest restRequest = new RestRequest { Method = Method.POST, RequestFormat = DataFormat.Json };          
            restRequest.AddBody(booking.MapToApi());
            return restClient.Execute(Path.Combine(ApiHostname, ApiEndpoint), restRequest).Content;            
        }

        /// <summary>
        /// Get all bookings from database
        /// </summary>
        /// <returns></returns>
        public IList<SwiftBooking> GetBookings()
        {            
            return bookingRepository.GetAll().ToList();            
        }

        /// <summary>
        /// Save Booking to the database
        /// </summary>
        public SwiftBooking SaveBooking(SwiftBooking booking)
        {
            bookingRepository.Add(booking);
            bookingRepository.SaveChanges();               
            
            return booking;
        }
    }
   

}