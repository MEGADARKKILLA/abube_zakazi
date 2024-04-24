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
    public class ТранспортController : ApiController
    {
        private ЗаказыEntities db = new ЗаказыEntities();

        // GET: api/Транспорт
        public IQueryable<Транспорт> GetТранспорт()
        {
            return db.Транспорт;
        }

        // GET: api/Транспорт/5
        
        [ResponseType(typeof(Транспорт))]
        public IHttpActionResult GetТранспорт(int id)
        {
            Транспорт транспорт = db.Транспорт.Find(id);
            if (транспорт == null)
            {
                return NotFound();
            }

            return Ok(транспорт);
        }

        // PUT: api/Транспорт/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutТранспорт(int id, Транспорт транспорт)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != транспорт.id_Транспорта)
            {
                return BadRequest();
            }

            db.Entry(транспорт).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ТранспортExists(id))
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

        // POST: api/Транспорт
        [ResponseType(typeof(Транспорт))]
        public IHttpActionResult PostТранспорт(Транспорт транспорт)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Транспорт.Add(транспорт);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ТранспортExists(транспорт.id_Транспорта))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = транспорт.id_Транспорта }, транспорт);
        }

        // DELETE: api/Транспорт/5
        [ResponseType(typeof(Транспорт))]
        public IHttpActionResult DeleteТранспорт(int id)
        {
            Транспорт транспорт = db.Транспорт.Find(id);
            if (транспорт == null)
            {
                return NotFound();
            }

            db.Транспорт.Remove(транспорт);
            db.SaveChanges();

            return Ok(транспорт);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ТранспортExists(int id)
        {
            return db.Транспорт.Count(e => e.id_Транспорта == id) > 0;
        }
    }
}