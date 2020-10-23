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
    public class VehicleSoldController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: VehicleSold
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.vehicle_sold.ToList());
        }

        // GET: VehicleSold/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicle_sold vehicle_sold = db.vehicle_sold.Find(id);
            if (vehicle_sold == null)
            {
                return HttpNotFound();
            }
            return View(vehicle_sold);
        }

        // GET: VehicleSold/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleSold/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,client,model,plate,soldby,date")] vehicle_sold vehicle_sold)
        {
            if (ModelState.IsValid)
            {
                db.vehicle_sold.Add(vehicle_sold);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicle_sold);
        }

        // GET: VehicleSold/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicle_sold vehicle_sold = db.vehicle_sold.Find(id);
            if (vehicle_sold == null)
            {
                return HttpNotFound();
            }
            return View(vehicle_sold);
        }

        // POST: VehicleSold/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,client,model,plate,soldby,date")] vehicle_sold vehicle_sold)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle_sold).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle_sold);
        }

        // GET: VehicleSold/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehicle_sold vehicle_sold = db.vehicle_sold.Find(id);
            if (vehicle_sold == null)
            {
                return HttpNotFound();
            }
            return View(vehicle_sold);
        }

        // POST: VehicleSold/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            vehicle_sold vehicle_sold = db.vehicle_sold.Find(id);
            db.vehicle_sold.Remove(vehicle_sold);
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
