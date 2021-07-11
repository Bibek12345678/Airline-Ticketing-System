using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketBooking.DAL;
using TicketBooking.Models;

namespace TicketBooking.Controllers
{
    public class CategoryController : Controller
    {
        private BookingContext db = new BookingContext();
        // GET: Category
        public ActionResult Index()
        {
            return View(db.Categorys.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            Category category = new Category();
            return View(category);
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categorys.Add(category);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}