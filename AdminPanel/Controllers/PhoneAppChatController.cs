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
    public class PhoneAppChatController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: PhoneAppChat
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.phone_app_chat.ToList());
        }

        // GET: PhoneAppChat/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phone_app_chat phone_app_chat = db.phone_app_chat.Find(id);
            if (phone_app_chat == null)
            {
                return HttpNotFound();
            }
            return View(phone_app_chat);
        }

        // GET: PhoneAppChat/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhoneAppChat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,channel,message,time")] phone_app_chat phone_app_chat)
        {
            if (ModelState.IsValid)
            {
                db.phone_app_chat.Add(phone_app_chat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phone_app_chat);
        }

        // GET: PhoneAppChat/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phone_app_chat phone_app_chat = db.phone_app_chat.Find(id);
            if (phone_app_chat == null)
            {
                return HttpNotFound();
            }
            return View(phone_app_chat);
        }

        // POST: PhoneAppChat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,channel,message,time")] phone_app_chat phone_app_chat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phone_app_chat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phone_app_chat);
        }

        // GET: PhoneAppChat/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phone_app_chat phone_app_chat = db.phone_app_chat.Find(id);
            if (phone_app_chat == null)
            {
                return HttpNotFound();
            }
            return View(phone_app_chat);
        }

        // POST: PhoneAppChat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            phone_app_chat phone_app_chat = db.phone_app_chat.Find(id);
            db.phone_app_chat.Remove(phone_app_chat);
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
