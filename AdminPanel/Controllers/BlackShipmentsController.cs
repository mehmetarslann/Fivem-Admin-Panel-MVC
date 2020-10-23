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
    public class BlackShipmentsController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: BlackShipments
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.black_shipments.ToList());
        }

        // GET: BlackShipments/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            black_shipments black_shipments = db.black_shipments.Find(id);
            if (black_shipments == null)
            {
                return HttpNotFound();
            }
            return View(black_shipments);
        }

        [AdminAuthorize]
        // GET: BlackShipments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlackShipments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "b_id,id,identifier,label,item,price,count,time")] black_shipments black_shipments)
        {
            if (ModelState.IsValid)
            {
                db.black_shipments.Add(black_shipments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(black_shipments);
        }

        // GET: BlackShipments/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            black_shipments black_shipments = db.black_shipments.Find(id);
            if (black_shipments == null)
            {
                return HttpNotFound();
            }
            return View(black_shipments);
        }

        // POST: BlackShipments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [AdminAuthorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "b_id,id,identifier,label,item,price,count,time")] black_shipments black_shipments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(black_shipments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(black_shipments);
        }

        // GET: BlackShipments/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            black_shipments black_shipments = db.black_shipments.Find(id);
            if (black_shipments == null)
            {
                return HttpNotFound();
            }
            return View(black_shipments);
        }

        // POST: BlackShipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            black_shipments black_shipments = db.black_shipments.Find(id);
            db.black_shipments.Remove(black_shipments);
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
