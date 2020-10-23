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
    public class DiscAmmoController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: DiscAmmo
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.disc_ammo.ToList());
        }

        // GET: DiscAmmo/Details/5
        [AdminAuthorize]
        public ActionResult Details(decimal? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            disc_ammo disc_ammo = db.disc_ammo.Find(id);
            if (disc_ammo == null)
            {
                return HttpNotFound();
            }
            return View(disc_ammo);
        }

        // GET: DiscAmmo/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiscAmmo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,owner,hash,count")] disc_ammo disc_ammo)
        {
            if (ModelState.IsValid)
            {
                db.disc_ammo.Add(disc_ammo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(disc_ammo);
        }

        // GET: DiscAmmo/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(decimal? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            disc_ammo disc_ammo = db.disc_ammo.Find(id);
            if (disc_ammo == null)
            {
                return HttpNotFound();
            }
            return View(disc_ammo);
        }

        // POST: DiscAmmo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,owner,hash,count")] disc_ammo disc_ammo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disc_ammo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(disc_ammo);
        }

        // GET: DiscAmmo/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(decimal? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            disc_ammo disc_ammo = db.disc_ammo.Find(id);
            if (disc_ammo == null)
            {
                return HttpNotFound();
            }
            return View(disc_ammo);
        }

        // POST: DiscAmmo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(decimal id)
        {
            disc_ammo disc_ammo = db.disc_ammo.Find(id);
            db.disc_ammo.Remove(disc_ammo);
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
