using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwiftBookingTest.Web.Models
{
    public class SwiftBooking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PickupAddress { get; set; }
        public string Phone { get; set; }
    }
}