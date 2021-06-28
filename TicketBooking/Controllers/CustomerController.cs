using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketBooking.DAL;
using TicketBooking.Models;

namespace TicketBooking.Controllers
{
    public class CustomerController : Controller
    {
        private BookingContext db = new BookingContext();
        // GET: Customer
        public ActionResult Index()
        {
            var list = db.Customers.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            Customer cus = new Customer();
            return View(cus);
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
            return RedirectToAction("Create");
        }
    }
}