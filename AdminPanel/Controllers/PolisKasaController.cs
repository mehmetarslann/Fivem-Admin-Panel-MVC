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
    public class PolisKasaController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: PolisKasa
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.poliskasa.ToList());
        }

        // GET: PolisKasa/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            poliskasa poliskasa = db.poliskasa.Find(id);
            if (poliskasa == null)
            {
                return HttpNotFound();
            }
            return View(poliskasa);
        }

        // GET: PolisKasa/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PolisKasa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,Sender1,Sender,Sender2,Type,Amount,Reciever,Time")] poliskasa poliskasa)
        {
            if (ModelState.IsValid)
            {
                db.poliskasa.Add(poliskasa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(poliskasa);
        }

        // GET: PolisKasa/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            poliskasa poliskasa = db.poliskasa.Find(id);
            if (poliskasa == null)
            {
                return HttpNotFound();
            }
            return View(poliskasa);
        }

        // POST: PolisKasa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,Sender1,Sender,Sender2,Type,Amount,Reciever,Time")] poliskasa poliskasa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poliskasa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(poliskasa);
        }

        // GET: PolisKasa/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            poliskasa poliskasa = db.poliskasa.Find(id);
            if (poliskasa == null)
            {
                return HttpNotFound();
            }
            return View(poliskasa);
        }

        // POST: PolisKasa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            poliskasa poliskasa = db.poliskasa.Find(id);
            db.poliskasa.Remove(poliskasa);
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
