using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyZilla.Models
{
    public class Flight
    {
        private static List<Flight> flightList = new List<Flight>();
        string flightPath;
        string takeoffAirport;
        string landingAirport;
        string flightAirline;
        string takeoffTime;
        string landingTime;
        string flightDuration;
        int price;
        int legs;

        public Flight(string flightPath, string takeoffAirport, string landingAirport, string flightAirline, string takeoffTime, string landingTime, string flightDuration, int price)
        {
            this.flightPath = flightPath;
            this.takeoffAirport = takeoffAirport;
            this.landingAirport = landingAirport;
            this.flightAirline = flightAirline;
            this.takeoffTime = takeoffTime;
            this.landingTime = landingTime;
            this.flightDuration = flightDuration;
            this.price = price;
            
        }

        public static List<Flight> FlightList { get => flightList; set => flightList = value; }
        public string FlightPath { get => flightPath; set => flightPath = value; }
        public string TakeoffAirport { get => takeoffAirport; set => takeoffAirport = value; }
        public string LandingAirport { get => landingAirport; set => landingAirport = value; }
        public string FlightAirline { get => flightAirline; set => flightAirline = value; }
        public string TakeoffTime { get => takeoffTime; set => takeoffTime = value; }
        public string LandingTime { get => landingTime; set => landingTime = value; }
        public string FlightDuration { get => flightDuration; set => flightDuration = value; }
        public int Price { get => price; set => price = value; }
        public int Legs { get => legs; set => legs = value; }
        

        public  int insert()
        {
            DBservices dbs = new DBservices();
            dbs.insertFL(this);
            return 0;
        }
    }
}