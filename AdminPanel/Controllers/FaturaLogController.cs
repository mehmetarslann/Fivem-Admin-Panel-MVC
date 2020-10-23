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
    public class FaturaLogController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: FaturaLog
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.faturalog.ToList());
        }

        // GET: FaturaLog/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            faturalog faturalog = db.faturalog.Find(id);
            if (faturalog == null)
            {
                return HttpNotFound();
            }
            return View(faturalog);
        }

        // GET: FaturaLog/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: FaturaLog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,Sender1,Sender,Sender2,Type,Amount,Reciever,Time")] faturalog faturalog)
        {
            if (ModelState.IsValid)
            {
                db.faturalog.Add(faturalog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(faturalog);
        }

        // GET: FaturaLog/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            faturalog faturalog = db.faturalog.Find(id);
            if (faturalog == null)
            {
                return HttpNotFound();
            }
            return View(faturalog);
        }

        // POST: FaturaLog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,Sender1,Sender,Sender2,Type,Amount,Reciever,Time")] faturalog faturalog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faturalog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faturalog);
        }

        // GET: FaturaLog/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            faturalog faturalog = db.faturalog.Find(id);
            if (faturalog == null)
            {
                return HttpNotFound();
            }
            return View(faturalog);
        }

        // POST: FaturaLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            faturalog faturalog = db.faturalog.Find(id);
            db.faturalog.Remove(faturalog);
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
