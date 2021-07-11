using System;
using System.ComponentModel.DataAnnotations;

namespace TicketBooking.Models
{
    public class OrderMaster
    {
        [Key]
        public int OrderId { get; set; }
        public string  OrderNo { get; set; }
        //[Required(ErrorMessage = "Start date and time cannot be empty")]
        //validate:Must be greater than current date
        //[DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }
        public string Description { get; set; }


    }
}