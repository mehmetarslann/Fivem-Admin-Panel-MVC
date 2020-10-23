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
    public class AddonAccountController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: AddonAccount
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.addon_account.ToList());
        }

        // GET: AddonAccount/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            addon_account addon_account = db.addon_account.Find(id);
            if (addon_account == null)
            {
                return HttpNotFound();
            }
            return View(addon_account);
        }

        // GET: AddonAccount/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddonAccount/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,name,label,shared")] addon_account addon_account)
        {
            if (ModelState.IsValid)
            {
                db.addon_account.Add(addon_account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addon_account);
        }

        // GET: AddonAccount/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            addon_account addon_account = db.addon_account.Find(id);
            if (addon_account == null)
            {
                return HttpNotFound();
            }
            return View(addon_account);
        }

        // POST: AddonAccount/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,name,label,shared")] addon_account addon_account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addon_account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addon_account);
        }

        // GET: AddonAccount/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            addon_account addon_account = db.addon_account.Find(id);
            if (addon_account == null)
            {
                return HttpNotFound();
            }
            return View(addon_account);
        }

        // POST: AddonAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            addon_account addon_account = db.addon_account.Find(id);
            db.addon_account.Remove(addon_account);
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
