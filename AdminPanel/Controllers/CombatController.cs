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
    public class CombatController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: Combat
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.combat.ToList());
        }

        // GET: Combat/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            combat combat = db.combat.Find(id);
            if (combat == null)
            {
                return HttpNotFound();
            }
            return View(combat);
        }

        // GET: Combat/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Combat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,Sender,Type,Time")] combat combat)
        {
            if (ModelState.IsValid)
            {
                db.combat.Add(combat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(combat);
        }

        // GET: Combat/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            combat combat = db.combat.Find(id);
            if (combat == null)
            {
                return HttpNotFound();
            }
            return View(combat);
        }

        // POST: Combat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,Sender,Type,Time")] combat combat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(combat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(combat);
        }

        // GET: Combat/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            combat combat = db.combat.Find(id);
            if (combat == null)
            {
                return HttpNotFound();
            }
            return View(combat);
        }

        // POST: Combat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            combat combat = db.combat.Find(id);
            db.combat.Remove(combat);
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
