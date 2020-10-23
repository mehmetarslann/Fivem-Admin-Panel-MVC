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
    public class Cete2KasaController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: Cete2Kasa
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.cete2kasa.ToList());
        }

        // GET: Cete2Kasa/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cete2kasa cete2kasa = db.cete2kasa.Find(id);
            if (cete2kasa == null)
            {
                return HttpNotFound();
            }
            return View(cete2kasa);
        }

        // GET: Cete2Kasa/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cete2Kasa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,Sender1,Sender,Sender2,Amount,Type,Reciever,Time")] cete2kasa cete2kasa)
        {
            if (ModelState.IsValid)
            {
                db.cete2kasa.Add(cete2kasa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cete2kasa);
        }

        // GET: Cete2Kasa/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cete2kasa cete2kasa = db.cete2kasa.Find(id);
            if (cete2kasa == null)
            {
                return HttpNotFound();
            }
            return View(cete2kasa);
        }

        // POST: Cete2Kasa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,Sender1,Sender,Sender2,Amount,Type,Reciever,Time")] cete2kasa cete2kasa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cete2kasa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cete2kasa);
        }

        // GET: Cete2Kasa/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cete2kasa cete2kasa = db.cete2kasa.Find(id);
            if (cete2kasa == null)
            {
                return HttpNotFound();
            }
            return View(cete2kasa);
        }

        // POST: Cete2Kasa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            cete2kasa cete2kasa = db.cete2kasa.Find(id);
            db.cete2kasa.Remove(cete2kasa);
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
