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
    public class LauncherRenkController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: LauncherRenk
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.launcher_renk.ToList());
        }

        // GET: LauncherRenk/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            launcher_renk launcher_renk = db.launcher_renk.Find(id);
            if (launcher_renk == null)
            {
                return HttpNotFound();
            }
            return View(launcher_renk);
        }

        // GET: LauncherRenk/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: LauncherRenk/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "renk_id,red,green,blue")] launcher_renk launcher_renk)
        {
            if (ModelState.IsValid)
            {
                db.launcher_renk.Add(launcher_renk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(launcher_renk);
        }

        // GET: LauncherRenk/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            launcher_renk launcher_renk = db.launcher_renk.Find(id);
            if (launcher_renk == null)
            {
                return HttpNotFound();
            }
            return View(launcher_renk);
        }

        // POST: LauncherRenk/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "renk_id,red,green,blue")] launcher_renk launcher_renk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(launcher_renk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(launcher_renk);
        }

        // GET: LauncherRenk/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            launcher_renk launcher_renk = db.launcher_renk.Find(id);
            if (launcher_renk == null)
            {
                return HttpNotFound();
            }
            return View(launcher_renk);
        }

        // POST: LauncherRenk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            launcher_renk launcher_renk = db.launcher_renk.Find(id);
            db.launcher_renk.Remove(launcher_renk);
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
