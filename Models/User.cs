using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyZilla.Models
{
    public class User
    {
        string mainName;
        string passengersNames;
        string email;
        string bookingTime;
        string takeoffAirport;
        string landingAirport;

        public User(string mainName, string passengersNames, string email, string bookingTime, string takeoffAirport, string landingAirport)
        {
            this.mainName = mainName;
            this.passengersNames = passengersNames;
            this.email = email;
            this.bookingTime = bookingTime;
            this.takeoffAirport = takeoffAirport;
            this.landingAirport = landingAirport;
        }

        public User()
        {
        }

        public string MainName { get => mainName; set => mainName = value; }
        public string PassengersNames { get => passengersNames; set => passengersNames = value; }
        public string Email { get => email; set => email = value; }
        public string BookingTime { get => bookingTime; set => bookingTime = value; }
        public string TakeoffAirport { get => takeoffAirport; set => takeoffAirport = value; }
        public string LandingAirport { get => landingAirport; set => landingAirport = value; }

        public int insert()
        {
            DBservices dbs = new DBservices();
            dbs.insertUS(this);
            return 0;
        }

        public List<User> getUsers()
        {
            DBservices dbs = new DBservices();
            return dbs.getUsers();
        }
    }
}