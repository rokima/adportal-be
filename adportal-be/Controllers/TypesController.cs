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
        AdPortalDbContext adPortalDbContext = new AdPortalDbContext();
        //Get all types
        public IHttpActionResult Get();
        {
            
        }
        

    }
}
