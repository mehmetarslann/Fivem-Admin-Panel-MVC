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
    public class AircraftsController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: Aircrafts
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.aircrafts.ToList());
        }

        // GET: Aircrafts/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aircrafts aircrafts = db.aircrafts.Find(id);
            if (aircrafts == null)
            {
                return HttpNotFound();
            }
            return View(aircrafts);
        }

        // GET: Aircrafts/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aircrafts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,name,model,price,category")] aircrafts aircrafts)
        {
            if (ModelState.IsValid)
            {
                db.aircrafts.Add(aircrafts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aircrafts);
        }

        // GET: Aircrafts/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aircrafts aircrafts = db.aircrafts.Find(id);
            if (aircrafts == null)
            {
                return HttpNotFound();
            }
            return View(aircrafts);
        }

        // POST: Aircrafts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,name,model,price,category")] aircrafts aircrafts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aircrafts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aircrafts);
        }

        // GET: Aircrafts/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aircrafts aircrafts = db.aircrafts.Find(id);
            if (aircrafts == null)
            {
                return HttpNotFound();
            }
            return View(aircrafts);
        }
        [AdminAuthorize]
        // POST: Aircrafts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            aircrafts aircrafts = db.aircrafts.Find(id);
            db.aircrafts.Remove(aircrafts);
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
