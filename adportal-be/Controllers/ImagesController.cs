using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using adportal_be.Models;
using adportal_be.Data;

namespace adportal_be.Controllers
{
    public class ImagesController : ApiController
    {
        AdPortalDbContext adPortalDbContext = new AdPortalDbContext();
        // GET: api/Images
        public IHttpActionResult Get()
        {
            var images = adPortalDbContext.Images;
            return Ok(images);
        }

        // GET: api/Images/5
        public IHttpActionResult Get(int id)
        {
            var image = adPortalDbContext.Images.Find(id);
            if(image == null)
            {
                return BadRequest("Image with such id not found");
            }
            return Ok(image);
        }

        // POST: api/Images
        public IHttpActionResult Post([FromBody]Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            adPortalDbContext.Images.Add(image);
            return StatusCode(HttpStatusCode.Created);
        }

        // PUT: api/Images/5
        public IHttpActionResult Put(int id, [FromBody]Image image)
        {
            var entity = adPortalDbContext.Images.FirstOrDefault(i => i.Id == id);
            if (entity == null)
            {
                return BadRequest("No image with such id found");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            entity.FileName = image.FileName;
            entity.ImageUrl = image.ImageUrl;
            return Ok(entity);
        }

        // DELETE: api/Images/5
        public IHttpActionResult Delete(int id)
        {
            var image = adPortalDbContext.Images.Find(id);
            if (image == null)
            {
                return BadRequest("No image with such id found");
            }
            adPortalDbContext.Images.Remove(image);
            adPortalDbContext.SaveChanges();
            return Ok("Image deleted!");
        }
    }
}
