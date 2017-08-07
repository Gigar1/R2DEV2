using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using R2DEV2.Models;

namespace R2DEV2.Controllers
{
    public class ActivityController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Activity
        public ActionResult Index()
        {
            return View(db.ActivityClasses.ToList());
        }

        // GET: Activity/Details/5
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

        // GET: Activity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Activity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ActivityName,ActivityDescription,StartTime,Duration")] ActivityClass activityClass)
        {
            if (ModelState.IsValid)
            {
                db.ActivityClasses.Add(activityClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activityClass);
        }

        // GET: Activity/Edit/5
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
            return View(activityClass);
        }

        // POST: Activity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ActivityName,ActivityDescription,StartTime,Duration")] ActivityClass activityClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activityClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activityClass);
        }

        // GET: Activity/Delete/5
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

        // POST: Activity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActivityClass activityClass = db.ActivityClasses.Find(id);
            db.ActivityClasses.Remove(activityClass);
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
