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
    public class accounting_entryController : Controller
    {
        private accounting_dbEntities db = new accounting_dbEntities();

        // GET: accounting_entry
        public ActionResult Index()
        {
            var accounting_entry = db.accounting_entry.Include(a => a.accounting_clerk).Include(a => a.currency);
            return View(accounting_entry.ToList());
        }

        // GET: accounting_entry/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            accounting_entry accounting_entry = db.accounting_entry.Find(id);
            if (accounting_entry == null)
            {
                return HttpNotFound();
            }
            return View(accounting_entry);
        }

        // GET: accounting_entry/Create
        public ActionResult Create()
        {
            ViewBag.accounting_clerk_id = new SelectList(db.accounting_clerk, "id", "code");
            ViewBag.currency_id = new SelectList(db.currency, "id", "code");
            return View();
        }

        // POST: accounting_entry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,accounting_clerk_id,currency_id,description,state,create_on")] accounting_entry accounting_entry)
        {
            if (ModelState.IsValid)
            {
                db.accounting_entry.Add(accounting_entry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.accounting_clerk_id = new SelectList(db.accounting_clerk, "id", "code", accounting_entry.accounting_clerk_id);
            ViewBag.currency_id = new SelectList(db.currency, "id", "code", accounting_entry.currency_id);
            return View(accounting_entry);
        }

        // GET: accounting_entry/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            accounting_entry accounting_entry = db.accounting_entry.Find(id);
            if (accounting_entry == null)
            {
                return HttpNotFound();
            }
            ViewBag.accounting_clerk_id = new SelectList(db.accounting_clerk, "id", "code", accounting_entry.accounting_clerk_id);
            ViewBag.currency_id = new SelectList(db.currency, "id", "code", accounting_entry.currency_id);
            return View(accounting_entry);
        }

        // POST: accounting_entry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,accounting_clerk_id,currency_id,description,state,create_on")] accounting_entry accounting_entry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accounting_entry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.accounting_clerk_id = new SelectList(db.accounting_clerk, "id", "code", accounting_entry.accounting_clerk_id);
            ViewBag.currency_id = new SelectList(db.currency, "id", "code", accounting_entry.currency_id);
            return View(accounting_entry);
        }

        // GET: accounting_entry/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            accounting_entry accounting_entry = db.accounting_entry.Find(id);
            if (accounting_entry == null)
            {
                return HttpNotFound();
            }
            return View(accounting_entry);
        }

        // POST: accounting_entry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            accounting_entry accounting_entry = db.accounting_entry.Find(id);
            db.accounting_entry.Remove(accounting_entry);
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
