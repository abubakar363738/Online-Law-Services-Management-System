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
    public class LawyersController : Controller
    {
        private Model1 db = new Model1();

        // GET: Lawyers
        public ActionResult Index()
        {
            var lawyers = db.Lawyers.Include(l => l.Expertise).Include(l => l.Qualification);
            return View(lawyers.ToList());
        }

        // GET: Lawyers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lawyer lawyer = db.Lawyers.Find(id);
            if (lawyer == null)
            {
                return HttpNotFound();
            }
            return View(lawyer);
        }

        // GET: Lawyers/Create
        public ActionResult Create()
        {
            ViewBag.ExpertiseFid = new SelectList(db.Expertises, "ExpertiseId", "Expertise1");
            ViewBag.QualificationFid = new SelectList(db.Qualifications, "QualificationId", "DegreeName");
            return View();
        }

        // POST: Lawyers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LawyerId,FirstName,LastName,FatherName,UserName,LawyerEmail,Password,Picture,Street,Town,City,District,Province,Country,PostalCode,CNIC,DOB,MartialStatus,Gender,MobileNumber,WhatsappNumber,Language,PracticeCity,BarCouncil,EnrollmentYear,BarLicenseNumber,LawFirm,FirmAddress,Contribution,Facebook,LinkedIn,Status,HandledCases,QualificationFid,ExpertiseFid")] Lawyer lawyer)
        {
            if (ModelState.IsValid)
            {
                db.Lawyers.Add(lawyer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExpertiseFid = new SelectList(db.Expertises, "ExpertiseId", "Expertise1", lawyer.ExpertiseFid);
            ViewBag.QualificationFid = new SelectList(db.Qualifications, "QualificationId", "DegreeName", lawyer.QualificationFid);
            return View(lawyer);
        }

        // GET: Lawyers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lawyer lawyer = db.Lawyers.Find(id);
            if (lawyer == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExpertiseFid = new SelectList(db.Expertises, "ExpertiseId", "Expertise1", lawyer.ExpertiseFid);
            ViewBag.QualificationFid = new SelectList(db.Qualifications, "QualificationId", "DegreeName", lawyer.QualificationFid);
            return View(lawyer);
        }

        // POST: Lawyers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LawyerId,FirstName,LastName,FatherName,UserName,LawyerEmail,Password,Picture,Street,Town,City,District,Province,Country,PostalCode,CNIC,DOB,MartialStatus,Gender,MobileNumber,WhatsappNumber,Language,PracticeCity,BarCouncil,EnrollmentYear,BarLicenseNumber,LawFirm,FirmAddress,Contribution,Facebook,LinkedIn,Status,HandledCases,QualificationFid,ExpertiseFid")] Lawyer lawyer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lawyer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExpertiseFid = new SelectList(db.Expertises, "ExpertiseId", "Expertise1", lawyer.ExpertiseFid);
            ViewBag.QualificationFid = new SelectList(db.Qualifications, "QualificationId", "DegreeName", lawyer.QualificationFid);
            return View(lawyer);
        }

        // GET: Lawyers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lawyer lawyer = db.Lawyers.Find(id);
            if (lawyer == null)
            {
                return HttpNotFound();
            }
            return View(lawyer);
        }

        // POST: Lawyers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lawyer lawyer = db.Lawyers.Find(id);
            db.Lawyers.Remove(lawyer);
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
