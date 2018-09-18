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
using WebApi.Models;

namespace WebApi.Controllers
{
    public class VehicleController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Vehicle
        public IQueryable<vehicle> Getvehicles()
        {
            return db.vehicles;
        }

        // GET: api/Vehicle/5
        [ResponseType(typeof(vehicle))]
        public IHttpActionResult Getvehicle(int id)
        {
            vehicle vehicle = db.vehicles.Find(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        // PUT: api/Vehicle/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putvehicle(int id, vehicle vehicle)
        {


            if (id != vehicle.Id)
            {
                return BadRequest();
            }

            db.Entry(vehicle).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vehicleExists(id))
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
        [ResponseType(typeof(vehicle))]
        public IHttpActionResult Postvehicle(vehicle vehicle)
        {
            

            db.vehicles.Add(vehicle);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vehicle.Id }, vehicle);
        }

        // DELETE: api/Vehicle/5
        [ResponseType(typeof(vehicle))]
        public IHttpActionResult Deletevehicle(int id)
        {
            vehicle vehicle = db.vehicles.Find(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            db.vehicles.Remove(vehicle);
            db.SaveChanges();

            return Ok(vehicle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vehicleExists(int id)
        {
            return db.vehicles.Count(e => e.Id == id) > 0;
        }
    }
}