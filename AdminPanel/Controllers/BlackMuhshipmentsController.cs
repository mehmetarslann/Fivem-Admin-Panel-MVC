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
    public class BlackMuhshipmentsController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: BlackMuhshipments
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.black_muhshipments.ToList());
        }

        // GET: BlackMuhshipments/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            black_muhshipments black_muhshipments = db.black_muhshipments.Find(id);
            if (black_muhshipments == null)
            {
                return HttpNotFound();
            }
            return View(black_muhshipments);
        }

        // GET: BlackMuhshipments/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlackMuhshipments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "black_id,id,identifier,label,item,price,count,time")] black_muhshipments black_muhshipments)
        {
            if (ModelState.IsValid)
            {
                db.black_muhshipments.Add(black_muhshipments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(black_muhshipments);
        }

        // GET: BlackMuhshipments/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            black_muhshipments black_muhshipments = db.black_muhshipments.Find(id);
            if (black_muhshipments == null)
            {
                return HttpNotFound();
            }
            return View(black_muhshipments);
        }

        // POST: BlackMuhshipments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "black_id,id,identifier,label,item,price,count,time")] black_muhshipments black_muhshipments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(black_muhshipments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(black_muhshipments);
        }

        // GET: BlackMuhshipments/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            black_muhshipments black_muhshipments = db.black_muhshipments.Find(id);
            if (black_muhshipments == null)
            {
                return HttpNotFound();
            }
            return View(black_muhshipments);
        }

        // POST: BlackMuhshipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            black_muhshipments black_muhshipments = db.black_muhshipments.Find(id);
            db.black_muhshipments.Remove(black_muhshipments);
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
