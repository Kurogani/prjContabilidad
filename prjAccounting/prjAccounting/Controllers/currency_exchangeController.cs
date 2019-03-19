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
    public class currency_exchangeController : Controller
    {
        private accounting_dbEntities db = new accounting_dbEntities();

        // GET: currency_exchange
        public ActionResult Index()
        {
            var currency_exchange = db.currency_exchange.Include(c => c.currency);
            return View(currency_exchange.ToList());
        }

        // GET: currency_exchange/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            currency_exchange currency_exchange = db.currency_exchange.Find(id);
            if (currency_exchange == null)
            {
                return HttpNotFound();
            }
            return View(currency_exchange);
        }

        // GET: currency_exchange/Create
        public ActionResult Create()
        {
            ViewBag.currency_id = new SelectList(db.currency, "id", "code");
            return View();
        }

        // POST: currency_exchange/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,currency_id,amount,create_on")] currency_exchange currency_exchange)
        {
            if (ModelState.IsValid)
            {
                db.currency_exchange.Add(currency_exchange);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.currency_id = new SelectList(db.currency, "id", "code", currency_exchange.currency_id);
            return View(currency_exchange);
        }

        // GET: currency_exchange/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            currency_exchange currency_exchange = db.currency_exchange.Find(id);
            if (currency_exchange == null)
            {
                return HttpNotFound();
            }
            ViewBag.currency_id = new SelectList(db.currency, "id", "code", currency_exchange.currency_id);
            return View(currency_exchange);
        }

        // POST: currency_exchange/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,currency_id,amount,create_on")] currency_exchange currency_exchange)
        {
            if (ModelState.IsValid)
            {
                db.Entry(currency_exchange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.currency_id = new SelectList(db.currency, "id", "code", currency_exchange.currency_id);
            return View(currency_exchange);
        }

        // GET: currency_exchange/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            currency_exchange currency_exchange = db.currency_exchange.Find(id);
            if (currency_exchange == null)
            {
                return HttpNotFound();
            }
            return View(currency_exchange);
        }

        // POST: currency_exchange/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            currency_exchange currency_exchange = db.currency_exchange.Find(id);
            db.currency_exchange.Remove(currency_exchange);
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
