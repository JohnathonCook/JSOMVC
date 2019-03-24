using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using JsoMvc.Models;

namespace JsoMvc.Controllers
{
    public class SuspectsApiController : ApiController
    {
        private JsoMvcDB db = new JsoMvcDB();

        // GET: api/SuspectsApi
        public IQueryable<Suspect> GetSuspects()
        {
            return db.Suspects;
        }

        // GET: api/SuspectsApi/5
        [ResponseType(typeof(Suspect))]
        public IHttpActionResult GetSuspect(int id)
        {
            Suspect suspect = db.Suspects.Find(id);
            if (suspect == null)
            {
                return NotFound();
            }

            return Ok(suspect);
        }

        // PUT: api/SuspectsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSuspect(int id, Suspect suspect)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != suspect.SuspectId)
            {
                return BadRequest();
            }

            db.Entry(suspect).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuspectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SuspectsApi
        [ResponseType(typeof(Suspect))]
        public IHttpActionResult PostSuspect(Suspect suspect)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Suspects.Add(suspect);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = suspect.SuspectId }, suspect);
        }

        // DELETE: api/SuspectsApi/5
        [ResponseType(typeof(Suspect))]
        public IHttpActionResult DeleteSuspect(int id)
        {
            Suspect suspect = db.Suspects.Find(id);
            if (suspect == null)
            {
                return NotFound();
            }

            db.Suspects.Remove(suspect);
            db.SaveChanges();

            return Ok(suspect);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SuspectExists(int id)
        {
            return db.Suspects.Count(e => e.SuspectId == id) > 0;
        }
    }
}