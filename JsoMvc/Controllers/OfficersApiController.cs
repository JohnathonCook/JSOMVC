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
    public class OfficersApiController : ApiController
    {
        private JsoMvcDB db = new JsoMvcDB();

        // GET: api/OfficersApi
        public IQueryable<Officer> GetOfficers()
        {
            return db.Officers;
        }

        // GET: api/OfficersApi/5
        [ResponseType(typeof(Officer))]
        public IHttpActionResult GetOfficer(int id)
        {
            Officer officer = db.Officers.Find(id);
            if (officer == null)
            {
                return NotFound();
            }

            return Ok(officer);
        }

        // PUT: api/OfficersApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOfficer(int id, Officer officer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != officer.OfficerId)
            {
                return BadRequest();
            }

            db.Entry(officer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficerExists(id))
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

        // POST: api/OfficersApi
        [ResponseType(typeof(Officer))]
        public IHttpActionResult PostOfficer(Officer officer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Officers.Add(officer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = officer.OfficerId }, officer);
        }

        // DELETE: api/OfficersApi/5
        [ResponseType(typeof(Officer))]
        public IHttpActionResult DeleteOfficer(int id)
        {
            Officer officer = db.Officers.Find(id);
            if (officer == null)
            {
                return NotFound();
            }

            db.Officers.Remove(officer);
            db.SaveChanges();

            return Ok(officer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OfficerExists(int id)
        {
            return db.Officers.Count(e => e.OfficerId == id) > 0;
        }
    }
}