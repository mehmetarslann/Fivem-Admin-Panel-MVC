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
    public class CarParkingController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: CarParking
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.car_parking.ToList());
        }

        // GET: CarParking/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            car_parking car_parking = db.car_parking.Find(id);
            if (car_parking == null)
            {
                return HttpNotFound();
            }
            return View(car_parking);
        }

        // GET: CarParking/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarParking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,owner,plate,data,time,parking")] car_parking car_parking)
        {
            if (ModelState.IsValid)
            {
                db.car_parking.Add(car_parking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car_parking);
        }

        // GET: CarParking/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            car_parking car_parking = db.car_parking.Find(id);
            if (car_parking == null)
            {
                return HttpNotFound();
            }
            return View(car_parking);
        }

        // POST: CarParking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,owner,plate,data,time,parking")] car_parking car_parking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car_parking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car_parking);
        }

        // GET: CarParking/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            car_parking car_parking = db.car_parking.Find(id);
            if (car_parking == null)
            {
                return HttpNotFound();
            }
            return View(car_parking);
        }

        // POST: CarParking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            car_parking car_parking = db.car_parking.Find(id);
            db.car_parking.Remove(car_parking);
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
