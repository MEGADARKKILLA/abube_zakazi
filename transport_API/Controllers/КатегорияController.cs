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
    public class КатегорияController : ApiController
    {
        private ЗаказыEntities db = new ЗаказыEntities();

        // GET: api/Категория
        public IQueryable<Категория> GetКатегория()
        {
            return db.Категория;
        }

        // GET: api/Категория/5
        [ResponseType(typeof(Категория))]
        public IHttpActionResult GetКатегория(int id)
        {
            Категория категория = db.Категория.Find(id);
            if (категория == null)
            {
                return NotFound();
            }

            return Ok(категория);
        }

        // PUT: api/Категория/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutКатегория(int id, Категория категория)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != категория.id_Категории)
            {
                return BadRequest();
            }

            db.Entry(категория).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!КатегорияExists(id))
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

        // POST: api/Категория
        [ResponseType(typeof(Категория))]
        public IHttpActionResult PostКатегория(Категория категория)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Категория.Add(категория);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (КатегорияExists(категория.id_Категории))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = категория.id_Категории }, категория);
        }

        // DELETE: api/Категория/5
        [ResponseType(typeof(Категория))]
        public IHttpActionResult DeleteКатегория(int id)
        {
            Категория категория = db.Категория.Find(id);
            if (категория == null)
            {
                return NotFound();
            }

            db.Категория.Remove(категория);
            db.SaveChanges();

            return Ok(категория);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool КатегорияExists(int id)
        {
            return db.Категория.Count(e => e.id_Категории == id) > 0;
        }
    }
}