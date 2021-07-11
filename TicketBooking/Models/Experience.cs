using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicketBooking.Models
{
    public class Experience
    {
        public Experience()
        {

        }
        [Key]
        public int ExperienceId { get; set; }
        [ForeignKey("Application")]
        public int ApplicationId { get; set; }
        public virtual Application Application { get; private set; }
        public string  CompanyName { get; set; }
        public string Designation { get; set; }
        public int YearsWorked { get; set; }



    }
}