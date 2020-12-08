using adportal_be.Data;
using adportal_be.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Web.Http;

namespace adportal_be.Controllers
{
    public class UsersController : ApiController
    {

        //AdPortalDbContext adportalDbContext = new AdPortalDbContext();
        public AdPortalDbContext adPortalDbContext;
        public UsersController(AdPortalDbContext dbContext)
        {
            if (dbContext is null) dbContext = new AdPortalDbContext();
            adPortalDbContext = dbContext;
        }

        // GET: api/Users
        public IHttpActionResult Get()
        {
            var users = adPortalDbContext.Users;
            return Ok(users);
        }

        // GET: api/Users/5
        public IHttpActionResult Get(int id)
        {
            var user = adPortalDbContext.Users.Where(x => x.Id == id).FirstOrDefault();
            //var advertisement = adPortalDbContext.Advertisements.Where(x => x.Id == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("No user with such Id found");
            }
            return Ok(user);
        }

        // POST: api/Users
        public IHttpActionResult Post([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var ctx = new AdPortalDbContext())
            { 
                var duplicate = ctx.Users.SqlQuery(
                    "SELECT * FROM Users where Login=@Login", new System.Data.SqlClient.SqlParameter("@Login", user.Login)
                    ).ToList<User>();
                if (duplicate.Count() > 0) {
                    return BadRequest("Duplicate login");
                }
            }
            adPortalDbContext.Users.Add(user);
            adPortalDbContext.SaveChanges();
            return StatusCode(HttpStatusCode.Created);
        }

        // PUT: api/Users/5
        public IHttpActionResult Put(int id, [FromBody] User user)
        {
            var entity = adPortalDbContext.Users.FirstOrDefault(u => u.Id == id);
            if (entity == null)
            {
                return BadRequest("No user with such Id found");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            entity.Login = user.Login;
            entity.Email = user.Email;
            entity.Password = user.Password;
            entity.Country = user.Country;
            entity.City = user.City;
            entity.Address = user.Address;
            return Ok(entity);
        }

        // DELETE: api/Users/5
        public IHttpActionResult Delete(int id)
        {
            var user = adPortalDbContext.Users.Find(id);
            if (user == null)
            {
                return BadRequest("No user with such Id found");
            }
            adPortalDbContext.Users.Remove(user);
            adPortalDbContext.SaveChanges();
            return Ok("User deleted");
        }
    }
}
