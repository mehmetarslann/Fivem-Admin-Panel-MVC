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
    public class MdtReportController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: MdtReport
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.mdt_reports.ToList());
        }

        // GET: MdtReport/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mdt_reports mdt_reports = db.mdt_reports.Find(id);
            if (mdt_reports == null)
            {
                return HttpNotFound();
            }
            return View(mdt_reports);
        }

        // GET: MdtReport/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: MdtReport/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,char_id,title,incident,charges,author,name,date,jailtime")] mdt_reports mdt_reports)
        {
            if (ModelState.IsValid)
            {
                db.mdt_reports.Add(mdt_reports);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mdt_reports);
        }

        // GET: MdtReport/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mdt_reports mdt_reports = db.mdt_reports.Find(id);
            if (mdt_reports == null)
            {
                return HttpNotFound();
            }
            return View(mdt_reports);
        }

        // POST: MdtReport/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,char_id,title,incident,charges,author,name,date,jailtime")] mdt_reports mdt_reports)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mdt_reports).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mdt_reports);
        }

        // GET: MdtReport/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mdt_reports mdt_reports = db.mdt_reports.Find(id);
            if (mdt_reports == null)
            {
                return HttpNotFound();
            }
            return View(mdt_reports);
        }

        // POST: MdtReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            mdt_reports mdt_reports = db.mdt_reports.Find(id);
            db.mdt_reports.Remove(mdt_reports);
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
