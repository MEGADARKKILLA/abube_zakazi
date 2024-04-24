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
using transport_API;

namespace transport_API.Controllers
{
    public class КлиентController : ApiController
    {
        private ЗаказыEntities db = new ЗаказыEntities();

        // GET: api/Клиент
        public IQueryable<Клиент> GetКлиент()
        {
            return db.Клиент;
        }

        // GET: api/Клиент/5
        [ResponseType(typeof(Клиент))]
        public IHttpActionResult GetКлиент(int id)
        {
            Клиент клиент = db.Клиент.Find(id);
            if (клиент == null)
            {
                return NotFound();
            }

            return Ok(клиент);
        }

        // PUT: api/Клиент/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutКлиент(int id, Клиент клиент)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != клиент.id_Клиента)
            {
                return BadRequest();
            }

            db.Entry(клиент).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!КлиентExists(id))
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

        // POST: api/Клиент
        [ResponseType(typeof(Клиент))]
        public IHttpActionResult PostКлиент(Клиент клиент)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Клиент.Add(клиент);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (КлиентExists(клиент.id_Клиента))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = клиент.id_Клиента }, клиент);
        }

        // DELETE: api/Клиент/5
        [ResponseType(typeof(Клиент))]
        public IHttpActionResult DeleteКлиент(int id)
        {
            Клиент клиент = db.Клиент.Find(id);
            if (клиент == null)
            {
                return NotFound();
            }

            db.Клиент.Remove(клиент);
            db.SaveChanges();

            return Ok(клиент);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool КлиентExists(int id)
        {
            return db.Клиент.Count(e => e.id_Клиента == id) > 0;
        }
    }
}