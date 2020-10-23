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
    public class PhoneUserContactController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: PhoneUserContact
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.phone_users_contacts.ToList());
        }

        // GET: PhoneUserContact/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phone_users_contacts phone_users_contacts = db.phone_users_contacts.Find(id);
            if (phone_users_contacts == null)
            {
                return HttpNotFound();
            }
            return View(phone_users_contacts);
        }

        // GET: PhoneUserContact/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhoneUserContact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,identifier,number,display")] phone_users_contacts phone_users_contacts)
        {
            if (ModelState.IsValid)
            {
                db.phone_users_contacts.Add(phone_users_contacts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phone_users_contacts);
        }

        // GET: PhoneUserContact/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phone_users_contacts phone_users_contacts = db.phone_users_contacts.Find(id);
            if (phone_users_contacts == null)
            {
                return HttpNotFound();
            }
            return View(phone_users_contacts);
        }

        // POST: PhoneUserContact/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,identifier,number,display")] phone_users_contacts phone_users_contacts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phone_users_contacts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phone_users_contacts);
        }

        // GET: PhoneUserContact/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            phone_users_contacts phone_users_contacts = db.phone_users_contacts.Find(id);
            if (phone_users_contacts == null)
            {
                return HttpNotFound();
            }
            return View(phone_users_contacts);
        }

        // POST: PhoneUserContact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            phone_users_contacts phone_users_contacts = db.phone_users_contacts.Find(id);
            db.phone_users_contacts.Remove(phone_users_contacts);
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
