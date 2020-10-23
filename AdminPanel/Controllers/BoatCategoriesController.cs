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
    public class BoatCategoriesController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: BoatCategories
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.boat_categories.ToList());
        }

        // GET: BoatCategories/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boat_categories boat_categories = db.boat_categories.Find(id);
            if (boat_categories == null)
            {
                return HttpNotFound();
            }
            return View(boat_categories);
        }

        // GET: BoatCategories/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BoatCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,name,label")] boat_categories boat_categories)
        {
            if (ModelState.IsValid)
            {
                db.boat_categories.Add(boat_categories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boat_categories);
        }

        // GET: BoatCategories/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boat_categories boat_categories = db.boat_categories.Find(id);
            if (boat_categories == null)
            {
                return HttpNotFound();
            }
            return View(boat_categories);
        }

        // POST: BoatCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,name,label")] boat_categories boat_categories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boat_categories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boat_categories);
        }

        // GET: BoatCategories/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boat_categories boat_categories = db.boat_categories.Find(id);
            if (boat_categories == null)
            {
                return HttpNotFound();
            }
            return View(boat_categories);
        }

        // POST: BoatCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            boat_categories boat_categories = db.boat_categories.Find(id);
            db.boat_categories.Remove(boat_categories);
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
