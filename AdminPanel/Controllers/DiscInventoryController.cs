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
    public class DiscInventoryController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: DiscInventory
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.disc_inventory.ToList());
        }

        // GET: DiscInventory/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            disc_inventory disc_inventory = db.disc_inventory.Find(id);
            if (disc_inventory == null)
            {
                return HttpNotFound();
            }
            return View(disc_inventory);
        }

        // GET: DiscInventory/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiscInventory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,owner,type,data")] disc_inventory disc_inventory)
        {
            if (ModelState.IsValid)
            {
                db.disc_inventory.Add(disc_inventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(disc_inventory);
        }

        // GET: DiscInventory/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            disc_inventory disc_inventory = db.disc_inventory.Find(id);
            if (disc_inventory == null)
            {
                return HttpNotFound();
            }
            return View(disc_inventory);
        }

        // POST: DiscInventory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,owner,type,data")] disc_inventory disc_inventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disc_inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(disc_inventory);
        }

        // GET: DiscInventory/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            disc_inventory disc_inventory = db.disc_inventory.Find(id);
            if (disc_inventory == null)
            {
                return HttpNotFound();
            }
            return View(disc_inventory);
        }

        // POST: DiscInventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            disc_inventory disc_inventory = db.disc_inventory.Find(id);
            db.disc_inventory.Remove(disc_inventory);
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
