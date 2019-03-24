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
    public class JsoCaseManagersApiController : ApiController
    {
        private JsoMvcDB db = new JsoMvcDB();

        // GET: api/JsoCaseManagersApi
        public IQueryable<JsoCaseManager> GetJsoCaseManagers()
        {
            return db.JsoCaseManagers;
        }

        // GET: api/JsoCaseManagersApi/5
        [ResponseType(typeof(JsoCaseManager))]
        public IHttpActionResult GetJsoCaseManager(int id)
        {
            JsoCaseManager jsoCaseManager = db.JsoCaseManagers.Find(id);
            if (jsoCaseManager == null)
            {
                return NotFound();
            }

            return Ok(jsoCaseManager);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JsoCaseManagerExists(int id)
        {
            return db.JsoCaseManagers.Count(e => e.CaseId == id) > 0;
        }
    }
}