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
    public class ЗаказController : ApiController
    {
        private ЗаказыEntities db = new ЗаказыEntities();

        // GET: api/Заказ
        public IQueryable<Заказ> GetЗаказ()
        {
            return db.Заказ;
        }

        // GET: api/Заказ/5
        [ResponseType(typeof(Заказ))]
        public IHttpActionResult GetЗаказ(int id)
        {
            Заказ заказ = db.Заказ.Find(id);
            if (заказ == null)
            {
                return NotFound();
            }

            return Ok(заказ);
        }

        // PUT: api/Заказ/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutЗаказ(int id, Заказ заказ)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != заказ.id_заказа)
            {
                return BadRequest();
            }

            db.Entry(заказ).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ЗаказExists(id))
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

        // POST: api/Заказ
        [ResponseType(typeof(Заказ))]
        public IHttpActionResult PostЗаказ(Заказ заказ)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Заказ.Add(заказ);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ЗаказExists(заказ.id_заказа))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = заказ.id_заказа }, заказ);
        }

        // DELETE: api/Заказ/5
        [ResponseType(typeof(Заказ))]
        public IHttpActionResult DeleteЗаказ(int id)
        {
            Заказ заказ = db.Заказ.Find(id);
            if (заказ == null)
            {
                return NotFound();
            }

            db.Заказ.Remove(заказ);
            db.SaveChanges();

            return Ok(заказ);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ЗаказExists(int id)
        {
            return db.Заказ.Count(e => e.id_заказа == id) > 0;
        }
    }
}