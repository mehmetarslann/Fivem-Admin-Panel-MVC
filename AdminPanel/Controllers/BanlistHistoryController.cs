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
    public class BanlistHistoryController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: BanlistHistory
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.banlisthistory.ToList());
        }

        // GET: BanlistHistory/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            banlisthistory banlisthistory = db.banlisthistory.Find(id);
            if (banlisthistory == null)
            {
                return HttpNotFound();
            }
            return View(banlisthistory);
        }

        // GET: BanlistHistory/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BanlistHistory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,identifier,license,liveid,xblid,discord,playerip,targetplayername,sourceplayername,reason,timeat,added,expiration,permanent")] banlisthistory banlisthistory)
        {
            if (ModelState.IsValid)
            {
                db.banlisthistory.Add(banlisthistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(banlisthistory);
        }

        // GET: BanlistHistory/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            banlisthistory banlisthistory = db.banlisthistory.Find(id);
            if (banlisthistory == null)
            {
                return HttpNotFound();
            }
            return View(banlisthistory);
        }

        // POST: BanlistHistory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,identifier,license,liveid,xblid,discord,playerip,targetplayername,sourceplayername,reason,timeat,added,expiration,permanent")] banlisthistory banlisthistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(banlisthistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(banlisthistory);
        }

        // GET: BanlistHistory/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            banlisthistory banlisthistory = db.banlisthistory.Find(id);
            if (banlisthistory == null)
            {
                return HttpNotFound();
            }
            return View(banlisthistory);
        }

        // POST: BanlistHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            banlisthistory banlisthistory = db.banlisthistory.Find(id);
            db.banlisthistory.Remove(banlisthistory);
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
