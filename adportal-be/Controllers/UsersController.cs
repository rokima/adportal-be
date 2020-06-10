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
        public IEnumerable<User> Get()
        {
            return adportalDbContext.Users;
        }

        // GET: api/Users/5
        public User Get(int id)
        {
            var user = adportalDbContext.Users.Find(id);
            return user;
        }

        // POST: api/Users
        public void Post([FromBody]User user)
        {
            adportalDbContext.Users.Add(user);
            adportalDbContext.SaveChanges();
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]User user)
        {
            var entity = adportalDbContext.Users.FirstOrDefault(u => u.Id == id);
            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            entity.Login = user.Login;
            entity.Email = user.Email;
            entity.Password = user.Password;
            entity.Country = user.Country;
            entity.City = user.City;
            entity.Address = user.Address;
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
            var user = adportalDbContext.Users.Find(id);
            adportalDbContext.Users.Remove(user);
            adportalDbContext.SaveChanges();
        }
    }
}
