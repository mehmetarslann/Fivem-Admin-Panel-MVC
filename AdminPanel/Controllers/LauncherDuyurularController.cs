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
    public class LauncherDuyurularController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: LauncherDuyurular
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.launcher_duyurular.ToList());
        }

        // GET: LauncherDuyurular/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            launcher_duyurular launcher_duyurular = db.launcher_duyurular.Find(id);
            if (launcher_duyurular == null)
            {
                return HttpNotFound();
            }
            return View(launcher_duyurular);
        }

        // GET: LauncherDuyurular/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: LauncherDuyurular/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "duyuru_id,duyuru_baslik,duyuru_metin,duyuru_tarih")] launcher_duyurular launcher_duyurular)
        {
            if (ModelState.IsValid)
            {
                
                db.launcher_duyurular.Add(launcher_duyurular);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(launcher_duyurular);
        }

        // GET: LauncherDuyurular/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            launcher_duyurular launcher_duyurular = db.launcher_duyurular.Find(id);
            if (launcher_duyurular == null)
            {
                return HttpNotFound();
            }
            return View(launcher_duyurular);
        }

        // POST: LauncherDuyurular/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "duyuru_id,duyuru_baslik,duyuru_metin,duyuru_tarih")] launcher_duyurular launcher_duyurular)
        {
            if (ModelState.IsValid)
            {
                db.Entry(launcher_duyurular).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(launcher_duyurular);
        }

        // GET: LauncherDuyurular/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            launcher_duyurular launcher_duyurular = db.launcher_duyurular.Find(id);
            if (launcher_duyurular == null)
            {
                return HttpNotFound();
            }
            return View(launcher_duyurular);
        }

        // POST: LauncherDuyurular/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            launcher_duyurular launcher_duyurular = db.launcher_duyurular.Find(id);
            db.launcher_duyurular.Remove(launcher_duyurular);
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
