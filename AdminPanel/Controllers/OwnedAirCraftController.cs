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
    public class OwnedAirCraftController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: OwnedAirCraft
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.owned_aircrafts.ToList());
        }

        // GET: OwnedAirCraft/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            owned_aircrafts owned_aircrafts = db.owned_aircrafts.Find(id);
            if (owned_aircrafts == null)
            {
                return HttpNotFound();
            }
            return View(owned_aircrafts);
        }

        // GET: OwnedAirCraft/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: OwnedAirCraft/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,owner,state,plate,vehicle")] owned_aircrafts owned_aircrafts)
        {
            if (ModelState.IsValid)
            {
                db.owned_aircrafts.Add(owned_aircrafts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(owned_aircrafts);
        }

        // GET: OwnedAirCraft/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            owned_aircrafts owned_aircrafts = db.owned_aircrafts.Find(id);
            if (owned_aircrafts == null)
            {
                return HttpNotFound();
            }
            return View(owned_aircrafts);
        }

        // POST: OwnedAirCraft/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,owner,state,plate,vehicle")] owned_aircrafts owned_aircrafts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(owned_aircrafts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(owned_aircrafts);
        }

        // GET: OwnedAirCraft/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            owned_aircrafts owned_aircrafts = db.owned_aircrafts.Find(id);
            if (owned_aircrafts == null)
            {
                return HttpNotFound();
            }
            return View(owned_aircrafts);
        }

        // POST: OwnedAirCraft/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            owned_aircrafts owned_aircrafts = db.owned_aircrafts.Find(id);
            db.owned_aircrafts.Remove(owned_aircrafts);
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
