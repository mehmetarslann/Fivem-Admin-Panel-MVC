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
    public class HardLogController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: HardLog
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.hardlog.ToList());
        }

        // GET: HardLog/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hardlog hardlog = db.hardlog.Find(id);
            if (hardlog == null)
            {
                return HttpNotFound();
            }
            return View(hardlog);
        }

        // GET: HardLog/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: HardLog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,Sender,Type,Amount,Reciever,Time")] hardlog hardlog)
        {
            if (ModelState.IsValid)
            {
                db.hardlog.Add(hardlog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hardlog);
        }

        // GET: HardLog/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hardlog hardlog = db.hardlog.Find(id);
            if (hardlog == null)
            {
                return HttpNotFound();
            }
            return View(hardlog);
        }

        // POST: HardLog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,Sender,Type,Amount,Reciever,Time")] hardlog hardlog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hardlog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hardlog);
        }

        // GET: HardLog/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hardlog hardlog = db.hardlog.Find(id);
            if (hardlog == null)
            {
                return HttpNotFound();
            }
            return View(hardlog);
        }

        // POST: HardLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            hardlog hardlog = db.hardlog.Find(id);
            db.hardlog.Remove(hardlog);
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
