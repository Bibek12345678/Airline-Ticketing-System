using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketBooking.DAL;
using TicketBooking.Models;

namespace TicketBooking.Controllers
{
    public class OrderMasterController : Controller
    {
        private BookingContext db = new BookingContext();
        // GET: OrderMaster
        public ActionResult Index()
        {
            return View(db.OrderMasters.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            OrderMaster ordermaster = new OrderMaster();
            return View(ordermaster);
        }
        [HttpPost]
        public ActionResult Create(OrderMaster ordermaster)
        {
            if (ModelState.IsValid)
            {
                db.OrderMasters.Add(ordermaster);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}