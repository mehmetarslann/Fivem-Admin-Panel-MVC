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
    public class ElKoymaController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: ElKoyma
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.elkoyma.ToList());
        }

        // GET: ElKoyma/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            elkoyma elkoyma = db.elkoyma.Find(id);
            if (elkoyma == null)
            {
                return HttpNotFound();
            }
            return View(elkoyma);
        }

        // GET: ElKoyma/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ElKoyma/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,Sender,Type,Amount,Reciever,Time")] elkoyma elkoyma)
        {
            if (ModelState.IsValid)
            {
                db.elkoyma.Add(elkoyma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(elkoyma);
        }

        // GET: ElKoyma/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            elkoyma elkoyma = db.elkoyma.Find(id);
            if (elkoyma == null)
            {
                return HttpNotFound();
            }
            return View(elkoyma);
        }

        // POST: ElKoyma/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,Sender,Type,Amount,Reciever,Time")] elkoyma elkoyma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(elkoyma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(elkoyma);
        }

        // GET: ElKoyma/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            elkoyma elkoyma = db.elkoyma.Find(id);
            if (elkoyma == null)
            {
                return HttpNotFound();
            }
            return View(elkoyma);
        }

        // POST: ElKoyma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            elkoyma elkoyma = db.elkoyma.Find(id);
            db.elkoyma.Remove(elkoyma);
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
