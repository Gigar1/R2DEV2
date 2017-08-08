using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using R2DEV2.Models;
using R2DEV2.Models.Classes;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

/*tEst */
namespace R2DEV2.Controllers
{
    public class CourseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public object UserUtils { get; private set; }

        // GET: Course
        [Authorize]
        public ActionResult Index()
        {
            //var currentUser = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            return View(db.CourseClasses.ToList());
        }

        // GET: Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseClass courseClass = db.CourseClasses.Find(id);
            if (courseClass == null)
            {
                return HttpNotFound();
            }
            return View(courseClass);
        }

        //Student
        public ActionResult CourseToggle(int id)
        {
            CourseClass CurrentClass = db.CourseClasses.Where(g => g.Id == id).FirstOrDefault();
            ApplicationUser CurrentUser = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            
            //Remove Student
            if (CurrentClass.AttendingStudents.Contains(CurrentUser))
            {
                CurrentClass.AttendingStudents.Remove(CurrentUser);
                db.SaveChanges();
            }//Add Student
            else
            {
                CurrentClass.AttendingStudents.Add(CurrentUser);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: Course/Create
        [Authorize(Roles = "Teacher")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public ActionResult Create([Bind(Include = "Id,Name,Description,StartTime,EndTime")] CourseClass courseClass)
        {
            if (ModelState.IsValid)
            {
                db.CourseClasses.Add(courseClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseClass);
        }

        // GET: Course/Edit/5
        [Authorize(Roles = "Teacher")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseClass courseClass = db.CourseClasses.Find(id);
            if (courseClass == null)
            {
                return HttpNotFound();
            }
            return View(courseClass);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,StartTime,EndTime")] CourseClass courseClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseClass);
        }

        // GET: Course/Delete/5
        [Authorize(Roles = "Teacher")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseClass courseClass = db.CourseClasses.Find(id);
            if (courseClass == null)
            {
                return HttpNotFound();
            }
            return View(courseClass);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Teacher")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseClass courseClass = db.CourseClasses.Find(id);
            db.CourseClasses.Remove(courseClass);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
