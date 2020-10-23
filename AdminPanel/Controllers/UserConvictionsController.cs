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
    public class UserConvictionsController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: UserConvictions
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.user_convictions.ToList());
        }

        // GET: UserConvictions/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_convictions user_convictions = db.user_convictions.Find(id);
            if (user_convictions == null)
            {
                return HttpNotFound();
            }
            return View(user_convictions);
        }

        // GET: UserConvictions/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserConvictions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,char_id,offense,count")] user_convictions user_convictions)
        {
            if (ModelState.IsValid)
            {
                db.user_convictions.Add(user_convictions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_convictions);
        }

        // GET: UserConvictions/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_convictions user_convictions = db.user_convictions.Find(id);
            if (user_convictions == null)
            {
                return HttpNotFound();
            }
            return View(user_convictions);
        }

        // POST: UserConvictions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,char_id,offense,count")] user_convictions user_convictions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_convictions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_convictions);
        }

        // GET: UserConvictions/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_convictions user_convictions = db.user_convictions.Find(id);
            if (user_convictions == null)
            {
                return HttpNotFound();
            }
            return View(user_convictions);
        }

        // POST: UserConvictions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            user_convictions user_convictions = db.user_convictions.Find(id);
            db.user_convictions.Remove(user_convictions);
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
