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
    public class UserMdtController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: UserMdt
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.user_mdt.ToList());
        }

        // GET: UserMdt/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_mdt user_mdt = db.user_mdt.Find(id);
            if (user_mdt == null)
            {
                return HttpNotFound();
            }
            return View(user_mdt);
        }

        // GET: UserMdt/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserMdt/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,char_id,notes,mugshot_url")] user_mdt user_mdt)
        {
            if (ModelState.IsValid)
            {
                db.user_mdt.Add(user_mdt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_mdt);
        }

        // GET: UserMdt/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_mdt user_mdt = db.user_mdt.Find(id);
            if (user_mdt == null)
            {
                return HttpNotFound();
            }
            return View(user_mdt);
        }

        // POST: UserMdt/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,char_id,notes,mugshot_url")] user_mdt user_mdt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_mdt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_mdt);
        }

        // GET: UserMdt/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_mdt user_mdt = db.user_mdt.Find(id);
            if (user_mdt == null)
            {
                return HttpNotFound();
            }
            return View(user_mdt);
        }

        // POST: UserMdt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            user_mdt user_mdt = db.user_mdt.Find(id);
            db.user_mdt.Remove(user_mdt);
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
