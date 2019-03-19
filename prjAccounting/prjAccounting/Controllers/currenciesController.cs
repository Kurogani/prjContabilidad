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
    public class currenciesController : Controller
    {
        private accounting_dbEntities db = new accounting_dbEntities();

        // GET: currencies
        public ActionResult Index()
        {
            return View(db.currency.ToList());
        }

        // GET: currencies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            currency currency = db.currency.Find(id);
            if (currency == null)
            {
                return HttpNotFound();
            }
            return View(currency);
        }

        // GET: currencies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: currencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,code,name,state")] currency currency)
        {
            if (ModelState.IsValid)
            {
                db.currency.Add(currency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(currency);
        }

        // GET: currencies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            currency currency = db.currency.Find(id);
            if (currency == null)
            {
                return HttpNotFound();
            }
            return View(currency);
        }

        // POST: currencies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,code,name,state")] currency currency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(currency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(currency);
        }

        // GET: currencies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            currency currency = db.currency.Find(id);
            if (currency == null)
            {
                return HttpNotFound();
            }
            return View(currency);
        }

        // POST: currencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            currency currency = db.currency.Find(id);
            db.currency.Remove(currency);
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
