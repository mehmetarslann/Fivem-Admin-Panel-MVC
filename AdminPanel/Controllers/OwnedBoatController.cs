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
    public class OwnedBoatController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: OwnedBoat

        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.owned_boats.ToList());
        }

        // GET: OwnedBoat/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            owned_boats owned_boats = db.owned_boats.Find(id);
            if (owned_boats == null)
            {
                return HttpNotFound();
            }
            return View(owned_boats);
        }

        // GET: OwnedBoat/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: OwnedBoat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,owner,state,plate,vehicle")] owned_boats owned_boats)
        {
            if (ModelState.IsValid)
            {
                db.owned_boats.Add(owned_boats);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(owned_boats);
        }

        // GET: OwnedBoat/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            owned_boats owned_boats = db.owned_boats.Find(id);
            if (owned_boats == null)
            {
                return HttpNotFound();
            }
            return View(owned_boats);
        }

        // POST: OwnedBoat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,owner,state,plate,vehicle")] owned_boats owned_boats)
        {
            if (ModelState.IsValid)
            {
                db.Entry(owned_boats).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(owned_boats);
        }

        // GET: OwnedBoat/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            owned_boats owned_boats = db.owned_boats.Find(id);
            if (owned_boats == null)
            {
                return HttpNotFound();
            }
            return View(owned_boats);
        }

        // POST: OwnedBoat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            owned_boats owned_boats = db.owned_boats.Find(id);
            db.owned_boats.Remove(owned_boats);
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
