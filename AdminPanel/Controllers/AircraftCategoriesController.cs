using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminPanel.Kontrol;
using AdminPanel.Models.Entity;

namespace AdminPanel.Controllers
{
    public class AircraftCategoriesController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: AircraftCategories
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.aircraft_categories.ToList());
        }

        // GET: AircraftCategories/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aircraft_categories aircraft_categories = db.aircraft_categories.Find(id);
            if (aircraft_categories == null)
            {
                return HttpNotFound();
            }
            return View(aircraft_categories);
        }

        // GET: AircraftCategories/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AircraftCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,name,label")] aircraft_categories aircraft_categories)
        {
            if (ModelState.IsValid)
            {
                db.aircraft_categories.Add(aircraft_categories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aircraft_categories);
        }

        // GET: AircraftCategories/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aircraft_categories aircraft_categories = db.aircraft_categories.Find(id);
            if (aircraft_categories == null)
            {
                return HttpNotFound();
            }
            return View(aircraft_categories);
        }

        // POST: AircraftCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,name,label")] aircraft_categories aircraft_categories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aircraft_categories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aircraft_categories);
        }

        // GET: AircraftCategories/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aircraft_categories aircraft_categories = db.aircraft_categories.Find(id);
            if (aircraft_categories == null)
            {
                return HttpNotFound();
            }
            return View(aircraft_categories);
        }

        // POST: AircraftCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            aircraft_categories aircraft_categories = db.aircraft_categories.Find(id);
            db.aircraft_categories.Remove(aircraft_categories);
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
