using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityofLouisvilleVaccine.DataContexts;
using UniversityofLouisvilleVaccine.Models;


namespace UniversityofLouisvilleVaccine.Controllers
{

    public class VaccineController : Controller
    {
        private VaccineDBContext db = new VaccineDBContext();

        // GET: /Vaccine/
        [Authorize(Roles = "Admin, Executive, ProgramStaff, Researcher")]
        public ActionResult Index(string lotnumber, string searchString)
        {
            var lotlist = new List<string>();

            var lotqry = from d in db.Vaccines
                         orderby d.lotNumber
                         select d.lotNumber;

            lotlist.AddRange(lotqry.Distinct());
            ViewBag.lotNumber = new SelectList(lotlist);

            var vaccines = from v in db.Vaccines select v;

            if (!String.IsNullOrEmpty(searchString))
            {
                vaccines = vaccines.Where(s => s.vaccineName.Contains(searchString));
            }

            if(!String.IsNullOrEmpty(lotnumber))
            {
                vaccines = vaccines.Where(x => x.lotNumber == lotnumber);
            }
            
            
            return View(vaccines);
        }

        // GET: /Vaccine/Details/5
        [Authorize(Roles = "Admin, Executive, ProgramStaff, Researcher")]
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaccine vaccine = db.Vaccines.Find(id);
            if (vaccine == null)
            {
                return HttpNotFound();
            }
            return View(vaccine);
        }

        // GET: /Vaccine/Create
        [Authorize(Roles = "Admin, Executive, ProgramStaff, Researcher")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Vaccine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Executive, ProgramStaff, Researcher")]
        public ActionResult Create([Bind(Include="ID,vaccineID,vaccineName,dateReceived,CPT,ICD9Code,NDC,leadTime,lotNumber,numofDoses,salesPrice,expDate")] Vaccine vaccine)
        {
            if (ModelState.IsValid)
            {
                db.Vaccines.Add(vaccine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vaccine);
        }

        // GET: /Vaccine/Edit/5
        [Authorize(Roles = "Admin, Executive, ProgramStaff")]
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaccine vaccine = db.Vaccines.Find(id);
            if (vaccine == null)
            {
                return HttpNotFound();
            }
            return View(vaccine);
        }

        // POST: /Vaccine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Executive, ProgramStaff")]
        public ActionResult Edit([Bind(Include="ID,vaccineID,vaccineName,dateReceived,CPT,ICD9Code,NDC,leadTime,lotNumber,numofDoses,salesPrice,expDate")] Vaccine vaccine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaccine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vaccine);
        }

        // GET: /Vaccine/Delete/5
        [Authorize(Roles = "Admin, Executive, ProgramStaff")]
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaccine vaccine = db.Vaccines.Find(id);
            if (vaccine == null)
            {
                return HttpNotFound();
            }
            return View(vaccine);
        }

        // POST: /Vaccine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Executive, ProgramStaff")]
        public ActionResult DeleteConfirmed(int id)
        {
            Vaccine vaccine = db.Vaccines.Find(id);
            db.Vaccines.Remove(vaccine);
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
