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
    public class user_accountingController : Controller
    {
        private accounting_dbEntities db = new accounting_dbEntities();

        // GET: user_accounting
        public ActionResult Index()
        {
            return View(db.user_accounting.ToList());
        }

        // GET: user_accounting/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_accounting user_accounting = db.user_accounting.Find(id);
            if (user_accounting == null)
            {
                return HttpNotFound();
            }
            return View(user_accounting);
        }

        // GET: user_accounting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: user_accounting/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "username,fullname,user_password")] user_accounting user_accounting)
        {
            if (ModelState.IsValid)
            {
                db.user_accounting.Add(user_accounting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_accounting);
        }

        // GET: user_accounting/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_accounting user_accounting = db.user_accounting.Find(id);
            if (user_accounting == null)
            {
                return HttpNotFound();
            }
            return View(user_accounting);
        }

        // POST: user_accounting/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "username,fullname,user_password")] user_accounting user_accounting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_accounting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_accounting);
        }

        // GET: user_accounting/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_accounting user_accounting = db.user_accounting.Find(id);
            if (user_accounting == null)
            {
                return HttpNotFound();
            }
            return View(user_accounting);
        }

        // POST: user_accounting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            user_accounting user_accounting = db.user_accounting.Find(id);
            db.user_accounting.Remove(user_accounting);
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
