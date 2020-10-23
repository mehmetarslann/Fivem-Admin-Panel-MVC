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
    public class DiscPropertyController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: DiscProperty
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.disc_property.ToList());
        }

        // GET: DiscProperty/Details/5
        [AdminAuthorize]
        public ActionResult Details(decimal? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            disc_property disc_property = db.disc_property.Find(id);
            if (disc_property == null)
            {
                return HttpNotFound();
            }
            return View(disc_property);
        }

        // GET: DiscProperty/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiscProperty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,name,sold,price,locked")] disc_property disc_property)
        {
            if (ModelState.IsValid)
            {
                db.disc_property.Add(disc_property);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(disc_property);
        }

        // GET: DiscProperty/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(decimal? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            disc_property disc_property = db.disc_property.Find(id);
            if (disc_property == null)
            {
                return HttpNotFound();
            }
            return View(disc_property);
        }

        // POST: DiscProperty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,name,sold,price,locked")] disc_property disc_property)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disc_property).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(disc_property);
        }

        // GET: DiscProperty/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(decimal? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            disc_property disc_property = db.disc_property.Find(id);
            if (disc_property == null)
            {
                return HttpNotFound();
            }
            return View(disc_property);
        }

        // POST: DiscProperty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(decimal id)
        {
            disc_property disc_property = db.disc_property.Find(id);
            db.disc_property.Remove(disc_property);
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
