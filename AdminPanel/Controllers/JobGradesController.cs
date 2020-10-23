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
    public class JobGradesController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: JobGrades
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.job_grades.ToList());
        }

        // GET: JobGrades/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            job_grades job_grades = db.job_grades.Find(id);
            if (job_grades == null)
            {
                return HttpNotFound();
            }
            return View(job_grades);
        }

        // GET: JobGrades/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobGrades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,job_name,grade,name,label,salary,skin_male,skin_female")] job_grades job_grades)
        {
            if (ModelState.IsValid)
            {
                db.job_grades.Add(job_grades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(job_grades);
        }

        // GET: JobGrades/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            job_grades job_grades = db.job_grades.Find(id);
            if (job_grades == null)
            {
                return HttpNotFound();
            }
            return View(job_grades);
        }

        // POST: JobGrades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,job_name,grade,name,label,salary,skin_male,skin_female")] job_grades job_grades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job_grades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(job_grades);
        }

        // GET: JobGrades/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            job_grades job_grades = db.job_grades.Find(id);
            if (job_grades == null)
            {
                return HttpNotFound();
            }
            return View(job_grades);
        }

        // POST: JobGrades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            job_grades job_grades = db.job_grades.Find(id);
            db.job_grades.Remove(job_grades);
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
