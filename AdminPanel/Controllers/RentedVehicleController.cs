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
    public class RentedVehicleController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: RentedVehicle
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.rented_vehicles.ToList());
        }

        // GET: RentedVehicle/Details/5
        [AdminAuthorize]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rented_vehicles rented_vehicles = db.rented_vehicles.Find(id);
            if (rented_vehicles == null)
            {
                return HttpNotFound();
            }
            return View(rented_vehicles);
        }

        // GET: RentedVehicle/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: RentedVehicle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "vehicle,plate,player_name,base_price,rent_price,owner")] rented_vehicles rented_vehicles)
        {
            if (ModelState.IsValid)
            {
                db.rented_vehicles.Add(rented_vehicles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rented_vehicles);
        }

        // GET: RentedVehicle/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rented_vehicles rented_vehicles = db.rented_vehicles.Find(id);
            if (rented_vehicles == null)
            {
                return HttpNotFound();
            }
            return View(rented_vehicles);
        }

        // POST: RentedVehicle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "vehicle,plate,player_name,base_price,rent_price,owner")] rented_vehicles rented_vehicles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rented_vehicles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rented_vehicles);
        }

        // GET: RentedVehicle/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            rented_vehicles rented_vehicles = db.rented_vehicles.Find(id);
            if (rented_vehicles == null)
            {
                return HttpNotFound();
            }
            return View(rented_vehicles);
        }

        // POST: RentedVehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(string id)
        {
            rented_vehicles rented_vehicles = db.rented_vehicles.Find(id);
            db.rented_vehicles.Remove(rented_vehicles);
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
