using SwiftBookingTest.Web.Models;
using System.Collections.Generic;

namespace SwiftBookingTest.Web.Services
{
    /// <summary>
    /// Interface for Booking Service
    /// <seealso cref="BookingService"/>
    /// </summary>
    public interface IBookingService
    {
        /// <summary>
        /// Save booking to the database
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        SwiftBooking SaveBooking(SwiftBooking booking);
        /// <summary>
        /// Get all bookings
        /// </summary>
        IList<SwiftBooking> GetBookings();

        /// <summary>
        /// Deliver booking
        /// </summary>        
        string Deliver(SwiftBooking booking);
    }

}
