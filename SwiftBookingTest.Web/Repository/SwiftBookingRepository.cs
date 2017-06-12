using StructureMap;
using SwiftBookingTest.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SwiftBookingTest.Web.Repository
{
    public interface ISwiftBookingRepository : IBaseRepository<SwiftBooking, int>
    {

    }
    public class SwiftBookingRepository : BaseRepository<SwiftBooking>, ISwiftBookingRepository
    {
        public SwiftBookingRepository(IContainer container)
            : base(container)
        {
        }
        protected override IDbSet<SwiftBooking> DbSet
        {
            get
            {
                return db.Bookings;
            }
        }
    }
}