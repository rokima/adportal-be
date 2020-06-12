using adportal_be.Data;
using adportal_be.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace adportal_be.Controllers
{
    public class AdvertisementController : ApiController
    {

        AdPortalDbContext adportalDbContext = new AdPortalDbContext();

        // GET: api/Advertisement
        public IHttpActionResult Get(string sort)
        {
            /*IQueryable<Advertisement> advertisements = adportalDbContext.Advertisements.Include("Types");
            switch (sort)
            {
                case "Buy":
                   advertisements = adportalDbContext.Advertisements.Find(a =>  );
            }*/
            var advertisements = adportalDbContext.Advertisements;
            return Ok(advertisements);
        }

        // GET: api/Advertisement/5
        public IHttpActionResult Get(int id)
        {
            var advertisement = adportalDbContext.Advertisements.Find(id);
            if (advertisement == null)
            {
                return BadRequest("No advertisement with such id");
            }
            return Ok(advertisement);
        }

        // POST: api/Advertisement
        public IHttpActionResult Post([FromBody] Advertisement advertisement)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            adportalDbContext.Advertisements.Add(advertisement);
            return StatusCode(HttpStatusCode.Created);
        }

        // PUT: api/Advertisement/5
        public IHttpActionResult Put(int id, [FromBody] Advertisement advertisement)
        {
            var entity = adportalDbContext.Advertisements.FirstOrDefault(a => a.Id == id);
            if(entity == null)
            {
                return BadRequest("No advertisement with such id found");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            entity.Title = advertisement.Title;
            entity.Description = advertisement.Description;
            entity.Price = advertisement.Price;
            entity.Active = advertisement.Active;
            return Ok(entity);
        }

        // DELETE: api/Advertisement/5
        public IHttpActionResult Delete(int id)
        {
            var advertisement = adportalDbContext.Advertisements.Find(id);
            if (advertisement == null)
            {
                return BadRequest("No advertisement with such id found");
            }
            adportalDbContext.Advertisements.Remove(advertisement);
            adportalDbContext.SaveChanges();
            return Ok("Advertisement deleted!");
        }
    }
}
