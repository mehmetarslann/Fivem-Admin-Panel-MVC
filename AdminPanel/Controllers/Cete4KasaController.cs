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
    public class Cete4KasaController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: Cete4Kasa
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.cete4kasa.ToList());
        }

        // GET: Cete4Kasa/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cete4kasa cete4kasa = db.cete4kasa.Find(id);
            if (cete4kasa == null)
            {
                return HttpNotFound();
            }
            return View(cete4kasa);
        }

        // GET: Cete4Kasa/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cete4Kasa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,Sender1,Sender,Sender2,Type,Amount,Reciever,Time")] cete4kasa cete4kasa)
        {
            if (ModelState.IsValid)
            {
                db.cete4kasa.Add(cete4kasa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cete4kasa);
        }

        // GET: Cete4Kasa/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cete4kasa cete4kasa = db.cete4kasa.Find(id);
            if (cete4kasa == null)
            {
                return HttpNotFound();
            }
            return View(cete4kasa);
        }

        // POST: Cete4Kasa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,Sender1,Sender,Sender2,Type,Amount,Reciever,Time")] cete4kasa cete4kasa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cete4kasa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cete4kasa);
        }

        // GET: Cete4Kasa/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cete4kasa cete4kasa = db.cete4kasa.Find(id);
            if (cete4kasa == null)
            {
                return HttpNotFound();
            }
            return View(cete4kasa);
        }

        // POST: Cete4Kasa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            cete4kasa cete4kasa = db.cete4kasa.Find(id);
            db.cete4kasa.Remove(cete4kasa);
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
