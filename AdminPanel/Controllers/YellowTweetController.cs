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
    public class YellowTweetController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: YellowTweet
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.yellow_tweets.ToList());
        }

        // GET: YellowTweet/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yellow_tweets yellow_tweets = db.yellow_tweets.Find(id);
            if (yellow_tweets == null)
            {
                return HttpNotFound();
            }
            return View(yellow_tweets);
        }

        // GET: YellowTweet/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: YellowTweet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,phone_number,firstname,lastname,message,time")] yellow_tweets yellow_tweets)
        {
            if (ModelState.IsValid)
            {
                db.yellow_tweets.Add(yellow_tweets);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yellow_tweets);
        }

        // GET: YellowTweet/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yellow_tweets yellow_tweets = db.yellow_tweets.Find(id);
            if (yellow_tweets == null)
            {
                return HttpNotFound();
            }
            return View(yellow_tweets);
        }

        // POST: YellowTweet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,phone_number,firstname,lastname,message,time")] yellow_tweets yellow_tweets)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yellow_tweets).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yellow_tweets);
        }

        // GET: YellowTweet/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            yellow_tweets yellow_tweets = db.yellow_tweets.Find(id);
            if (yellow_tweets == null)
            {
                return HttpNotFound();
            }
            return View(yellow_tweets);
        }

        // POST: YellowTweet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            yellow_tweets yellow_tweets = db.yellow_tweets.Find(id);
            db.yellow_tweets.Remove(yellow_tweets);
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
