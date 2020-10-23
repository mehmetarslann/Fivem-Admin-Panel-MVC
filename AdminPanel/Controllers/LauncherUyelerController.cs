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
    public class LauncherUyelerController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: LauncherUyeler
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.launcher_uyeler.ToList());
        }

        // GET: LauncherUyeler/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            launcher_uyeler launcher_uyeler = db.launcher_uyeler.Find(id);
            if (launcher_uyeler == null)
            {
                return HttpNotFound();
            }
            return View(launcher_uyeler);
        }

        // GET: LauncherUyeler/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: LauncherUyeler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "uye_id,uye_ad,uye_soyad,uye_kadi,uye_parola,uye_gtarih,steam_id,discord_id,hile_tespiti,login_durum")] launcher_uyeler launcher_uyeler)
        {
            if (ModelState.IsValid)
            {
                db.launcher_uyeler.Add(launcher_uyeler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(launcher_uyeler);
        }

        // GET: LauncherUyeler/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            launcher_uyeler launcher_uyeler = db.launcher_uyeler.Find(id);
            if (launcher_uyeler == null)
            {
                return HttpNotFound();
            }
            return View(launcher_uyeler);
        }

        // POST: LauncherUyeler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "uye_id,uye_ad,uye_soyad,uye_kadi,uye_parola,uye_gtarih,steam_id,discord_id,hile_tespiti,login_durum")] launcher_uyeler launcher_uyeler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(launcher_uyeler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(launcher_uyeler);
        }

        // GET: LauncherUyeler/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            launcher_uyeler launcher_uyeler = db.launcher_uyeler.Find(id);
            if (launcher_uyeler == null)
            {
                return HttpNotFound();
            }
            return View(launcher_uyeler);
        }

        // POST: LauncherUyeler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            launcher_uyeler launcher_uyeler = db.launcher_uyeler.Find(id);
            db.launcher_uyeler.Remove(launcher_uyeler);
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
