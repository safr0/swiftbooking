using StructureMap;
using SwiftBookingTest.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

namespace SwiftBookingTest.Web.Repository
{
    
    public class SwiftBookingDbContext : DbContext, IDisposable
    {
        // Your context has been configured to use a 'SwiftBookingDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SwiftBookingTest.Web.Repository.SwiftBookingDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SwiftBookingDbContext' 
        // connection string in the application configuration file.
        public SwiftBookingDbContext(string connectionString)
            : base(connectionString)
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<SwiftBooking> Bookings { get; set; }
    }

 
}