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
    public class AdminsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Admins
        public ActionResult Index()
        {
            var admins = db.Admins.Include(a => a.Client).Include(a => a.Lawyer).Include(a => a.Report);
            return View(admins.ToList());
        }

        // GET: Admins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // GET: Admins/Create
        public ActionResult Create()
        {
            ViewBag.ClientFid = new SelectList(db.Clients, "ClientId", "FirstName");
            ViewBag.LawyerFId = new SelectList(db.Lawyers, "LawyerId", "FirstName");
            ViewBag.ReportFid = new SelectList(db.Reports, "ReportId", "Description");
            return View();
        }

        // POST: Admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdminId,Name,Password,ClientFid,LawyerFId,ReportFid,Status")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientFid = new SelectList(db.Clients, "ClientId", "FirstName", admin.ClientFid);
            ViewBag.LawyerFId = new SelectList(db.Lawyers, "LawyerId", "FirstName", admin.LawyerFId);
            ViewBag.ReportFid = new SelectList(db.Reports, "ReportId", "Description", admin.ReportFid);
            return View(admin);
        }

        // GET: Admins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientFid = new SelectList(db.Clients, "ClientId", "FirstName", admin.ClientFid);
            ViewBag.LawyerFId = new SelectList(db.Lawyers, "LawyerId", "FirstName", admin.LawyerFId);
            ViewBag.ReportFid = new SelectList(db.Reports, "ReportId", "Description", admin.ReportFid);
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdminId,Name,Password,ClientFid,LawyerFId,ReportFid,Status")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientFid = new SelectList(db.Clients, "ClientId", "FirstName", admin.ClientFid);
            ViewBag.LawyerFId = new SelectList(db.Lawyers, "LawyerId", "FirstName", admin.LawyerFId);
            ViewBag.ReportFid = new SelectList(db.Reports, "ReportId", "Description", admin.ReportFid);
            return View(admin);
        }

        // GET: Admins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin admin = db.Admins.Find(id);
            db.Admins.Remove(admin);
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
