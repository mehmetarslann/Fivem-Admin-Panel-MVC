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
    public class DpKeyBindController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: DpKeyBind
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.dpkeybinds.ToList());
        }

        // GET: DpKeyBind/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dpkeybinds dpkeybinds = db.dpkeybinds.Find(id);
            if (dpkeybinds == null)
            {
                return HttpNotFound();
            }
            return View(dpkeybinds);
        }

        // GET: DpKeyBind/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DpKeyBind/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "d_id,id,keybind1,emote1,keybind2,emote2,keybind3,emote3,keybind4,emote4,keybind5,emote5,keybind6,emote6")] dpkeybinds dpkeybinds)
        {
            if (ModelState.IsValid)
            {
                db.dpkeybinds.Add(dpkeybinds);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dpkeybinds);
        }

        // GET: DpKeyBind/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dpkeybinds dpkeybinds = db.dpkeybinds.Find(id);
            if (dpkeybinds == null)
            {
                return HttpNotFound();
            }
            return View(dpkeybinds);
        }

        // POST: DpKeyBind/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AdminAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "d_id,id,keybind1,emote1,keybind2,emote2,keybind3,emote3,keybind4,emote4,keybind5,emote5,keybind6,emote6")] dpkeybinds dpkeybinds)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dpkeybinds).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dpkeybinds);
        }

        // GET: DpKeyBind/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dpkeybinds dpkeybinds = db.dpkeybinds.Find(id);
            if (dpkeybinds == null)
            {
                return HttpNotFound();
            }
            return View(dpkeybinds);
        }

        // POST: DpKeyBind/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            dpkeybinds dpkeybinds = db.dpkeybinds.Find(id);
            db.dpkeybinds.Remove(dpkeybinds);
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
