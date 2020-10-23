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
    public class PhoneCallController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: PhoneCall
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.phone_calls.ToList());
        }

        // GET: PhoneCall/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phone_calls phone_calls = db.phone_calls.Find(id);
            if (phone_calls == null)
            {
                return HttpNotFound();
            }
            return View(phone_calls);
        }

        // GET: PhoneCall/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhoneCall/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,owner,num,incoming,time,accepts")] phone_calls phone_calls)
        {
            if (ModelState.IsValid)
            {
                db.phone_calls.Add(phone_calls);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phone_calls);
        }

        // GET: PhoneCall/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phone_calls phone_calls = db.phone_calls.Find(id);
            if (phone_calls == null)
            {
                return HttpNotFound();
            }
            return View(phone_calls);
        }

        // POST: PhoneCall/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,owner,num,incoming,time,accepts")] phone_calls phone_calls)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phone_calls).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phone_calls);
        }

        // GET: PhoneCall/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phone_calls phone_calls = db.phone_calls.Find(id);
            if (phone_calls == null)
            {
                return HttpNotFound();
            }
            return View(phone_calls);
        }

        // POST: PhoneCall/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            phone_calls phone_calls = db.phone_calls.Find(id);
            db.phone_calls.Remove(phone_calls);
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
