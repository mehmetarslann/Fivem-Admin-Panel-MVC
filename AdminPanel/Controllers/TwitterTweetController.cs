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
    public class TwitterTweetController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: TwitterTweet
        [AdminAuthorize]
        public ActionResult Index()
        {
            var twitter_tweets = db.twitter_tweets.Include(t => t.twitter_accounts);
            return View(twitter_tweets.ToList());
        }

        // GET: TwitterTweet/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            twitter_tweets twitter_tweets = db.twitter_tweets.Find(id);
            if (twitter_tweets == null)
            {
                return HttpNotFound();
            }
            return View(twitter_tweets);
        }

        // GET: TwitterTweet/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            ViewBag.authorId = new SelectList(db.twitter_accounts, "id", "username");
            return View();
        }

        // POST: TwitterTweet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,authorId,realUser,message,time,likes")] twitter_tweets twitter_tweets)
        {
            if (ModelState.IsValid)
            {
                db.twitter_tweets.Add(twitter_tweets);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.authorId = new SelectList(db.twitter_accounts, "id", "username", twitter_tweets.authorId);
            return View(twitter_tweets);
        }

        // GET: TwitterTweet/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            twitter_tweets twitter_tweets = db.twitter_tweets.Find(id);
            if (twitter_tweets == null)
            {
                return HttpNotFound();
            }
            ViewBag.authorId = new SelectList(db.twitter_accounts, "id", "username", twitter_tweets.authorId);
            return View(twitter_tweets);
        }

        // POST: TwitterTweet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,authorId,realUser,message,time,likes")] twitter_tweets twitter_tweets)
        {
            if (ModelState.IsValid)
            {
                db.Entry(twitter_tweets).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.authorId = new SelectList(db.twitter_accounts, "id", "username", twitter_tweets.authorId);
            return View(twitter_tweets);
        }

        // GET: TwitterTweet/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            twitter_tweets twitter_tweets = db.twitter_tweets.Find(id);
            if (twitter_tweets == null)
            {
                return HttpNotFound();
            }
            return View(twitter_tweets);
        }

        // POST: TwitterTweet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            twitter_tweets twitter_tweets = db.twitter_tweets.Find(id);
            db.twitter_tweets.Remove(twitter_tweets);
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
