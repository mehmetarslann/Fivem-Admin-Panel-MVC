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
    public class DiscPropertyInventoryController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: DiscPropertyInventory
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.disc_property_inventory.ToList());
        }

        // GET: DiscPropertyInventory/Details/5
        [AdminAuthorize]
        public ActionResult Details(decimal? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            disc_property_inventory disc_property_inventory = db.disc_property_inventory.Find(id);
            if (disc_property_inventory == null)
            {
                return HttpNotFound();
            }
            return View(disc_property_inventory);
        }

        // GET: DiscPropertyInventory/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiscPropertyInventory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,inventory_name,data")] disc_property_inventory disc_property_inventory)
        {
            if (ModelState.IsValid)
            {
                db.disc_property_inventory.Add(disc_property_inventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(disc_property_inventory);
        }

        // GET: DiscPropertyInventory/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(decimal? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            disc_property_inventory disc_property_inventory = db.disc_property_inventory.Find(id);
            if (disc_property_inventory == null)
            {
                return HttpNotFound();
            }
            return View(disc_property_inventory);
        }

        // POST: DiscPropertyInventory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,inventory_name,data")] disc_property_inventory disc_property_inventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disc_property_inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(disc_property_inventory);
        }

        // GET: DiscPropertyInventory/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(decimal? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            disc_property_inventory disc_property_inventory = db.disc_property_inventory.Find(id);
            if (disc_property_inventory == null)
            {
                return HttpNotFound();
            }
            return View(disc_property_inventory);
        }

        // POST: DiscPropertyInventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(decimal id)
        {
            disc_property_inventory disc_property_inventory = db.disc_property_inventory.Find(id);
            db.disc_property_inventory.Remove(disc_property_inventory);
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
