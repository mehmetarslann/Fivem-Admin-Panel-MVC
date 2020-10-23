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
    public class VehicleCategoriesController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: VehicleCategories
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.vehicle_categories.ToList());
        }

        // GET: VehicleCategories/Details/5
        [AdminAuthorize]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicle_categories vehicle_categories = db.vehicle_categories.Find(id);
            if (vehicle_categories == null)
            {
                return HttpNotFound();
            }
            return View(vehicle_categories);
        }

        // GET: VehicleCategories/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "name,label")] vehicle_categories vehicle_categories)
        {
            if (ModelState.IsValid)
            {
                db.vehicle_categories.Add(vehicle_categories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicle_categories);
        }

        // GET: VehicleCategories/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicle_categories vehicle_categories = db.vehicle_categories.Find(id);
            if (vehicle_categories == null)
            {
                return HttpNotFound();
            }
            return View(vehicle_categories);
        }

        // POST: VehicleCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "name,label")] vehicle_categories vehicle_categories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle_categories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle_categories);
        }

        // GET: VehicleCategories/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicle_categories vehicle_categories = db.vehicle_categories.Find(id);
            if (vehicle_categories == null)
            {
                return HttpNotFound();
            }
            return View(vehicle_categories);
        }

        // POST: VehicleCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(string id)
        {
            vehicle_categories vehicle_categories = db.vehicle_categories.Find(id);
            db.vehicle_categories.Remove(vehicle_categories);
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
