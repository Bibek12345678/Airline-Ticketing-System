using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TicketBooking.Models;

namespace TicketBooking.DAL
{
    public class BookingContext : DbContext
    {
        public BookingContext() : base("BookingContext")
        {

        }
        public DbSet<Location> Locations { get; set; }
        public DbSet<FlightTravel> FlightTravels { get; set; }

        public DbSet<BookingRate> BookingRates { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<OrderMaster> OrderMasters { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Experience> Experiences { get; set; }



    }
     
}