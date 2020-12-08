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
    public class TypesController : ApiController
    {
        //AdPortalDbContext adPortalDbContext = new AdPortalDbContext();
        public AdPortalDbContext adPortalDbContext;
        public TypesController(AdPortalDbContext dbContext)
        {
            if (dbContext is null) dbContext = new AdPortalDbContext();
            adPortalDbContext = dbContext;
        }
        //Get all types
        public IHttpActionResult Get()
        {
            var types = adPortalDbContext.Types;
            return Ok(types);
        }

        //Get type by id
        public IHttpActionResult Get(int id)
        {
            var types = adPortalDbContext.Types.Where(x => x.Id == id).FirstOrDefault();
            //var advertisement = adPortalDbContext.Advertisements.Where(x => x.Id == id).FirstOrDefault();
            if (types == null)
            {
                return BadRequest("No type with such id");
            }
            return Ok(types);

        }

        

    }
}
