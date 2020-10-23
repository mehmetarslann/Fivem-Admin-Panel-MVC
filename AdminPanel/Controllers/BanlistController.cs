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
    public class BanlistController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: Banlist
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.banlist.ToList());
        }

        // GET: Banlist/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            banlist banlist = db.banlist.Find(id);
            if (banlist == null)
            {
                return HttpNotFound();
            }
            return View(banlist);
        }

        // GET: Banlist/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Banlist/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,identifier,license,liveid,xblid,discord,playerip,targetplayername,sourceplayername,reason,timeat,added,expiration,permanent")] banlist banlist)
        {
            if (ModelState.IsValid)
            {
                db.banlist.Add(banlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(banlist);
        }

        // GET: Banlist/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            banlist banlist = db.banlist.Find(id);
            if (banlist == null)
            {
                return HttpNotFound();
            }
            return View(banlist);
        }

        // POST: Banlist/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,identifier,license,liveid,xblid,discord,playerip,targetplayername,sourceplayername,reason,timeat,added,expiration,permanent")] banlist banlist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(banlist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(banlist);
        }

        // GET: Banlist/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            banlist banlist = db.banlist.Find(id);
            if (banlist == null)
            {
                return HttpNotFound();
            }
            return View(banlist);
        }

        // POST: Banlist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            banlist banlist = db.banlist.Find(id);
            db.banlist.Remove(banlist);
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
