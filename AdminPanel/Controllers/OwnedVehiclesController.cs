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
    public class OwnedVehiclesController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: OwnedVehicles
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.owned_vehicles.ToList());
        }

        // GET: OwnedVehicles/Details/5
        [AdminAuthorize]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            owned_vehicles owned_vehicles = db.owned_vehicles.Find(id);
            if (owned_vehicles == null)
            {
                return HttpNotFound();
            }
            return View(owned_vehicles);
        }

        // GET: OwnedVehicles/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: OwnedVehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "owner,plate,vehicle,type,job,stored,state,jamstate,lasthouse")] owned_vehicles owned_vehicles)
        {
            if (ModelState.IsValid)
            {
                db.owned_vehicles.Add(owned_vehicles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(owned_vehicles);
        }

        // GET: OwnedVehicles/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            owned_vehicles owned_vehicles = db.owned_vehicles.Find(id);
            if (owned_vehicles == null)
            {
                return HttpNotFound();
            }
            return View(owned_vehicles);
        }

        // POST: OwnedVehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "owner,plate,vehicle,type,job,stored,state,jamstate,lasthouse")] owned_vehicles owned_vehicles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(owned_vehicles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(owned_vehicles);
        }

        // GET: OwnedVehicles/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            owned_vehicles owned_vehicles = db.owned_vehicles.Find(id);
            if (owned_vehicles == null)
            {
                return HttpNotFound();
            }
            return View(owned_vehicles);
        }

        // POST: OwnedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(string id)
        {
            owned_vehicles owned_vehicles = db.owned_vehicles.Find(id);
            db.owned_vehicles.Remove(owned_vehicles);
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
