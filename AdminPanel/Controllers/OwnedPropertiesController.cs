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
    public class OwnedPropertiesController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: OwnedProperties
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.owned_properties.ToList());
        }

        // GET: OwnedProperties/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            owned_properties owned_properties = db.owned_properties.Find(id);
            if (owned_properties == null)
            {
                return HttpNotFound();
            }
            return View(owned_properties);
        }

        // GET: OwnedProperties/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: OwnedProperties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,name,price,rented,owner")] owned_properties owned_properties)
        {
            if (ModelState.IsValid)
            {
                db.owned_properties.Add(owned_properties);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(owned_properties);
        }

        // GET: OwnedProperties/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            owned_properties owned_properties = db.owned_properties.Find(id);
            if (owned_properties == null)
            {
                return HttpNotFound();
            }
            return View(owned_properties);
        }

        // POST: OwnedProperties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,name,price,rented,owner")] owned_properties owned_properties)
        {
            if (ModelState.IsValid)
            {
                db.Entry(owned_properties).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(owned_properties);
        }

        // GET: OwnedProperties/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            owned_properties owned_properties = db.owned_properties.Find(id);
            if (owned_properties == null)
            {
                return HttpNotFound();
            }
            return View(owned_properties);
        }

        // POST: OwnedProperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            owned_properties owned_properties = db.owned_properties.Find(id);
            db.owned_properties.Remove(owned_properties);
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
