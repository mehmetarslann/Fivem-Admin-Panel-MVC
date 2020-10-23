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
    public class MdtWarrantController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: MdtWarrant
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.mdt_warrants.ToList());
        }

        // GET: MdtWarrant/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mdt_warrants mdt_warrants = db.mdt_warrants.Find(id);
            if (mdt_warrants == null)
            {
                return HttpNotFound();
            }
            return View(mdt_warrants);
        }

        // GET: MdtWarrant/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: MdtWarrant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,name,char_id,report_id,report_title,charges,date,expire,notes,author")] mdt_warrants mdt_warrants)
        {
            if (ModelState.IsValid)
            {
                db.mdt_warrants.Add(mdt_warrants);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mdt_warrants);
        }

        // GET: MdtWarrant/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mdt_warrants mdt_warrants = db.mdt_warrants.Find(id);
            if (mdt_warrants == null)
            {
                return HttpNotFound();
            }
            return View(mdt_warrants);
        }

        // POST: MdtWarrant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,name,char_id,report_id,report_title,charges,date,expire,notes,author")] mdt_warrants mdt_warrants)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mdt_warrants).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mdt_warrants);
        }

        // GET: MdtWarrant/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mdt_warrants mdt_warrants = db.mdt_warrants.Find(id);
            if (mdt_warrants == null)
            {
                return HttpNotFound();
            }
            return View(mdt_warrants);
        }

        // POST: MdtWarrant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            mdt_warrants mdt_warrants = db.mdt_warrants.Find(id);
            db.mdt_warrants.Remove(mdt_warrants);
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
