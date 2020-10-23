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
    public class DiscPropertyOwnersController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: DiscPropertyOwners
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.disc_property_owners.ToList());
        }

        // GET: DiscPropertyOwners/Details/5
        [AdminAuthorize]
        public ActionResult Details(decimal? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            disc_property_owners disc_property_owners = db.disc_property_owners.Find(id);
            if (disc_property_owners == null)
            {
                return HttpNotFound();
            }
            return View(disc_property_owners);
        }

        // GET: DiscPropertyOwners/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiscPropertyOwners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,name,identifier,active,owner")] disc_property_owners disc_property_owners)
        {
            if (ModelState.IsValid)
            {
                db.disc_property_owners.Add(disc_property_owners);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(disc_property_owners);
        }

        // GET: DiscPropertyOwners/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(decimal? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            disc_property_owners disc_property_owners = db.disc_property_owners.Find(id);
            if (disc_property_owners == null)
            {
                return HttpNotFound();
            }
            return View(disc_property_owners);
        }

        // POST: DiscPropertyOwners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,name,identifier,active,owner")] disc_property_owners disc_property_owners)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disc_property_owners).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(disc_property_owners);
        }

        // GET: DiscPropertyOwners/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(decimal? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            disc_property_owners disc_property_owners = db.disc_property_owners.Find(id);
            if (disc_property_owners == null)
            {
                return HttpNotFound();
            }
            return View(disc_property_owners);
        }

        // POST: DiscPropertyOwners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(decimal id)
        {
            disc_property_owners disc_property_owners = db.disc_property_owners.Find(id);
            db.disc_property_owners.Remove(disc_property_owners);
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
