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
    public class UserAccountController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: UserAccount
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.user_accounts.ToList());
        }

        // GET: UserAccount/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_accounts user_accounts = db.user_accounts.Find(id);
            if (user_accounts == null)
            {
                return HttpNotFound();
            }
            return View(user_accounts);
        }

        // GET: UserAccount/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserAccount/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,identifier,name,money")] user_accounts user_accounts)
        {
            if (ModelState.IsValid)
            {
                db.user_accounts.Add(user_accounts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_accounts);
        }

        // GET: UserAccount/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_accounts user_accounts = db.user_accounts.Find(id);
            if (user_accounts == null)
            {
                return HttpNotFound();
            }
            return View(user_accounts);
        }

        // POST: UserAccount/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,identifier,name,money")] user_accounts user_accounts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_accounts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_accounts);
        }

        // GET: UserAccount/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_accounts user_accounts = db.user_accounts.Find(id);
            if (user_accounts == null)
            {
                return HttpNotFound();
            }
            return View(user_accounts);
        }

        // POST: UserAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            user_accounts user_accounts = db.user_accounts.Find(id);
            db.user_accounts.Remove(user_accounts);
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
