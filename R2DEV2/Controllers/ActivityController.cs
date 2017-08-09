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

namespace WebApplication23.Controllers
{
    public class ActivityController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ActivityClasses
        public ActionResult Index()
        {
            var activityClasses = db.ActivityClasses.Include(a => a.Module);
            return View(activityClasses.ToList());
        }

        // GET: ActivityClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityClass activityClass = db.ActivityClasses.Find(id);
            if (activityClass == null)
            {
                return HttpNotFound();
            }
            return View(activityClass);
        }

        // GET: ActivityClasses/Create
        public ActionResult Create(int id)
        {
            //ViewBag.ModuleClassId = new SelectList(db.ModuleClasses, "Id", "Name");
            return View();
        }

        // POST: ActivityClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,StartTime,EndTime,ModuleClassId")] ActivityClass activityClass, int id)
        {
            if (ModelState.IsValid)
            {
                activityClass.ModuleClassId = id;
                db.ActivityClasses.Add(activityClass);
                db.SaveChanges();
                var courseId = db.ModuleClasses.Find(activityClass.ModuleClassId).CourseClassId;
                //var courseid = x.CourseClassId;
                return RedirectToAction("Details", "Course", new { id = courseId });
            }

            //ViewBag.ModuleClassId = new SelectList(db.ModuleClasses, "Id", "Name", activityClass.ModuleClassId);
            //ViewBag.ActivityClassId = new SelectList(db.ActivityClasses, "Id", "Name", activityClass.ModuleClassId);
            return View(activityClass);
        }

        // GET: ActivityClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityClass activityClass = db.ActivityClasses.Find(id);

            if (activityClass == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModuleClassId = new SelectList(db.ModuleClasses, "Id", "Name", activityClass.ModuleClassId);
            return View(activityClass);
        }

        // POST: ActivityClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,StartTime,EndTime,ModuleClassId")] ActivityClass activityClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activityClass).State = EntityState.Modified;
                db.SaveChanges();
                var courseId = db.ModuleClasses.Find(activityClass.ModuleClassId).CourseClassId;
                return RedirectToAction("Details", "Course", new { id = courseId });
            }
            ViewBag.ModuleClassId = new SelectList(db.ModuleClasses, "Id", "Name", activityClass.ModuleClassId);
            return View(activityClass);
        }

        // GET: ActivityClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityClass activityClass = db.ActivityClasses.Find(id);
            if (activityClass == null)
            {
                return HttpNotFound();
            }
            return View(activityClass);
        }

        // POST: ActivityClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActivityClass activityClass = db.ActivityClasses.Find(id);
            db.ActivityClasses.Remove(activityClass);
            db.SaveChanges();
            var courseId = db.ModuleClasses.Find(activityClass.ModuleClassId).CourseClassId;
            //var courseid = x.CourseClassId;
            return RedirectToAction("Details", "Course", new { id = courseId });
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
