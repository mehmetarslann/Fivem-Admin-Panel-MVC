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
    public class LsrpMotelController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: LsrpMotel
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.lsrp_motels.ToList());
        }

        // GET: LsrpMotel/Details/5
        [AdminAuthorize]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lsrp_motels lsrp_motels = db.lsrp_motels.Find(id);
            if (lsrp_motels == null)
            {
                return HttpNotFound();
            }
            return View(lsrp_motels);
        }

        // GET: LsrpMotel/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: LsrpMotel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,ident,motel_id")] lsrp_motels lsrp_motels)
        {
            if (ModelState.IsValid)
            {
                db.lsrp_motels.Add(lsrp_motels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lsrp_motels);
        }

        // GET: LsrpMotel/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lsrp_motels lsrp_motels = db.lsrp_motels.Find(id);
            if (lsrp_motels == null)
            {
                return HttpNotFound();
            }
            return View(lsrp_motels);
        }

        // POST: LsrpMotel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,ident,motel_id")] lsrp_motels lsrp_motels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lsrp_motels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lsrp_motels);
        }

        // GET: LsrpMotel/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lsrp_motels lsrp_motels = db.lsrp_motels.Find(id);
            if (lsrp_motels == null)
            {
                return HttpNotFound();
            }
            return View(lsrp_motels);
        }

        // POST: LsrpMotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(long id)
        {
            lsrp_motels lsrp_motels = db.lsrp_motels.Find(id);
            db.lsrp_motels.Remove(lsrp_motels);
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
