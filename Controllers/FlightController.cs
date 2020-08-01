using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlyZilla.Models;

namespace FlyZilla.Controllers
{
    public class FlightController : ApiController
    {
        public IEnumerable<Flight> Get()
        {
            return Flight.FlightList;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]Flight flight)
        {

            flight.insert();

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