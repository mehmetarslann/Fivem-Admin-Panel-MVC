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
    public class KaiserCiuchyController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: KaiserCiuchy
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.kaiser_ciuchy.ToList());
        }

        // GET: KaiserCiuchy/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kaiser_ciuchy kaiser_ciuchy = db.kaiser_ciuchy.Find(id);
            if (kaiser_ciuchy == null)
            {
                return HttpNotFound();
            }
            return View(kaiser_ciuchy);
        }

        // GET: KaiserCiuchy/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: KaiserCiuchy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,identifier,bag,bag2,tshirt,tshirt2,torso,torso2,legs,legs2,shoes,shoes2,arms,chain,chain2,mask,mask2,decals,decals2,hat,hat2,glasses,glasses2")] kaiser_ciuchy kaiser_ciuchy)
        {
            if (ModelState.IsValid)
            {
                db.kaiser_ciuchy.Add(kaiser_ciuchy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kaiser_ciuchy);
        }

        // GET: KaiserCiuchy/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kaiser_ciuchy kaiser_ciuchy = db.kaiser_ciuchy.Find(id);
            if (kaiser_ciuchy == null)
            {
                return HttpNotFound();
            }
            return View(kaiser_ciuchy);
        }

        // POST: KaiserCiuchy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,identifier,bag,bag2,tshirt,tshirt2,torso,torso2,legs,legs2,shoes,shoes2,arms,chain,chain2,mask,mask2,decals,decals2,hat,hat2,glasses,glasses2")] kaiser_ciuchy kaiser_ciuchy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kaiser_ciuchy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kaiser_ciuchy);
        }

        // GET: KaiserCiuchy/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kaiser_ciuchy kaiser_ciuchy = db.kaiser_ciuchy.Find(id);
            if (kaiser_ciuchy == null)
            {
                return HttpNotFound();
            }
            return View(kaiser_ciuchy);
        }

        // POST: KaiserCiuchy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            kaiser_ciuchy kaiser_ciuchy = db.kaiser_ciuchy.Find(id);
            db.kaiser_ciuchy.Remove(kaiser_ciuchy);
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
