using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JsoMvc.Models;

namespace JsoMvc.Controllers
{
    public class JsoCaseManagersController : Controller
    {
        private JsoMvcDB db = new JsoMvcDB();

        // GET: JsoCaseManagers
        public ActionResult Index()
        {
            var jsoCaseManagers = db.JsoCaseManagers.Include(j => j.Crime).Include(j => j.Officer).Include(j => j.Suspect);
            return View(jsoCaseManagers.ToList());
        }

        // GET: JsoCaseManagers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JsoCaseManager jsoCaseManager = db.JsoCaseManagers.Find(id);
            if (jsoCaseManager == null)
            {
                return HttpNotFound();
            }
            return View(jsoCaseManager);
        }

        // GET: JsoCaseManagers/Create
        public ActionResult Create()
        {
            ViewBag.CrimeId = new SelectList(db.Crimes, "CrimeId", "CrimeType");
            ViewBag.OfficerId = new SelectList(db.Officers, "OfficerId", "Name");
            ViewBag.SuspectId = new SelectList(db.Suspects, "SuspectId", "Name");
            return View();
        }

        // POST: JsoCaseManagers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CaseId,OfficerId,CrimeId,SuspectId,HoursWorked,Completed")] JsoCaseManager jsoCaseManager)
        {
            if (ModelState.IsValid)
            {
                db.JsoCaseManagers.Add(jsoCaseManager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CrimeId = new SelectList(db.Crimes, "CrimeId", "CrimeType", jsoCaseManager.CrimeId);
            ViewBag.OfficerId = new SelectList(db.Officers, "OfficerId", "Name", jsoCaseManager.OfficerId);
            ViewBag.SuspectId = new SelectList(db.Suspects, "SuspectId", "Name", jsoCaseManager.SuspectId);
            return View(jsoCaseManager);
        }

        // GET: JsoCaseManagers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JsoCaseManager jsoCaseManager = db.JsoCaseManagers.Find(id);
            if (jsoCaseManager == null)
            {
                return HttpNotFound();
            }
            ViewBag.CrimeId = new SelectList(db.Crimes, "CrimeId", "CrimeType", jsoCaseManager.CrimeId);
            ViewBag.OfficerId = new SelectList(db.Officers, "OfficerId", "Name", jsoCaseManager.OfficerId);
            ViewBag.SuspectId = new SelectList(db.Suspects, "SuspectId", "Name", jsoCaseManager.SuspectId);
            return View(jsoCaseManager);
        }

        // POST: JsoCaseManagers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CaseId,OfficerId,CrimeId,SuspectId,HoursWorked,Completed")] JsoCaseManager jsoCaseManager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jsoCaseManager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CrimeId = new SelectList(db.Crimes, "CrimeId", "CrimeType", jsoCaseManager.CrimeId);
            ViewBag.OfficerId = new SelectList(db.Officers, "OfficerId", "Name", jsoCaseManager.OfficerId);
            ViewBag.SuspectId = new SelectList(db.Suspects, "SuspectId", "Name", jsoCaseManager.SuspectId);
            return View(jsoCaseManager);
        }

        // GET: JsoCaseManagers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JsoCaseManager jsoCaseManager = db.JsoCaseManagers.Find(id);
            if (jsoCaseManager == null)
            {
                return HttpNotFound();
            }
            return View(jsoCaseManager);
        }

        // POST: JsoCaseManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JsoCaseManager jsoCaseManager = db.JsoCaseManagers.Find(id);
            db.JsoCaseManagers.Remove(jsoCaseManager);
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
