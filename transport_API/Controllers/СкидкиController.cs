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
    public class СкидкиController : ApiController
    {
        private ЗаказыEntities db = new ЗаказыEntities();

        // GET: api/Скидки
        public IQueryable<Скидки> GetСкидки()
        {
            return db.Скидки;
        }

        // GET: api/Скидки/5
        [ResponseType(typeof(Скидки))]
        public IHttpActionResult GetСкидки(int id)
        {
            Скидки скидки = db.Скидки.Find(id);
            if (скидки == null)
            {
                return NotFound();
            }

            return Ok(скидки);
        }

        // PUT: api/Скидки/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutСкидки(int id, Скидки скидки)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != скидки.id_скидки)
            {
                return BadRequest();
            }

            db.Entry(скидки).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!СкидкиExists(id))
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

        // POST: api/Скидки
        [ResponseType(typeof(Скидки))]
        public IHttpActionResult PostСкидки(Скидки скидки)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Скидки.Add(скидки);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (СкидкиExists(скидки.id_скидки))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = скидки.id_скидки }, скидки);
        }

        // DELETE: api/Скидки/5
        [ResponseType(typeof(Скидки))]
        public IHttpActionResult DeleteСкидки(int id)
        {
            Скидки скидки = db.Скидки.Find(id);
            if (скидки == null)
            {
                return NotFound();
            }

            db.Скидки.Remove(скидки);
            db.SaveChanges();

            return Ok(скидки);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool СкидкиExists(int id)
        {
            return db.Скидки.Count(e => e.id_скидки == id) > 0;
        }
    }
}