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
    public class AddonAccountDataController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: AddonAccountData
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.addon_account_data.ToList());
        }

        [AdminAuthorize]
        // GET: AddonAccountData/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            addon_account_data addon_account_data = db.addon_account_data.Find(id);
            if (addon_account_data == null)
            {
                return HttpNotFound();
            }
            return View(addon_account_data);
        }

        // GET: AddonAccountData/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddonAccountData/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,account_name,money,owner")] addon_account_data addon_account_data)
        {
            if (ModelState.IsValid)
            {
                db.addon_account_data.Add(addon_account_data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addon_account_data);
        }

        // GET: AddonAccountData/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            addon_account_data addon_account_data = db.addon_account_data.Find(id);
            if (addon_account_data == null)
            {
                return HttpNotFound();
            }
            return View(addon_account_data);
        }

        // POST: AddonAccountData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,account_name,money,owner")] addon_account_data addon_account_data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addon_account_data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addon_account_data);
        }

        // GET: AddonAccountData/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            addon_account_data addon_account_data = db.addon_account_data.Find(id);
            if (addon_account_data == null)
            {
                return HttpNotFound();
            }
            return View(addon_account_data);
        }

        // POST: AddonAccountData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            addon_account_data addon_account_data = db.addon_account_data.Find(id);
            db.addon_account_data.Remove(addon_account_data);
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
