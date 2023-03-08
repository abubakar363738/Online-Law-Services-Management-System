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
    public class ConsultationsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Consultations
        public ActionResult Index()
        {
            var consultations = db.Consultations.Include(c => c.Appointment).Include(c => c.Client).Include(c => c.Fee).Include(c => c.Lawyer);
            return View(consultations.ToList());
        }

        // GET: Consultations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultation consultation = db.Consultations.Find(id);
            if (consultation == null)
            {
                return HttpNotFound();
            }
            return View(consultation);
        }

        // GET: Consultations/Create
        public ActionResult Create()
        {
            ViewBag.AppointmentFormFid = new SelectList(db.Appointments, "AppointmentFormId", "CaseDescription");
            ViewBag.ClientFid = new SelectList(db.Clients, "ClientId", "FirstName");
            ViewBag.FeesFid = new SelectList(db.Fees, "FeesId", "Profit");
            ViewBag.LawyerFid = new SelectList(db.Lawyers, "LawyerId", "FirstName");
            return View();
        }

        // POST: Consultations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConsultationId,ConsultationDate,DesiredDate,AssignedDate,AppointmentFormFid,ClientFid,LawyerFid,CurrentNoOfCasses,FeesFid")] Consultation consultation)
        {
            if (ModelState.IsValid)
            {
                db.Consultations.Add(consultation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AppointmentFormFid = new SelectList(db.Appointments, "AppointmentFormId", "CaseDescription", consultation.AppointmentFormFid);
            ViewBag.ClientFid = new SelectList(db.Clients, "ClientId", "FirstName", consultation.ClientFid);
            ViewBag.FeesFid = new SelectList(db.Fees, "FeesId", "Profit", consultation.FeesFid);
            ViewBag.LawyerFid = new SelectList(db.Lawyers, "LawyerId", "FirstName", consultation.LawyerFid);
            return View(consultation);
        }

        // GET: Consultations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultation consultation = db.Consultations.Find(id);
            if (consultation == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppointmentFormFid = new SelectList(db.Appointments, "AppointmentFormId", "CaseDescription", consultation.AppointmentFormFid);
            ViewBag.ClientFid = new SelectList(db.Clients, "ClientId", "FirstName", consultation.ClientFid);
            ViewBag.FeesFid = new SelectList(db.Fees, "FeesId", "Profit", consultation.FeesFid);
            ViewBag.LawyerFid = new SelectList(db.Lawyers, "LawyerId", "FirstName", consultation.LawyerFid);
            return View(consultation);
        }

        // POST: Consultations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConsultationId,ConsultationDate,DesiredDate,AssignedDate,AppointmentFormFid,ClientFid,LawyerFid,CurrentNoOfCasses,FeesFid")] Consultation consultation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consultation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AppointmentFormFid = new SelectList(db.Appointments, "AppointmentFormId", "CaseDescription", consultation.AppointmentFormFid);
            ViewBag.ClientFid = new SelectList(db.Clients, "ClientId", "FirstName", consultation.ClientFid);
            ViewBag.FeesFid = new SelectList(db.Fees, "FeesId", "Profit", consultation.FeesFid);
            ViewBag.LawyerFid = new SelectList(db.Lawyers, "LawyerId", "FirstName", consultation.LawyerFid);
            return View(consultation);
        }

        // GET: Consultations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultation consultation = db.Consultations.Find(id);
            if (consultation == null)
            {
                return HttpNotFound();
            }
            return View(consultation);
        }

        // POST: Consultations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consultation consultation = db.Consultations.Find(id);
            db.Consultations.Remove(consultation);
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
