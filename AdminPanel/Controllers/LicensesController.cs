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
    public class LicensesController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: Licenses
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.licenses.ToList());
        }

        // GET: Licenses/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            licenses licenses = db.licenses.Find(id);
            if (licenses == null)
            {
                return HttpNotFound();
            }
            return View(licenses);
        }
        [AdminAuthorize]
        // GET: Licenses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Licenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,type,label")] licenses licenses)
        {
            if (ModelState.IsValid)
            {
                db.licenses.Add(licenses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(licenses);
        }

        // GET: Licenses/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            licenses licenses = db.licenses.Find(id);
            if (licenses == null)
            {
                return HttpNotFound();
            }
            return View(licenses);
        }

        // POST: Licenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,type,label")] licenses licenses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licenses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(licenses);
        }

        // GET: Licenses/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            licenses licenses = db.licenses.Find(id);
            if (licenses == null)
            {
                return HttpNotFound();
            }
            return View(licenses);
        }

        // POST: Licenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            licenses licenses = db.licenses.Find(id);
            db.licenses.Remove(licenses);
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
