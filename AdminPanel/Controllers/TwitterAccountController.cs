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
    public class TwitterAccountController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: TwitterAccount
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.twitter_accounts.ToList());
        }

        // GET: TwitterAccount/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            twitter_accounts twitter_accounts = db.twitter_accounts.Find(id);
            if (twitter_accounts == null)
            {
                return HttpNotFound();
            }
            return View(twitter_accounts);
        }

        // GET: TwitterAccount/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TwitterAccount/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,username,password,avatar_url")] twitter_accounts twitter_accounts)
        {
            if (ModelState.IsValid)
            {
                db.twitter_accounts.Add(twitter_accounts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(twitter_accounts);
        }

        // GET: TwitterAccount/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            twitter_accounts twitter_accounts = db.twitter_accounts.Find(id);
            if (twitter_accounts == null)
            {
                return HttpNotFound();
            }
            return View(twitter_accounts);
        }

        // POST: TwitterAccount/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,username,password,avatar_url")] twitter_accounts twitter_accounts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(twitter_accounts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(twitter_accounts);
        }

        // GET: TwitterAccount/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            twitter_accounts twitter_accounts = db.twitter_accounts.Find(id);
            if (twitter_accounts == null)
            {
                return HttpNotFound();
            }
            return View(twitter_accounts);
        }

        // POST: TwitterAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            twitter_accounts twitter_accounts = db.twitter_accounts.Find(id);
            db.twitter_accounts.Remove(twitter_accounts);
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
