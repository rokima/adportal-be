using adportal_be.Data;
using adportal_be.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace adportal_be.Controllers
{
    public class UsersController : ApiController
    {

        AdPortalDbContext adportalDbContext = new AdPortalDbContext();
        // GET: api/Users
        public IHttpActionResult Get()
        {
            var users = adportalDbContext.Users;
            return StatusCode(HttpStatusCode.OK);
        }

        // GET: api/Users/5
        public IHttpActionResult Get(int id)
        {
            var user = adportalDbContext.Users.Find(id);
            if (user == null)
            {
                return BadRequest("No user with such Id found");
            }
            return StatusCode(HttpStatusCode.OK);
        }

        // POST: api/Users
        public IHttpActionResult Post([FromBody]User user)
        {
            adportalDbContext.Users.Add(user);
            adportalDbContext.SaveChanges();
            return StatusCode(HttpStatusCode.Created);
        }

        // PUT: api/Users/5
        public IHttpActionResult Put(int id, [FromBody] User user)
        {
            var entity = adportalDbContext.Users.FirstOrDefault(u => u.Id == id);
            if (entity == null)
            {
                return BadRequest("No user with such Id found");
            }
            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            entity.Login = user.Login;
            entity.Email = user.Email;
            entity.Password = user.Password;
            entity.Country = user.Country;
            entity.City = user.City;
            entity.Address = user.Address;
            return Ok();
        }

        // DELETE: api/Users/5
        public IHttpActionResult Delete(int id)
        {
            var user = adportalDbContext.Users.Find(id);
            if (user == null)
            {
                return BadRequest("No user with such Id found");
            }
            adportalDbContext.Users.Remove(user);
            adportalDbContext.SaveChanges();
            return Ok("User deleted");
        }
    }
}
