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
using VehiclesApi.Models;

namespace VehiclesApi.Controllers
{
    public class VehicleController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Vehicle
        public IQueryable<vehiclenew> Getvehiclenews()
        {
            return db.vehiclenews;
        }

        // GET: api/Vehicle/5
        [ResponseType(typeof(vehiclenew))]
        public IHttpActionResult Getvehiclenew(int id)
        {
            vehiclenew vehiclenew = db.vehiclenews.Find(id);
            if (vehiclenew == null)
            {
                return NotFound();
            }

            return Ok(vehiclenew);
        }

        // PUT: api/Vehicle/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putvehiclenew(int id, vehiclenew vehiclenew)
        {
            

            if (id != vehiclenew.Id)
            {
                return BadRequest();
            }

            db.Entry(vehiclenew).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vehiclenewExists(id))
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

        // POST: api/Vehicle
        [ResponseType(typeof(vehiclenew))]
        public IHttpActionResult Postvehiclenew(vehiclenew vehiclenew)
        {
            
            db.vehiclenews.Add(vehiclenew);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vehiclenew.Id }, vehiclenew);
        }

        // DELETE: api/Vehicle/5
        [ResponseType(typeof(vehiclenew))]
        public IHttpActionResult Deletevehiclenew(int id)
        {
            vehiclenew vehiclenew = db.vehiclenews.Find(id);
            if (vehiclenew == null)
            {
                return NotFound();
            }

            db.vehiclenews.Remove(vehiclenew);
            db.SaveChanges();

            return Ok(vehiclenew);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vehiclenewExists(int id)
        {
            return db.vehiclenews.Count(e => e.Id == id) > 0;
        }
    }
}