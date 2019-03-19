using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using prjAccounting;

namespace prjAccounting.Controllers
{
    public class account_catalogController : Controller
    {
        private accounting_dbEntities db = new accounting_dbEntities();

        // GET: account_catalog
        public ActionResult Index()
        {
            var account_catalog = db.account_catalog.Include(a => a.account_type);
            return View(account_catalog.ToList());
        }

        // GET: account_catalog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            account_catalog account_catalog = db.account_catalog.Find(id);
            if (account_catalog == null)
            {
                return HttpNotFound();
            }
            return View(account_catalog);
        }

        // GET: account_catalog/Create
        public ActionResult Create()
        {
            ViewBag.account_type_id = new SelectList(db.account_type, "id", "description");
            return View();
        }

        // POST: account_catalog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,account_type_id,code,name,transactional,level,major,balance,state")] account_catalog account_catalog)
        {
            if (ModelState.IsValid)
            {
                db.account_catalog.Add(account_catalog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.account_type_id = new SelectList(db.account_type, "id", "description", account_catalog.account_type_id);
            return View(account_catalog);
        }

        // GET: account_catalog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            account_catalog account_catalog = db.account_catalog.Find(id);
            if (account_catalog == null)
            {
                return HttpNotFound();
            }
            ViewBag.account_type_id = new SelectList(db.account_type, "id", "description", account_catalog.account_type_id);
            return View(account_catalog);
        }

        // POST: account_catalog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,account_type_id,code,name,transactional,level,major,balance,state")] account_catalog account_catalog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account_catalog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.account_type_id = new SelectList(db.account_type, "id", "description", account_catalog.account_type_id);
            return View(account_catalog);
        }

        // GET: account_catalog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            account_catalog account_catalog = db.account_catalog.Find(id);
            if (account_catalog == null)
            {
                return HttpNotFound();
            }
            return View(account_catalog);
        }

        // POST: account_catalog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            account_catalog account_catalog = db.account_catalog.Find(id);
            db.account_catalog.Remove(account_catalog);
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
