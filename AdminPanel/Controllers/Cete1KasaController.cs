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
    public class Cete1KasaController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: Cete1Kasa
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.cete1kasa.ToList());
        }

        // GET: Cete1Kasa/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cete1kasa cete1kasa = db.cete1kasa.Find(id);
            if (cete1kasa == null)
            {
                return HttpNotFound();
            }
            return View(cete1kasa);
        }

        // GET: Cete1Kasa/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cete1Kasa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,Sender1,Sender,Sender2,Type,Amount,Reciever,Time")] cete1kasa cete1kasa)
        {
            if (ModelState.IsValid)
            {
                db.cete1kasa.Add(cete1kasa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cete1kasa);
        }

        // GET: Cete1Kasa/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cete1kasa cete1kasa = db.cete1kasa.Find(id);
            if (cete1kasa == null)
            {
                return HttpNotFound();
            }
            return View(cete1kasa);
        }

        // POST: Cete1Kasa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,Sender1,Sender,Sender2,Type,Amount,Reciever,Time")] cete1kasa cete1kasa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cete1kasa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cete1kasa);
        }

        // GET: Cete1Kasa/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cete1kasa cete1kasa = db.cete1kasa.Find(id);
            if (cete1kasa == null)
            {
                return HttpNotFound();
            }
            return View(cete1kasa);
        }

        // POST: Cete1Kasa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            cete1kasa cete1kasa = db.cete1kasa.Find(id);
            db.cete1kasa.Remove(cete1kasa);
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
