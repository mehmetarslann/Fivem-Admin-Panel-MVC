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
    public class KokainController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: Kokain
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.kokain.ToList());
        }

        // GET: Kokain/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kokain kokain = db.kokain.Find(id);
            if (kokain == null)
            {
                return HttpNotFound();
            }
            return View(kokain);
        }

        // GET: Kokain/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kokain/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,Sender,Type,Amount,Reciever,Time")] kokain kokain)
        {
            if (ModelState.IsValid)
            {
                db.kokain.Add(kokain);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kokain);
        }

        // GET: Kokain/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kokain kokain = db.kokain.Find(id);
            if (kokain == null)
            {
                return HttpNotFound();
            }
            return View(kokain);
        }

        // POST: Kokain/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,Sender,Type,Amount,Reciever,Time")] kokain kokain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kokain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kokain);
        }

        // GET: Kokain/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kokain kokain = db.kokain.Find(id);
            if (kokain == null)
            {
                return HttpNotFound();
            }
            return View(kokain);
        }

        // POST: Kokain/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            kokain kokain = db.kokain.Find(id);
            db.kokain.Remove(kokain);
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
