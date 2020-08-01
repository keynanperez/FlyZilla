using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyZilla.Models
{
    public class Manager
    {
        string discountsId;
        string airlineName;
        string fromCity;
        string toCity;
        string startAt;
        string endAt;
        string discount;

        public Manager(string airportName, string fromCity, string toCity, string startAt, string endAt, string discount)
        {
            //this.discountsId = discountsId;
            this.airlineName = airportName;
            this.fromCity = fromCity;
            this.toCity = toCity;
            this.startAt = startAt;
            this.endAt = endAt;
            this.discount = discount;
        }

        public Manager()
        {
        }
        public string DiscountsId { get => discountsId; set => discountsId = value; }
        public string AirlineName { get => airlineName; set => airlineName = value; }
        public string FromCity { get => fromCity; set => fromCity = value; }
        public string ToCity { get => toCity; set => toCity = value; }
        public string StartAt { get => startAt; set => startAt = value; }
        public string EndAt { get => endAt; set => endAt = value; }
        public string Discount { get => discount; set => discount = value; }

        public int insert()
        {
            DBservices dbs = new DBservices();
            dbs.insertDS(this);
            return 0;
        }
        public List<Manager> getDiscounts()
        {
            DBservices dbs = new DBservices();
            return dbs.getDiscounts();
        }
        public static string deleteDiscount(string id)
        {
            DBservices db = new DBservices();
            return db.deleteDiscount(id);
        }
        public string editDiscout()
        {
            DBservices db = new DBservices();
            return db.editDiscount(this);
        }
    }
}