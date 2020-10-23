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
    public class TwitterLikeController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: TwitterLike
        [AdminAuthorize]
        public ActionResult Index()
        {
            var twitter_likes = db.twitter_likes.Include(t => t.twitter_accounts).Include(t => t.twitter_tweets);
            return View(twitter_likes.ToList());
        }

        // GET: TwitterLike/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            twitter_likes twitter_likes = db.twitter_likes.Find(id);
            if (twitter_likes == null)
            {
                return HttpNotFound();
            }
            return View(twitter_likes);
        }

        // GET: TwitterLike/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            ViewBag.authorId = new SelectList(db.twitter_accounts, "id", "username");
            ViewBag.tweetId = new SelectList(db.twitter_tweets, "id", "realUser");
            return View();
        }

        // POST: TwitterLike/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,authorId,tweetId")] twitter_likes twitter_likes)
        {
            if (ModelState.IsValid)
            {
                db.twitter_likes.Add(twitter_likes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.authorId = new SelectList(db.twitter_accounts, "id", "username", twitter_likes.authorId);
            ViewBag.tweetId = new SelectList(db.twitter_tweets, "id", "realUser", twitter_likes.tweetId);
            return View(twitter_likes);
        }

        // GET: TwitterLike/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            twitter_likes twitter_likes = db.twitter_likes.Find(id);
            if (twitter_likes == null)
            {
                return HttpNotFound();
            }
            ViewBag.authorId = new SelectList(db.twitter_accounts, "id", "username", twitter_likes.authorId);
            ViewBag.tweetId = new SelectList(db.twitter_tweets, "id", "realUser", twitter_likes.tweetId);
            return View(twitter_likes);
        }

        // POST: TwitterLike/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,authorId,tweetId")] twitter_likes twitter_likes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(twitter_likes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.authorId = new SelectList(db.twitter_accounts, "id", "username", twitter_likes.authorId);
            ViewBag.tweetId = new SelectList(db.twitter_tweets, "id", "realUser", twitter_likes.tweetId);
            return View(twitter_likes);
        }

        // GET: TwitterLike/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            twitter_likes twitter_likes = db.twitter_likes.Find(id);
            if (twitter_likes == null)
            {
                return HttpNotFound();
            }
            return View(twitter_likes);
        }

        // POST: TwitterLike/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            twitter_likes twitter_likes = db.twitter_likes.Find(id);
            db.twitter_likes.Remove(twitter_likes);
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
