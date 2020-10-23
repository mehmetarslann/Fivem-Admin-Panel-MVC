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
    public class InstoLikesController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: InstoLikes
        [AdminAuthorize]
        public ActionResult Index()
        {
            var insto_likes = db.insto_likes.Include(i => i.insto_accounts).Include(i => i.insto_instas);
            return View(insto_likes.ToList());
        }

        // GET: InstoLikes/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insto_likes insto_likes = db.insto_likes.Find(id);
            if (insto_likes == null)
            {
                return HttpNotFound();
            }
            return View(insto_likes);
        }

        // GET: InstoLikes/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            ViewBag.authorId = new SelectList(db.insto_accounts, "id", "forename");
            ViewBag.inapId = new SelectList(db.insto_instas, "id", "realUser");
            return View();
        }

        // POST: InstoLikes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,authorId,inapId")] insto_likes insto_likes)
        {
            if (ModelState.IsValid)
            {
                db.insto_likes.Add(insto_likes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.authorId = new SelectList(db.insto_accounts, "id", "forename", insto_likes.authorId);
            ViewBag.inapId = new SelectList(db.insto_instas, "id", "realUser", insto_likes.inapId);
            return View(insto_likes);
        }

        // GET: InstoLikes/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insto_likes insto_likes = db.insto_likes.Find(id);
            if (insto_likes == null)
            {
                return HttpNotFound();
            }
            ViewBag.authorId = new SelectList(db.insto_accounts, "id", "forename", insto_likes.authorId);
            ViewBag.inapId = new SelectList(db.insto_instas, "id", "realUser", insto_likes.inapId);
            return View(insto_likes);
        }

        // POST: InstoLikes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,authorId,inapId")] insto_likes insto_likes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insto_likes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.authorId = new SelectList(db.insto_accounts, "id", "forename", insto_likes.authorId);
            ViewBag.inapId = new SelectList(db.insto_instas, "id", "realUser", insto_likes.inapId);
            return View(insto_likes);
        }

        // GET: InstoLikes/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insto_likes insto_likes = db.insto_likes.Find(id);
            if (insto_likes == null)
            {
                return HttpNotFound();
            }
            return View(insto_likes);
        }

        // POST: InstoLikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            insto_likes insto_likes = db.insto_likes.Find(id);
            db.insto_likes.Remove(insto_likes);
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
