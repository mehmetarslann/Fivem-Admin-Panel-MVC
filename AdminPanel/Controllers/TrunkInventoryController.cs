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
    public class TrunkInventoryController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: TrunkInventory
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.trunk_inventory.ToList());
        }

        // GET: TrunkInventory/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trunk_inventory trunk_inventory = db.trunk_inventory.Find(id);
            if (trunk_inventory == null)
            {
                return HttpNotFound();
            }
            return View(trunk_inventory);
        }

        // GET: TrunkInventory/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrunkInventory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,plate,data,owned")] trunk_inventory trunk_inventory)
        {
            if (ModelState.IsValid)
            {
                db.trunk_inventory.Add(trunk_inventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trunk_inventory);
        }

        // GET: TrunkInventory/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trunk_inventory trunk_inventory = db.trunk_inventory.Find(id);
            if (trunk_inventory == null)
            {
                return HttpNotFound();
            }
            return View(trunk_inventory);
        }

        // POST: TrunkInventory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,plate,data,owned")] trunk_inventory trunk_inventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trunk_inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trunk_inventory);
        }

        // GET: TrunkInventory/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trunk_inventory trunk_inventory = db.trunk_inventory.Find(id);
            if (trunk_inventory == null)
            {
                return HttpNotFound();
            }
            return View(trunk_inventory);
        }

        // POST: TrunkInventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            trunk_inventory trunk_inventory = db.trunk_inventory.Find(id);
            db.trunk_inventory.Remove(trunk_inventory);
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
