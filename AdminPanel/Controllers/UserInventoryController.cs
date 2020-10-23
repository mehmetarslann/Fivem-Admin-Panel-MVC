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
    public class UserInventoryController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: UserInventory
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.user_inventory.ToList());
        }

        // GET: UserInventory/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_inventory user_inventory = db.user_inventory.Find(id);
            if (user_inventory == null)
            {
                return HttpNotFound();
            }
            return View(user_inventory);
        }

        // GET: UserInventory/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserInventory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,identifier,item,count")] user_inventory user_inventory)
        {
            if (ModelState.IsValid)
            {
                db.user_inventory.Add(user_inventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_inventory);
        }

        // GET: UserInventory/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_inventory user_inventory = db.user_inventory.Find(id);
            if (user_inventory == null)
            {
                return HttpNotFound();
            }
            return View(user_inventory);
        }

        // POST: UserInventory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,identifier,item,count")] user_inventory user_inventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_inventory);
        }

        // GET: UserInventory/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_inventory user_inventory = db.user_inventory.Find(id);
            if (user_inventory == null)
            {
                return HttpNotFound();
            }
            return View(user_inventory);
        }

        // POST: UserInventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            user_inventory user_inventory = db.user_inventory.Find(id);
            db.user_inventory.Remove(user_inventory);
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
