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
    public class BoatController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: Boat
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.boats.ToList());
        }

        // GET: Boat/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boats boats = db.boats.Find(id);
            if (boats == null)
            {
                return HttpNotFound();
            }
            return View(boats);
        }

        // GET: Boat/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Boat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,name,model,price,category")] boats boats)
        {
            if (ModelState.IsValid)
            {
                db.boats.Add(boats);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boats);
        }

        // GET: Boat/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boats boats = db.boats.Find(id);
            if (boats == null)
            {
                return HttpNotFound();
            }
            return View(boats);
        }

        // POST: Boat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,name,model,price,category")] boats boats)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boats).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boats);
        }

        // GET: Boat/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boats boats = db.boats.Find(id);
            if (boats == null)
            {
                return HttpNotFound();
            }
            return View(boats);
        }

        // POST: Boat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            boats boats = db.boats.Find(id);
            db.boats.Remove(boats);
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
