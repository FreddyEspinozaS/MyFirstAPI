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
using System.Web.Security;
using BikeRent.Models;
using BikeRent.Models.AppEntities;


namespace BikeRent.Controllers
{
    public class VetsController : ApiController
    {

        //[Authorize]
        //public string GetSecure()
        //{
        //    return "Acces Garanted!";
        //}

        
        private VetUPCEntities db = new VetUPCEntities();
        [Authorize]
        // GET: api/Vets
        public IQueryable<AppVet> GetVet()
        {
            var query = from v in db.Vet
                        select new AppVet
                        {
                            Address = v.Address,
                            ID = v.ID,
                            LocationX = v.LocationX,
                            LocationY = v.LocationY,
                            Name = v.Name
                        };
            return query;
        }

        // GET: api/Vets/5
        [ResponseType(typeof(Vet))]
        public IHttpActionResult GetVet(int id)
        {
            Vet vet = db.Vet.Find(id);
            if (vet == null)
            {
                return NotFound();
            }

            return Ok(vet);
        }

        // PUT: api/Vets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVet(int id, Vet vet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vet.ID)
            {
                return BadRequest();
            }

            db.Entry(vet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VetExists(id))
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

        // POST: api/Vets
        [ResponseType(typeof(Vet))]
        public IHttpActionResult PostVet(Vet vet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vet.Add(vet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vet.ID }, vet);
        }

        // DELETE: api/Vets/5
        [ResponseType(typeof(Vet))]
        public IHttpActionResult DeleteVet(int id)
        {
            Vet vet = db.Vet.Find(id);
            if (vet == null)
            {
                return NotFound();
            }

            db.Vet.Remove(vet);
            db.SaveChanges();

            return Ok(vet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VetExists(int id)
        {
            return db.Vet.Count(e => e.ID == id) > 0;
        }
    }
}