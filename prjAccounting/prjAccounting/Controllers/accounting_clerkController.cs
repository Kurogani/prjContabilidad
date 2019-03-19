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
    public class accounting_clerkController : Controller
    {
        private accounting_dbEntities db = new accounting_dbEntities();

        // GET: accounting_clerk
        public ActionResult Index()
        {
            return View(db.accounting_clerk.ToList());
        }

        // GET: accounting_clerk/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            accounting_clerk accounting_clerk = db.accounting_clerk.Find(id);
            if (accounting_clerk == null)
            {
                return HttpNotFound();
            }
            return View(accounting_clerk);
        }

        // GET: accounting_clerk/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: accounting_clerk/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,code,name,state")] accounting_clerk accounting_clerk)
        {
            if (ModelState.IsValid)
            {
                db.accounting_clerk.Add(accounting_clerk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accounting_clerk);
        }

        // GET: accounting_clerk/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            accounting_clerk accounting_clerk = db.accounting_clerk.Find(id);
            if (accounting_clerk == null)
            {
                return HttpNotFound();
            }
            return View(accounting_clerk);
        }

        // POST: accounting_clerk/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,code,name,state")] accounting_clerk accounting_clerk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accounting_clerk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accounting_clerk);
        }

        // GET: accounting_clerk/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            accounting_clerk accounting_clerk = db.accounting_clerk.Find(id);
            if (accounting_clerk == null)
            {
                return HttpNotFound();
            }
            return View(accounting_clerk);
        }

        // POST: accounting_clerk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            accounting_clerk accounting_clerk = db.accounting_clerk.Find(id);
            db.accounting_clerk.Remove(accounting_clerk);
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
