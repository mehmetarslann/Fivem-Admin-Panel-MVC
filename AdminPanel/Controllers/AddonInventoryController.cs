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
    public class AddonInventoryController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: AddonInventory
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.addon_inventory.ToList());
        }

        // GET: AddonInventory/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            addon_inventory addon_inventory = db.addon_inventory.Find(id);
            if (addon_inventory == null)
            {
                return HttpNotFound();
            }
            return View(addon_inventory);
        }

        // GET: AddonInventory/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddonInventory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "addon_id,id,name,label,shared")] addon_inventory addon_inventory)
        {
            if (ModelState.IsValid)
            {
                db.addon_inventory.Add(addon_inventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addon_inventory);
        }

        // GET: AddonInventory/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            addon_inventory addon_inventory = db.addon_inventory.Find(id);
            if (addon_inventory == null)
            {
                return HttpNotFound();
            }
            return View(addon_inventory);
        }

        // POST: AddonInventory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "addon_id,id,name,label,shared")] addon_inventory addon_inventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addon_inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addon_inventory);
        }

        // GET: AddonInventory/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            addon_inventory addon_inventory = db.addon_inventory.Find(id);
            if (addon_inventory == null)
            {
                return HttpNotFound();
            }
            return View(addon_inventory);
        }

        // POST: AddonInventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            addon_inventory addon_inventory = db.addon_inventory.Find(id);
            db.addon_inventory.Remove(addon_inventory);
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
