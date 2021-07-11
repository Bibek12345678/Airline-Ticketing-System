using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketBooking.DAL;
using TicketBooking.Models;
using TicketBooking.ViewModel;

namespace TicketBooking.Controllers
{
    public class OrderDetailController : Controller
    {
        private BookingContext db = new BookingContext();
        // GET: OrderDetail
        public ActionResult Index()
        {
            var orderdetails = db.OrderDetails.ToList();
            var result = (from od in db.OrderDetails.ToList()
                          join p in db.Products on od.ProductId equals p.ProductId
                          join c in db.Categorys on od.CategoryId equals c.CategoryId
                          select new OrderDetailViewModel()
                          {
                              CategoryName = c.CategoryName,
                              ProductName = p.ProductName,
                              Rate = od.Rate,
                              Quantity = od.Quantity
                          }).ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Categorys = new SelectList(db.Categorys, "CategoryId", "CategoryName");
            ViewBag.Products = new SelectList(db.Products, "ProductId", "ProductName");
            OrderDetails orderdetail = new OrderDetails();
            return View(orderdetail);
        }
        [HttpPost]
        public ActionResult Create(OrderDetails orderdetails)
        {
            ViewBag.Categorys = new SelectList(db.Categorys, "CategoryId", "CategoryName");
            ViewBag.Products = new SelectList(db.Products, "ProductId", "ProductName");
            if (ModelState.IsValid)
            {
                db.OrderDetails.Add(orderdetails);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}