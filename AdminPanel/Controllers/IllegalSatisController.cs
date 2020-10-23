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
    public class IllegalSatisController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: IllegalSatis
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.illegalsatis.ToList());
        }

        // GET: IllegalSatis/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            illegalsatis illegalsatis = db.illegalsatis.Find(id);
            if (illegalsatis == null)
            {
                return HttpNotFound();
            }
            return View(illegalsatis);
        }

        // GET: IllegalSatis/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: IllegalSatis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,Sender,Type,Amount,Reciever,Time")] illegalsatis illegalsatis)
        {
            if (ModelState.IsValid)
            {
                db.illegalsatis.Add(illegalsatis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(illegalsatis);
        }

        // GET: IllegalSatis/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            illegalsatis illegalsatis = db.illegalsatis.Find(id);
            if (illegalsatis == null)
            {
                return HttpNotFound();
            }
            return View(illegalsatis);
        }

        // POST: IllegalSatis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,Sender,Type,Amount,Reciever,Time")] illegalsatis illegalsatis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(illegalsatis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(illegalsatis);
        }

        // GET: IllegalSatis/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            illegalsatis illegalsatis = db.illegalsatis.Find(id);
            if (illegalsatis == null)
            {
                return HttpNotFound();
            }
            return View(illegalsatis);
        }

        // POST: IllegalSatis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            illegalsatis illegalsatis = db.illegalsatis.Find(id);
            db.illegalsatis.Remove(illegalsatis);
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
