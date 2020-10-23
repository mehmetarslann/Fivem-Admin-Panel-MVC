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
    public class DataStoreController : Controller
    {
        private sunucu1sEntities db = new sunucu1sEntities();

        // GET: DataStore
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View(db.datastore.ToList());
        }

        // GET: DataStore/Details/5
        [AdminAuthorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            datastore datastore = db.datastore.Find(id);
            if (datastore == null)
            {
                return HttpNotFound();
            }
            return View(datastore);
        }

        // GET: DataStore/Create
        [AdminAuthorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataStore/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create([Bind(Include = "id,name,label,shared")] datastore datastore)
        {
            if (ModelState.IsValid)
            {
                db.datastore.Add(datastore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(datastore);
        }

        // GET: DataStore/Edit/5
        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            datastore datastore = db.datastore.Find(id);
            if (datastore == null)
            {
                return HttpNotFound();
            }
            return View(datastore);
        }

        // POST: DataStore/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Edit([Bind(Include = "id,name,label,shared")] datastore datastore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datastore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(datastore);
        }

        // GET: DataStore/Delete/5
        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            datastore datastore = db.datastore.Find(id);
            if (datastore == null)
            {
                return HttpNotFound();
            }
            return View(datastore);
        }

        // POST: DataStore/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult DeleteConfirmed(int id)
        {
            datastore datastore = db.datastore.Find(id);
            db.datastore.Remove(datastore);
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
