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
    public class SuspectsController : Controller
    {
        private JsoMvcDB db = new JsoMvcDB();

        // GET: Suspects
        public ActionResult Index()
        {
            return View(db.Suspects.ToList());
        }

        // GET: Suspects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suspect suspect = db.Suspects.Find(id);
            if (suspect == null)
            {
                return HttpNotFound();
            }
            return View(suspect);
        }

        // GET: Suspects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suspects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SuspectId,Name,Height,Weight,Race,IdentifyingMarks,SuspectDOB")] Suspect suspect)
        {
            if (ModelState.IsValid)
            {
                db.Suspects.Add(suspect);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suspect);
        }

        // GET: Suspects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suspect suspect = db.Suspects.Find(id);
            if (suspect == null)
            {
                return HttpNotFound();
            }
            return View(suspect);
        }

        // POST: Suspects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SuspectId,Name,Height,Weight,Race,IdentifyingMarks,SuspectDOB")] Suspect suspect)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suspect).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suspect);
        }

        // GET: Suspects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suspect suspect = db.Suspects.Find(id);
            if (suspect == null)
            {
                return HttpNotFound();
            }
            return View(suspect);
        }

        // POST: Suspects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suspect suspect = db.Suspects.Find(id);
            db.Suspects.Remove(suspect);
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
