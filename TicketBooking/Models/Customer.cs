using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicketBooking.Models
{
    public class Customer
    {
        [Key]
        public int CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public int Salary { get; set; }
        public string DepartName { get; set; }


    }
}