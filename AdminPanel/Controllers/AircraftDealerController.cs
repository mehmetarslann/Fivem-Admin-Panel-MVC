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
    public class AircraftDealerController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: AircraftDealer
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.aircraftdealer_aircrafts.ToList());
        }

        // GET: AircraftDealer/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aircraftdealer_aircrafts aircraftdealer_aircrafts = db.aircraftdealer_aircrafts.Find(id);
            if (aircraftdealer_aircrafts == null)
            {
                return HttpNotFound();
            }
            return View(aircraftdealer_aircrafts);
        }
        [AdminAuthorize]
        // GET: AircraftDealer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AircraftDealer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,vehicle,price")] aircraftdealer_aircrafts aircraftdealer_aircrafts)
        {
            if (ModelState.IsValid)
            {
                db.aircraftdealer_aircrafts.Add(aircraftdealer_aircrafts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aircraftdealer_aircrafts);
        }

        // GET: AircraftDealer/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aircraftdealer_aircrafts aircraftdealer_aircrafts = db.aircraftdealer_aircrafts.Find(id);
            if (aircraftdealer_aircrafts == null)
            {
                return HttpNotFound();
            }
            return View(aircraftdealer_aircrafts);
        }

        // POST: AircraftDealer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,vehicle,price")] aircraftdealer_aircrafts aircraftdealer_aircrafts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aircraftdealer_aircrafts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aircraftdealer_aircrafts);
        }

        // GET: AircraftDealer/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aircraftdealer_aircrafts aircraftdealer_aircrafts = db.aircraftdealer_aircrafts.Find(id);
            if (aircraftdealer_aircrafts == null)
            {
                return HttpNotFound();
            }
            return View(aircraftdealer_aircrafts);
        }

        // POST: AircraftDealer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            aircraftdealer_aircrafts aircraftdealer_aircrafts = db.aircraftdealer_aircrafts.Find(id);
            db.aircraftdealer_aircrafts.Remove(aircraftdealer_aircrafts);
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
