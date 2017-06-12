using SwiftBookingTest.Web.Models;
using SwiftBookingTest.Web.Services;
using SwiftBookingTest.Web.Utils;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace SwiftBookingTest.Web.Controllers
{
    /// <summary>
    /// Swift Delivery Controller
    /// </summary>
    [RoutePrefix("api/swiftcontroller")]
    public class SwiftDeliveryController : ApiController
    {
        private readonly IBookingService bookingService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bookingService"></param>
        public SwiftDeliveryController(IBookingService bookingService)
        {
            if (bookingService == null)
            {
                throw new ArgumentNullException("bookingService");
            }
            this.bookingService = bookingService;
        }
        /// <summary>
        /// Get lists of booking
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [Route("getBookings")]
        public ActionResult Get()
        {
            if (ModelState.IsValid)
            {                
                return new CustomActionResult(bookingService.GetBookings(), JsonRequestBehavior.AllowGet); 
            }
            throw new InvalidOperationException("reqest invalid");
        }

        /// <summary>
        /// Save Booking to database
        /// </summary>
        [System.Web.Http.HttpPost]
        [Route("saveBooking")]
        public SwiftBooking SaveBooking(SwiftBooking request)
        {
            if (ModelState.IsValid)
            {
                return bookingService.SaveBooking(request);
            }
            throw new InvalidOperationException("reqest invalid");
        }

        /// <summary>
        /// Deliver booking
        /// </summary>
        [System.Web.Http.HttpPost]
        [Route("deliver")]
        public string Deliver(SwiftBooking request)
        {
            if (ModelState.IsValid)
            {
                return bookingService.Deliver(request);                    
            }
            throw new InvalidOperationException("reqest invalid");
        }
    }
}
