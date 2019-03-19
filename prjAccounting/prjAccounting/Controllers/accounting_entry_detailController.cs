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
    public class accounting_entry_detailController : Controller
    {
        private accounting_dbEntities db = new accounting_dbEntities();

        // GET: accounting_entry_detail
        public ActionResult Index()
        {
            var accounting_entry_detail = db.accounting_entry_detail.Include(a => a.account_catalog).Include(a => a.accounting_entry);
            return View(accounting_entry_detail.ToList());
        }

        // GET: accounting_entry_detail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            accounting_entry_detail accounting_entry_detail = db.accounting_entry_detail.Find(id);
            if (accounting_entry_detail == null)
            {
                return HttpNotFound();
            }
            return View(accounting_entry_detail);
        }

        // GET: accounting_entry_detail/Create
        public ActionResult Create()
        {
            ViewBag.account_catalog_id = new SelectList(db.account_catalog, "id", "code");
            ViewBag.accounting_entry_id = new SelectList(db.accounting_entry, "id", "description");
            return View();
        }

        // POST: accounting_entry_detail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,accounting_entry_id,account_catalog_id,transaction_type,amount")] accounting_entry_detail accounting_entry_detail)
        {
            if (ModelState.IsValid)
            {
                db.accounting_entry_detail.Add(accounting_entry_detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.account_catalog_id = new SelectList(db.account_catalog, "id", "code", accounting_entry_detail.account_catalog_id);
            ViewBag.accounting_entry_id = new SelectList(db.accounting_entry, "id", "description", accounting_entry_detail.accounting_entry_id);
            return View(accounting_entry_detail);
        }

        // GET: accounting_entry_detail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            accounting_entry_detail accounting_entry_detail = db.accounting_entry_detail.Find(id);
            if (accounting_entry_detail == null)
            {
                return HttpNotFound();
            }
            ViewBag.account_catalog_id = new SelectList(db.account_catalog, "id", "code", accounting_entry_detail.account_catalog_id);
            ViewBag.accounting_entry_id = new SelectList(db.accounting_entry, "id", "description", accounting_entry_detail.accounting_entry_id);
            return View(accounting_entry_detail);
        }

        // POST: accounting_entry_detail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,accounting_entry_id,account_catalog_id,transaction_type,amount")] accounting_entry_detail accounting_entry_detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accounting_entry_detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.account_catalog_id = new SelectList(db.account_catalog, "id", "code", accounting_entry_detail.account_catalog_id);
            ViewBag.accounting_entry_id = new SelectList(db.accounting_entry, "id", "description", accounting_entry_detail.accounting_entry_id);
            return View(accounting_entry_detail);
        }

        // GET: accounting_entry_detail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            accounting_entry_detail accounting_entry_detail = db.accounting_entry_detail.Find(id);
            if (accounting_entry_detail == null)
            {
                return HttpNotFound();
            }
            return View(accounting_entry_detail);
        }

        // POST: accounting_entry_detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            accounting_entry_detail accounting_entry_detail = db.accounting_entry_detail.Find(id);
            db.accounting_entry_detail.Remove(accounting_entry_detail);
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
