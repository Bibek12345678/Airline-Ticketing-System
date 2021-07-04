using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TicketBooking.DAL;
using TicketBooking.Models;

namespace TicketBooking.Controllers
{
    public class CustomerController : Controller
    {
        private BookingContext db = new BookingContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            Customer cus = new Customer();
            return View(cus);
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "CustomerId,CustomerName,Salary,DepartName")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
            return RedirectToAction("Create");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ViewBag.InitialData = serializer.Serialize(customer);
            return View(customer);
        }
        [HttpPost]
        public ActionResult Edit ([Bind(Include = "CustomerId,CustomerName,Salary,DepartName")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            return View(customer);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ViewBag.InitialData = serializer.Serialize(customer);
            return View(customer);
        }
    
       [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            Customer customerdetail = db.Customers.Find(customer.CustomerId);
            db.Customers.Remove(customerdetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public JsonResult FetchCustomer()
        {
            return Json(db.Customers.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}
