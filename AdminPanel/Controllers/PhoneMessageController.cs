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
    public class PhoneMessageController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: PhoneMessage
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.phone_messages.ToList());
        }

        // GET: PhoneMessage/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phone_messages phone_messages = db.phone_messages.Find(id);
            if (phone_messages == null)
            {
                return HttpNotFound();
            }
            return View(phone_messages);
        }

        // GET: PhoneMessage/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhoneMessage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,transmitter,receiver,message,time,isRead,owner")] phone_messages phone_messages)
        {
            if (ModelState.IsValid)
            {
                db.phone_messages.Add(phone_messages);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phone_messages);
        }

        // GET: PhoneMessage/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phone_messages phone_messages = db.phone_messages.Find(id);
            if (phone_messages == null)
            {
                return HttpNotFound();
            }
            return View(phone_messages);
        }

        // POST: PhoneMessage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,transmitter,receiver,message,time,isRead,owner")] phone_messages phone_messages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phone_messages).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phone_messages);
        }

        // GET: PhoneMessage/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phone_messages phone_messages = db.phone_messages.Find(id);
            if (phone_messages == null)
            {
                return HttpNotFound();
            }
            return View(phone_messages);
        }

        // POST: PhoneMessage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            phone_messages phone_messages = db.phone_messages.Find(id);
            db.phone_messages.Remove(phone_messages);
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
