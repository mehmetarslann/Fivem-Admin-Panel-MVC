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
    public class LauncherAyarController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: LauncherAyar
        [AdminAuthorize]
        public ActionResult Index()
        {
            var launcher_ayarlar = db.launcher_ayarlar.Include(l => l.launcher_renk).Include(l => l.launcher_renk1).Include(l => l.launcher_renk2);
            return View(launcher_ayarlar.ToList());
        }

        [AdminAuthorize]
        public ActionResult ResimveRenk()
        {
            var launcher_ayarlar = db.launcher_ayarlar.Include(l => l.launcher_renk).Include(l => l.launcher_renk1).Include(l => l.launcher_renk2);
            return View(launcher_ayarlar.ToList());
        }

        [AdminAuthorize]
        public ActionResult RenkDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            launcher_ayarlar launcher_ayarlar = db.launcher_ayarlar.Find(id);
            if (launcher_ayarlar == null)
            {
                return HttpNotFound();
            }
            return View(launcher_ayarlar);
        }

        // GET: LauncherAyar/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            launcher_ayarlar launcher_ayarlar = db.launcher_ayarlar.Find(id);
            if (launcher_ayarlar == null)
            {
                return HttpNotFound();
            }
            ViewBag.sol_renk = new SelectList(db.launcher_renk, "renk_id", "renk_id", launcher_ayarlar.sol_renk);
            ViewBag.main_renk = new SelectList(db.launcher_renk, "renk_id", "renk_id", launcher_ayarlar.main_renk);
            ViewBag.sag_renk = new SelectList(db.launcher_renk, "renk_id", "renk_id", launcher_ayarlar.sag_renk);
            return View(launcher_ayarlar);
        }

        // POST: LauncherAyar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "ayarlar_id,arkaplan_resmi,sol_logo,team_ip,discord_adres,sunucu_port,sunucu_ip,team_port,forum_adres,sol_renk,main_renk,sag_renk")] launcher_ayarlar launcher_ayarlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(launcher_ayarlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sol_renk = new SelectList(db.launcher_renk, "renk_id", "renk_id", launcher_ayarlar.sol_renk);
            ViewBag.main_renk = new SelectList(db.launcher_renk, "renk_id", "renk_id", launcher_ayarlar.main_renk);
            ViewBag.sag_renk = new SelectList(db.launcher_renk, "renk_id", "renk_id", launcher_ayarlar.sag_renk);
            return View(launcher_ayarlar);
        }
        [AdminAuthorize]
        public ActionResult RenkEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            launcher_ayarlar launcher_ayarlar = db.launcher_ayarlar.Find(id);
            if (launcher_ayarlar == null)
            {
                return HttpNotFound();
            }
            ViewBag.sol_renk = new SelectList(db.launcher_renk, "renk_id", "renk_id", launcher_ayarlar.sol_renk);
            ViewBag.main_renk = new SelectList(db.launcher_renk, "renk_id", "renk_id", launcher_ayarlar.main_renk);
            ViewBag.sag_renk = new SelectList(db.launcher_renk, "renk_id", "renk_id", launcher_ayarlar.sag_renk);
            return View(launcher_ayarlar);
        }

        // POST: LauncherAyarlar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult RenkEdit([Bind(Include = "ayarlar_id,arkaplan_resmi,sol_logo,team_ip,discord_adres,sunucu_port,sunucu_ip,team_port,forum_adres,sol_renk,main_renk,sag_renk")] launcher_ayarlar launcher_ayarlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(launcher_ayarlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ResimveRenk");
            }
            ViewBag.sol_renk = new SelectList(db.launcher_renk, "renk_id", "renk_id", launcher_ayarlar.sol_renk);
            ViewBag.main_renk = new SelectList(db.launcher_renk, "renk_id", "renk_id", launcher_ayarlar.main_renk);
            ViewBag.sag_renk = new SelectList(db.launcher_renk, "renk_id", "renk_id", launcher_ayarlar.sag_renk);
            return View(launcher_ayarlar);
        }

        // GET: LauncherAyar/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            launcher_ayarlar launcher_ayarlar = db.launcher_ayarlar.Find(id);
            if (launcher_ayarlar == null)
            {
                return HttpNotFound();
            }
            return View(launcher_ayarlar);
        }

        // POST: LauncherAyar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            launcher_ayarlar launcher_ayarlar = db.launcher_ayarlar.Find(id);
            db.launcher_ayarlar.Remove(launcher_ayarlar);
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
