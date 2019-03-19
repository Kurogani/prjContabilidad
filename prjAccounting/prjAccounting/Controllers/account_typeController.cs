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
    public class account_typeController : Controller
    {
        private accounting_dbEntities db = new accounting_dbEntities();

        // GET: account_type
        public ActionResult Index()
        {
            return View(db.account_type.ToList());
        }

        // GET: account_type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            account_type account_type = db.account_type.Find(id);
            if (account_type == null)
            {
                return HttpNotFound();
            }
            return View(account_type);
        }

        // GET: account_type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: account_type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,description,state")] account_type account_type)
        {
            if (ModelState.IsValid)
            {
                db.account_type.Add(account_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(account_type);
        }

        // GET: account_type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            account_type account_type = db.account_type.Find(id);
            if (account_type == null)
            {
                return HttpNotFound();
            }
            return View(account_type);
        }

        // POST: account_type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,description,state")] account_type account_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account_type);
        }

        // GET: account_type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            account_type account_type = db.account_type.Find(id);
            if (account_type == null)
            {
                return HttpNotFound();
            }
            return View(account_type);
        }

        // POST: account_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            account_type account_type = db.account_type.Find(id);
            db.account_type.Remove(account_type);
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
