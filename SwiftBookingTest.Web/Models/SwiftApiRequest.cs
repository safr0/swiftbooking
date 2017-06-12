using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SwiftBookingTest.Web.Models
{
    public class SwiftApiRequest
    {
        public string apiKey { get; set; }
        public Booking booking { get; set; }
    }
    public class Booking
    {
        public Address pickupDetail { get; set; }
        public Address dropoffDetail { get; set; }
    }
    public class Address
    {
        public string address { get; set; }
    }

    /// <summary>
    /// Mapper class for creating Api request from booking
    /// </summary>
    public static class ApiRequestMapper
    {
        public static SwiftApiRequest MapToApi(this SwiftBooking booking)
        {
            return new SwiftApiRequest
            {
                apiKey = ConfigurationManager.AppSettings["SwiftApiKey"],
                booking = new Booking
                {
                    dropoffDetail = new Address { address = booking.Address },
                    pickupDetail = new Address { address = booking.PickupAddress },
                }
            };
        }
    }
}