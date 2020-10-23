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
    public class HastaneController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: Hastane
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.hastane.ToList());
        }

        // GET: Hastane/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hastane hastane = db.hastane.Find(id);
            if (hastane == null)
            {
                return HttpNotFound();
            }
            return View(hastane);
        }

        // GET: Hastane/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hastane/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,Sender,Type,Amount,Reciever,Time")] hastane hastane)
        {
            if (ModelState.IsValid)
            {
                db.hastane.Add(hastane);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hastane);
        }

        // GET: Hastane/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hastane hastane = db.hastane.Find(id);
            if (hastane == null)
            {
                return HttpNotFound();
            }
            return View(hastane);
        }

        // POST: Hastane/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,Sender,Type,Amount,Reciever,Time")] hastane hastane)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hastane).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hastane);
        }

        // GET: Hastane/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hastane hastane = db.hastane.Find(id);
            if (hastane == null)
            {
                return HttpNotFound();
            }
            return View(hastane);
        }

        // POST: Hastane/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            hastane hastane = db.hastane.Find(id);
            db.hastane.Remove(hastane);
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
