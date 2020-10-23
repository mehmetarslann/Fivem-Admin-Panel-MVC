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
    public class AddonInventoryItemsController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: AddonInventoryItems
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.addon_inventory_items.ToList());
        }

        // GET: AddonInventoryItems/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            addon_inventory_items addon_inventory_items = db.addon_inventory_items.Find(id);
            if (addon_inventory_items == null)
            {
                return HttpNotFound();
            }
            return View(addon_inventory_items);
        }

        // GET: AddonInventoryItems/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddonInventoryItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,inventory_name,name,count,owner")] addon_inventory_items addon_inventory_items)
        {
            if (ModelState.IsValid)
            {
                db.addon_inventory_items.Add(addon_inventory_items);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addon_inventory_items);
        }

        // GET: AddonInventoryItems/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            addon_inventory_items addon_inventory_items = db.addon_inventory_items.Find(id);
            if (addon_inventory_items == null)
            {
                return HttpNotFound();
            }
            return View(addon_inventory_items);
        }

        // POST: AddonInventoryItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,inventory_name,name,count,owner")] addon_inventory_items addon_inventory_items)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addon_inventory_items).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addon_inventory_items);
        }

        // GET: AddonInventoryItems/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            addon_inventory_items addon_inventory_items = db.addon_inventory_items.Find(id);
            if (addon_inventory_items == null)
            {
                return HttpNotFound();
            }
            return View(addon_inventory_items);
        }

        // POST: AddonInventoryItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            addon_inventory_items addon_inventory_items = db.addon_inventory_items.Find(id);
            db.addon_inventory_items.Remove(addon_inventory_items);
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
