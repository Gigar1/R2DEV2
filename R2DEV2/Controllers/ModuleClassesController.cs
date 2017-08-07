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
    public class ModuleClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ModuleClasses
        public ActionResult Index()
        {
            var moduleClasses = db.ModuleClasses.Include(m => m.Course);
            return View(moduleClasses.ToList());
        }

        // GET: ModuleClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleClass moduleClass = db.ModuleClasses.Find(id);
            if (moduleClass == null)
            {
                return HttpNotFound();
            }
            return View(moduleClass);
        }

        // GET: ModuleClasses/Create
        public ActionResult Create()
        {
            ViewBag.CourseClassId = new SelectList(db.CourseClasses, "Id", "Name");
            return View();
        }

        // POST: ModuleClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,StartTime,EndTime,CourseClassId")] ModuleClass moduleClass)
        {
            if (ModelState.IsValid)
            {
                db.ModuleClasses.Add(moduleClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseClassId = new SelectList(db.CourseClasses, "Id", "Name", moduleClass.CourseClassId);
            return View(moduleClass);
        }

        // GET: ModuleClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleClass moduleClass = db.ModuleClasses.Find(id);
            if (moduleClass == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseClassId = new SelectList(db.CourseClasses, "Id", "Name", moduleClass.CourseClassId);
            return View(moduleClass);
        }

        // POST: ModuleClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,StartTime,EndTime,CourseClassId")] ModuleClass moduleClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moduleClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseClassId = new SelectList(db.CourseClasses, "Id", "Name", moduleClass.CourseClassId);
            return View(moduleClass);
        }

        // GET: ModuleClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleClass moduleClass = db.ModuleClasses.Find(id);
            if (moduleClass == null)
            {
                return HttpNotFound();
            }
            return View(moduleClass);
        }

        // POST: ModuleClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModuleClass moduleClass = db.ModuleClasses.Find(id);
            db.ModuleClasses.Remove(moduleClass);
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
