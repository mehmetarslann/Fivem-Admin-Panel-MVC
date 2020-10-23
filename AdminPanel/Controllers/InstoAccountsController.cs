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
    public class InstoAccountsController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: InstoAccounts
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.insto_accounts.ToList());
        }

        // GET: InstoAccounts/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insto_accounts insto_accounts = db.insto_accounts.Find(id);
            if (insto_accounts == null)
            {
                return HttpNotFound();
            }
            return View(insto_accounts);
        }

        // GET: InstoAccounts/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: InstoAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,forename,surname,username,password,avatar_url")] insto_accounts insto_accounts)
        {
            if (ModelState.IsValid)
            {
                db.insto_accounts.Add(insto_accounts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insto_accounts);
        }

        // GET: InstoAccounts/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insto_accounts insto_accounts = db.insto_accounts.Find(id);
            if (insto_accounts == null)
            {
                return HttpNotFound();
            }
            return View(insto_accounts);
        }

        // POST: InstoAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,forename,surname,username,password,avatar_url")] insto_accounts insto_accounts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insto_accounts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insto_accounts);
        }

        // GET: InstoAccounts/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insto_accounts insto_accounts = db.insto_accounts.Find(id);
            if (insto_accounts == null)
            {
                return HttpNotFound();
            }
            return View(insto_accounts);
        }

        // POST: InstoAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            insto_accounts insto_accounts = db.insto_accounts.Find(id);
            db.insto_accounts.Remove(insto_accounts);
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
