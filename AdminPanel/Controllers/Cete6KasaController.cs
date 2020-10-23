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
    public class Cete6KasaController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: Cete6Kasa
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.cete6kasa.ToList());
        }

        // GET: Cete6Kasa/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cete6kasa cete6kasa = db.cete6kasa.Find(id);
            if (cete6kasa == null)
            {
                return HttpNotFound();
            }
            return View(cete6kasa);
        }

        // GET: Cete6Kasa/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cete6Kasa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,Sender1,Sender,Sender2,Type,Amount,Receiver,Time")] cete6kasa cete6kasa)
        {
            if (ModelState.IsValid)
            {
                db.cete6kasa.Add(cete6kasa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cete6kasa);
        }

        // GET: Cete6Kasa/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cete6kasa cete6kasa = db.cete6kasa.Find(id);
            if (cete6kasa == null)
            {
                return HttpNotFound();
            }
            return View(cete6kasa);
        }

        // POST: Cete6Kasa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,Sender1,Sender,Sender2,Type,Amount,Receiver,Time")] cete6kasa cete6kasa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cete6kasa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cete6kasa);
        }

        // GET: Cete6Kasa/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cete6kasa cete6kasa = db.cete6kasa.Find(id);
            if (cete6kasa == null)
            {
                return HttpNotFound();
            }
            return View(cete6kasa);
        }

        // POST: Cete6Kasa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            cete6kasa cete6kasa = db.cete6kasa.Find(id);
            db.cete6kasa.Remove(cete6kasa);
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
