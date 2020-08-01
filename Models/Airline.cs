using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyZilla.Models
{
    public class Airline
    {
        string airlineId;
        string airlineName;

        public Airline(string airlineId, string airlineName)
        {
            this.AirlineId = airlineId;
            this.AirlineName = airlineName;
        }

        public string AirlineId { get => airlineId; set => airlineId = value; }
        public string AirlineName { get => airlineName; set => airlineName = value; }

        public static int insert(Airline[] airlines)
        {
            DBservices dbs = new DBservices();
            dbs.insertAL(airlines);
            return 0;
        }
        public static string check_insertTable()
        {
            DBservices db = new DBservices();
            return db.check("Airlines_CS");

        }
    }

}