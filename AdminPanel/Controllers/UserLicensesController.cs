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
    public class UserLicensesController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: UserLicenses
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.user_licenses.ToList());
        }

        // GET: UserLicenses/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_licenses user_licenses = db.user_licenses.Find(id);
            if (user_licenses == null)
            {
                return HttpNotFound();
            }
            return View(user_licenses);
        }

        // GET: UserLicenses/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserLicenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,type,owner")] user_licenses user_licenses)
        {
            if (ModelState.IsValid)
            {
                db.user_licenses.Add(user_licenses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_licenses);
        }

        // GET: UserLicenses/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_licenses user_licenses = db.user_licenses.Find(id);
            if (user_licenses == null)
            {
                return HttpNotFound();
            }
            return View(user_licenses);
        }

        // POST: UserLicenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,type,owner")] user_licenses user_licenses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_licenses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_licenses);
        }

        // GET: UserLicenses/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_licenses user_licenses = db.user_licenses.Find(id);
            if (user_licenses == null)
            {
                return HttpNotFound();
            }
            return View(user_licenses);
        }

        // POST: UserLicenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            user_licenses user_licenses = db.user_licenses.Find(id);
            db.user_licenses.Remove(user_licenses);
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
