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
    public class SocietyMoneyWashController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: SocietyMoneyWash
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.society_moneywash.ToList());
        }

        // GET: SocietyMoneyWash/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            society_moneywash society_moneywash = db.society_moneywash.Find(id);
            if (society_moneywash == null)
            {
                return HttpNotFound();
            }
            return View(society_moneywash);
        }

        // GET: SocietyMoneyWash/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: SocietyMoneyWash/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,identifier,society,amount")] society_moneywash society_moneywash)
        {
            if (ModelState.IsValid)
            {
                db.society_moneywash.Add(society_moneywash);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(society_moneywash);
        }

        // GET: SocietyMoneyWash/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            society_moneywash society_moneywash = db.society_moneywash.Find(id);
            if (society_moneywash == null)
            {
                return HttpNotFound();
            }
            return View(society_moneywash);
        }

        // POST: SocietyMoneyWash/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,identifier,society,amount")] society_moneywash society_moneywash)
        {
            if (ModelState.IsValid)
            {
                db.Entry(society_moneywash).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(society_moneywash);
        }

        // GET: SocietyMoneyWash/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            society_moneywash society_moneywash = db.society_moneywash.Find(id);
            if (society_moneywash == null)
            {
                return HttpNotFound();
            }
            return View(society_moneywash);
        }

        // POST: SocietyMoneyWash/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            society_moneywash society_moneywash = db.society_moneywash.Find(id);
            db.society_moneywash.Remove(society_moneywash);
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
