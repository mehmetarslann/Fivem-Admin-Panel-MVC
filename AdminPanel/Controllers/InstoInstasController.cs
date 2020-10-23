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
    public class InstoInstasController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: InstoInstas
        [AdminAuthorize]
        public ActionResult Index()
        {
            var insto_instas = db.insto_instas.Include(i => i.insto_accounts);
            return View(insto_instas.ToList());
        }

        // GET: InstoInstas/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insto_instas insto_instas = db.insto_instas.Find(id);
            if (insto_instas == null)
            {
                return HttpNotFound();
            }
            return View(insto_instas);
        }

        // GET: InstoInstas/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            ViewBag.authorId = new SelectList(db.insto_accounts, "id", "forename");
            return View();
        }

        // POST: InstoInstas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,authorId,realUser,message,image,filters,time,likes")] insto_instas insto_instas)
        {
            if (ModelState.IsValid)
            {
                db.insto_instas.Add(insto_instas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.authorId = new SelectList(db.insto_accounts, "id", "forename", insto_instas.authorId);
            return View(insto_instas);
        }

        // GET: InstoInstas/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insto_instas insto_instas = db.insto_instas.Find(id);
            if (insto_instas == null)
            {
                return HttpNotFound();
            }
            ViewBag.authorId = new SelectList(db.insto_accounts, "id", "forename", insto_instas.authorId);
            return View(insto_instas);
        }

        // POST: InstoInstas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,authorId,realUser,message,image,filters,time,likes")] insto_instas insto_instas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insto_instas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.authorId = new SelectList(db.insto_accounts, "id", "forename", insto_instas.authorId);
            return View(insto_instas);
        }

        // GET: InstoInstas/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            insto_instas insto_instas = db.insto_instas.Find(id);
            if (insto_instas == null)
            {
                return HttpNotFound();
            }
            return View(insto_instas);
        }

        // POST: InstoInstas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            insto_instas insto_instas = db.insto_instas.Find(id);
            db.insto_instas.Remove(insto_instas);
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
