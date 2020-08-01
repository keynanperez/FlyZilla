using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlyZilla.Models;

namespace FlyZilla.Controllers
{
    public class UserController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<User> Get()
        {
            User user = new User();
            return user.getUsers();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]User user)
        {
            user.insert();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}