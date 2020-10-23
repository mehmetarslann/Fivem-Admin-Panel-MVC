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
    public class BoatDealerController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: BoatDealer
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.boatdealer_boats.ToList());
        }

        // GET: BoatDealer/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boatdealer_boats boatdealer_boats = db.boatdealer_boats.Find(id);
            if (boatdealer_boats == null)
            {
                return HttpNotFound();
            }
            return View(boatdealer_boats);
        }

        // GET: BoatDealer/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BoatDealer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,vehicle,price")] boatdealer_boats boatdealer_boats)
        {
            if (ModelState.IsValid)
            {
                db.boatdealer_boats.Add(boatdealer_boats);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boatdealer_boats);
        }

        // GET: BoatDealer/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boatdealer_boats boatdealer_boats = db.boatdealer_boats.Find(id);
            if (boatdealer_boats == null)
            {
                return HttpNotFound();
            }
            return View(boatdealer_boats);
        }

        // POST: BoatDealer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,vehicle,price")] boatdealer_boats boatdealer_boats)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boatdealer_boats).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boatdealer_boats);
        }

        // GET: BoatDealer/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boatdealer_boats boatdealer_boats = db.boatdealer_boats.Find(id);
            if (boatdealer_boats == null)
            {
                return HttpNotFound();
            }
            return View(boatdealer_boats);
        }

        // POST: BoatDealer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            boatdealer_boats boatdealer_boats = db.boatdealer_boats.Find(id);
            db.boatdealer_boats.Remove(boatdealer_boats);
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
