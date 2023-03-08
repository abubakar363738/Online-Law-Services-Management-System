using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Online_Law_Services_Management_System.Models;

namespace Online_Law_Services_Management_System.Controllers
{
    public class FeesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Fees
        public ActionResult Index()
        {
            var fees = db.Fees.Include(f => f.Client).Include(f => f.Lawyer);
            return View(fees.ToList());
        }

        // GET: Fees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fee fee = db.Fees.Find(id);
            if (fee == null)
            {
                return HttpNotFound();
            }
            return View(fee);
        }

        // GET: Fees/Create
        public ActionResult Create()
        {
            ViewBag.ClientFid = new SelectList(db.Clients, "ClientId", "FirstName");
            ViewBag.LawyerFid = new SelectList(db.Lawyers, "LawyerId", "FirstName");
            return View();
        }

        // POST: Fees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FeesId,Profit,FeesStatus,ClientFid,LawyerFid")] Fee fee)
        {
            if (ModelState.IsValid)
            {
                db.Fees.Add(fee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientFid = new SelectList(db.Clients, "ClientId", "FirstName", fee.ClientFid);
            ViewBag.LawyerFid = new SelectList(db.Lawyers, "LawyerId", "FirstName", fee.LawyerFid);
            return View(fee);
        }

        // GET: Fees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fee fee = db.Fees.Find(id);
            if (fee == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientFid = new SelectList(db.Clients, "ClientId", "FirstName", fee.ClientFid);
            ViewBag.LawyerFid = new SelectList(db.Lawyers, "LawyerId", "FirstName", fee.LawyerFid);
            return View(fee);
        }

        // POST: Fees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FeesId,Profit,FeesStatus,ClientFid,LawyerFid")] Fee fee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientFid = new SelectList(db.Clients, "ClientId", "FirstName", fee.ClientFid);
            ViewBag.LawyerFid = new SelectList(db.Lawyers, "LawyerId", "FirstName", fee.LawyerFid);
            return View(fee);
        }

        // GET: Fees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fee fee = db.Fees.Find(id);
            if (fee == null)
            {
                return HttpNotFound();
            }
            return View(fee);
        }

        // POST: Fees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fee fee = db.Fees.Find(id);
            db.Fees.Remove(fee);
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
