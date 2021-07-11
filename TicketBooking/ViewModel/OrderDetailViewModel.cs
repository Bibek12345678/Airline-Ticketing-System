using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketBooking.ViewModel
{
    public class OrderDetailViewModel
    {
        public int OrderDetailViewModelId { get; set; }
        public int  ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal Rate { get; set; }
        public decimal Quantity { get; set; }


    }
}