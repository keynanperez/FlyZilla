using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FlyZilla.Models;

namespace FlyZilla.Controllers
{
    public class ManagerController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Manager> Get()
        {
            Manager man = new Manager();
            return man.getDiscounts();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]Manager mng)
        {
            mng.insert();
        }

        // PUT api/<controller>/5
        public void Put([FromBody]Manager dis)
        {
            dis.editDiscout();
        }

        // DELETE api/<controller>/5
        public void Delete([FromBody]string DisID)
        {
            Manager.deleteDiscount(DisID);
        }
    }
}