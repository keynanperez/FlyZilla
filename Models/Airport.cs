using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace FlyZilla.Models
{
    public class Airport
    {
        string airportId;
        string airportName;
        string longitude;
        string latitude;
        string airportCity;
        string airportCountry;

        public Airport(string airportId, string airportName, string longitude, string latitude, string airportCity, string airportCountry)
        {
            this.AirportId = airportId;
            this.AirportName = airportName;
            this.Longitude = longitude;
            this.Latitude = latitude;
            this.AirportCity = airportCity;
            this.AirportCountry = airportCountry;
        }

        public string AirportId { get => airportId; set => airportId = value; }
        public string AirportName { get => airportName; set => airportName = value; }
        public string Longitude { get => longitude; set => longitude = value; }
        public string Latitude { get => latitude; set => latitude = value; }
        public string AirportCity { get => airportCity; set => airportCity = value; }
        public string AirportCountry { get => airportCountry; set => airportCountry = value; }

        public static int insert(Airport[] airports)
        {
            DBservices dbs = new DBservices();
            dbs.insertAP(airports);
            return 0;
        }
        public static string check_insertTable()
        {
            DBservices db = new DBservices();
            return db.check("Airports_CS");

        }
    }
}