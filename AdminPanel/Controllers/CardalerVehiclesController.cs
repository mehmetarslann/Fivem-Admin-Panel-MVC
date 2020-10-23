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
    public class CardalerVehiclesController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: CardalerVehicles
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.cardealer_vehicles.ToList());
        }

        // GET: CardalerVehicles/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cardealer_vehicles cardealer_vehicles = db.cardealer_vehicles.Find(id);
            if (cardealer_vehicles == null)
            {
                return HttpNotFound();
            }
            return View(cardealer_vehicles);
        }

        // GET: CardalerVehicles/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CardalerVehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,vehicle,price")] cardealer_vehicles cardealer_vehicles)
        {
            if (ModelState.IsValid)
            {
                db.cardealer_vehicles.Add(cardealer_vehicles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cardealer_vehicles);
        }

        // GET: CardalerVehicles/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cardealer_vehicles cardealer_vehicles = db.cardealer_vehicles.Find(id);
            if (cardealer_vehicles == null)
            {
                return HttpNotFound();
            }
            return View(cardealer_vehicles);
        }

        // POST: CardalerVehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,vehicle,price")] cardealer_vehicles cardealer_vehicles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cardealer_vehicles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cardealer_vehicles);
        }

        // GET: CardalerVehicles/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cardealer_vehicles cardealer_vehicles = db.cardealer_vehicles.Find(id);
            if (cardealer_vehicles == null)
            {
                return HttpNotFound();
            }
            return View(cardealer_vehicles);
        }

        // POST: CardalerVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            cardealer_vehicles cardealer_vehicles = db.cardealer_vehicles.Find(id);
            db.cardealer_vehicles.Remove(cardealer_vehicles);
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
