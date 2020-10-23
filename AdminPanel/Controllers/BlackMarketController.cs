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
    public class BlackMarketController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: BlackMarket
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.blackmarket.ToList());
        }

        // GET: BlackMarket/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            blackmarket blackmarket = db.blackmarket.Find(id);
            if (blackmarket == null)
            {
                return HttpNotFound();
            }
            return View(blackmarket);
        }

        // GET: BlackMarket/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlackMarket/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,Sender,Type,Amount,Reciever,Time")] blackmarket blackmarket)
        {
            if (ModelState.IsValid)
            {
                db.blackmarket.Add(blackmarket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blackmarket);
        }

        // GET: BlackMarket/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            blackmarket blackmarket = db.blackmarket.Find(id);
            if (blackmarket == null)
            {
                return HttpNotFound();
            }
            return View(blackmarket);
        }

        // POST: BlackMarket/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,Sender,Type,Amount,Reciever,Time")] blackmarket blackmarket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blackmarket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blackmarket);
        }

        // GET: BlackMarket/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            blackmarket blackmarket = db.blackmarket.Find(id);
            if (blackmarket == null)
            {
                return HttpNotFound();
            }
            return View(blackmarket);
        }

        // POST: BlackMarket/Delete/5
        [AdminAuthorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            blackmarket blackmarket = db.blackmarket.Find(id);
            db.blackmarket.Remove(blackmarket);
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
