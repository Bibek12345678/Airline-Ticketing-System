using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketBooking.DAL;
using TicketBooking.Models;

namespace TicketBooking.Controllers
{
    public class ResumeController : Controller
    {
        private BookingContext db = new BookingContext();
        // GET: Resume
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Applications.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            Application application = new Application();
            application.Experiences.Add(new Experience() { ExperienceId = 1 });
            ViewBag.Gender = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Male",Value = "Male"},
                new SelectListItem(){Text="Female",Value="Female"}
            };
           // application.Experiences.Add(new Experience() { ExperienceId = 2 });
            return View(application);
        }
        [HttpPost]
        public ActionResult Create(Application application)
        {
            if (ModelState.IsValid)
            {
                db.Applications.Add(application);
                db.SaveChanges();

            }
            return RedirectToAction("Index");
            
        }
             [HttpGet]
        public ActionResult Details(int Id)
        {
            Application application = db.Applications.Include(e=>e.Experiences).Where(a => a.Id == Id).FirstOrDefault();
            return View(application);

        }
        [HttpGet]
        public ActionResult Delete(int? Id)
        {
            Application application = db.Applications.Include(e => e.Experiences).Where(a => a.Id == Id).FirstOrDefault();
            return View(application);
        }

        [HttpPost]
           public ActionResult Delete(int id)
        {
            Application application = db.Applications.Find(id);
            db.Applications.Remove(application);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
