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
    public class ModuleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Module
        public ActionResult Index()
        {
            return View(db.ModuleControllers.ToList());
        }

        // GET: Module/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module moduleClass = db.ModuleControllers.Find(id);
            if (moduleClass == null)
            {
                return HttpNotFound();
            }
            return View(moduleClass);
        }

        // GET: Module/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Module/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ModuleName,ModuleDescription")] Module moduleClass)
        {
            if (ModelState.IsValid)
            {
                db.ModuleControllers.Add(moduleClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moduleClass);
        }

        // GET: Module/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module moduleClass = db.ModuleControllers.Find(id);
            if (moduleClass == null)
            {
                return HttpNotFound();
            }
            return View(moduleClass);
        }

        // POST: Module/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ModuleName,ModuleDescription")] Module moduleClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moduleClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moduleClass);
        }

        // GET: Module/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module moduleClass = db.ModuleControllers.Find(id);
            if (moduleClass == null)
            {
                return HttpNotFound();
            }
            return View(moduleClass);
        }

        // POST: Module/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Module moduleClass = db.ModuleControllers.Find(id);
            db.ModuleControllers.Remove(moduleClass);
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
