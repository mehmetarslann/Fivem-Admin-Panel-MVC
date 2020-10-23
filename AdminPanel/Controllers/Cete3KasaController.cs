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
    public class Cete3KasaController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: Cete3Kasa
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.cete3kasa.ToList());
        }

        // GET: Cete3Kasa/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cete3kasa cete3kasa = db.cete3kasa.Find(id);
            if (cete3kasa == null)
            {
                return HttpNotFound();
            }
            return View(cete3kasa);
        }

        // GET: Cete3Kasa/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cete3Kasa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,Sender1,Sender,Sender2,Type,Amount,Reciever,Time")] cete3kasa cete3kasa)
        {
            if (ModelState.IsValid)
            {
                db.cete3kasa.Add(cete3kasa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cete3kasa);
        }

        // GET: Cete3Kasa/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cete3kasa cete3kasa = db.cete3kasa.Find(id);
            if (cete3kasa == null)
            {
                return HttpNotFound();
            }
            return View(cete3kasa);
        }

        // POST: Cete3Kasa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,Sender1,Sender,Sender2,Type,Amount,Reciever,Time")] cete3kasa cete3kasa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cete3kasa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cete3kasa);
        }

        // GET: Cete3Kasa/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cete3kasa cete3kasa = db.cete3kasa.Find(id);
            if (cete3kasa == null)
            {
                return HttpNotFound();
            }
            return View(cete3kasa);
        }

        // POST: Cete3Kasa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            cete3kasa cete3kasa = db.cete3kasa.Find(id);
            db.cete3kasa.Remove(cete3kasa);
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
