using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlyZilla.Models;

namespace FlyZilla.Controllers
{
    public class AirportController : ApiController
    {
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        public string Get()
        {
            return Airport.check_insertTable();
        }

        // POST api/<controller>
        public void Post([FromBody]Airport[] a)
        {
            Airport.insert(a);
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