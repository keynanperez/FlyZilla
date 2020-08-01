using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;

namespace FlyZilla.Models
{
    public class DBservices
    {
        public SqlDataAdapter da;
        public DataTable dt;

        public DBservices()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public string check(string name_table)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            String cStr = "select * from " + name_table;
            // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                string numEffected = (string)cmd.ExecuteScalar(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                return "";
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }

        //--------------------------------------------------------------------------------------------------
        // This method creates a connection to the database according to the connectionString name in the web.config 
        //--------------------------------------------------------------------------------------------------
        public SqlConnection connect(String conString)
        {

            // read the connection string from the configuration file
            string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }

        //--------------------------------------------------------------------------------------------------
        // get Users
        //--------------------------------------------------------------------------------------------------

public List<Manager> getDiscounts()
        {
            List<Manager> discList = new List<Manager>();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create the connection
                String selectSTR = "SELECT * FROM Discounts_CS";
                SqlCommand cmd = new SqlCommand(selectSTR, con);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while(dr.Read())
                {
                    Manager m = new Manager();
                    string dis = dr["DiscountsId"].ToString();
                    m.DiscountsId = dis;
                    m.AirlineName = (string)dr["AirlineName"];
                    m.FromCity = (string)dr["FromCity"];
                    m.ToCity = (string)dr["ToCity"];
                    m.StartAt = (string)dr["StartAt"];
                    m.EndAt = (string)dr["EndAt"];
                    m.Discount = (string)dr["Discount"];
                    discList.Add(m);
                }
                return discList;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con!= null)
                {
                    con.Close();
                }
            }
        }

        public List<User> getUsers()
        {
            List<User> userList = new List<User>();
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString"); // create the connection
                String selectSTR = "SELECT * FROM Users_CS";
                SqlCommand cmd = new SqlCommand(selectSTR, con);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    User u = new User();
                    u.MainName = (string)dr["MainName"];
                    u.PassengersNames = (string)dr["PassengersNames"];
                    u.Email = (string)dr["Email"];
                    u.BookingTime = (string)dr["BookingTime"];
                    u.TakeoffAirport = (string)dr["TakeoffAirport"];
                    u.LandingAirport = (string)dr["LandingAirport"];


                    userList.Add(u);
                }
                return userList;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

























        //********************************************************************************* User

        public int insertUS(User u)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildInsertCommandUS(u);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {

                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        private String BuildInsertCommandUS(User m)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            //use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}' ,'{2}', '{3}', '{4}', '{5}')", m.MainName, m.PassengersNames, m.Email, m.BookingTime, m.TakeoffAirport, m.LandingAirport);
            String prefix = "INSERT INTO Users_CS " + "(MainName, PassengersNames, Email, BookingTime, TakeoffAirport, LandingAirport) ";
            command = prefix + sb.ToString();
            return command;
        }

        //--------------------------------------------------------------------------------------------------
        // This method inserts a to the table 
        //--
        //********************************************************************************* Discount

        public int insertDS(Manager m)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildInsertCommandDS(m);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {

                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        private String BuildInsertCommandDS(Manager m)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            //use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}' ,'{1}', '{2}', '{3}', '{4}', '{5}')", m.AirlineName, m.FromCity, m.ToCity, m.StartAt, m.EndAt, m.Discount);
            String prefix = "INSERT INTO Discounts_CS " + "(AirlineName, FromCity, ToCity, StartAt, EndAt, Discount) ";
            command = prefix + sb.ToString();
            return command;
        }
        public string deleteDiscount(string discountId)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);

            }

            String cStr = "DELETE FROM Discounts_CS where DiscountsId = " + discountId + "";      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                string numEffected = (string)cmd.ExecuteScalar(); // execute the command

                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }

        public string editDiscount(Manager discount)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);

            }

            String cStr = "UPDATE Discounts_CS set AirlineName = '" + discount.AirlineName + "', FromCity = '" + discount.FromCity + "', ToCity = '" + discount.ToCity + "', StartAt = '" + discount.StartAt + "', EndAt='" + discount.EndAt + "', Discount = " + discount.Discount + " where DiscountsId = " + discount.DiscountsId;      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                string numEffected = (string)cmd.ExecuteScalar(); // execute the command

                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }

        ////********************************************************************************* LEG
        //public int insertLG(Leg l)
        //{

        //    SqlConnection con;
        //    SqlCommand cmd;

        //    try
        //    {
        //        con = connect("DBConnectionString"); // create the connection
        //    }
        //    catch (Exception ex)
        //    {
        //        // write to log
        //        throw (ex);
        //    }

        //    String cStr = BuildInsertCommandLG(l);      // helper method to build the insert string

        //    cmd = CreateCommand(cStr, con);             // create the command

        //    try
        //    {
        //        int numEffected = cmd.ExecuteNonQuery(); // execute the command
        //        return numEffected;
        //    }
        //    catch (Exception ex)
        //    {

        //        // write to log
        //        throw (ex);
        //    }

        //    finally
        //    {
        //        if (con != null)
        //        {
        //            // close the db connection
        //            con.Close();
        //        }
        //    }

        //}


        //private String BuildInsertCommandLG(Leg l)
        //{
        //    String command;

        //    StringBuilder sb = new StringBuilder();
        //    //use a string builder to create the dynamic string
        //    sb.AppendFormat("Values('{0}', '{1}' ,'{2}', '{3}', '{4}', '{5}', '{6}', '{7}','{8}', '{9}')", l.LegId, l.LegPath, l.LegNumber, l.FlightNumber, l.TakeoffAirport, l.LandingAirport, l.AirlineId, l.TakeoffTime, l.LandingTime, l.FlightDuration);
        //    String prefix = "INSERT INTO Legs_CS " + "(LegId, LegPath, LegNumber, FlightNumber, LegTakeoffAirport, LegLandingAirport, LegAirlineId, TakeoffTime, LandingTime, FlightDuration) ";
        //    command = prefix + sb.ToString();
        //    return command;
        //}





        public int insertAP(Airport[] airports)
        {
            int numEffected = 0;
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            for (int i = 0; i < airports.Length; i++)
            {
                String cStr = BuildInsertCommand(airports[i]);      // helper method to build the insert string

                cmd = CreateCommand(cStr, con);             // create the command
                try
                {
                    numEffected = cmd.ExecuteNonQuery(); // execute the command

                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
            return numEffected;
        }
        private String BuildInsertCommand(Airport airport)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            //use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}' ,'{2}', '{3}', '{4}', '{5}')", airport.AirportId, airport.AirportName, airport.Longitude, airport.Latitude, airport.AirportCity, airport.AirportCountry);
            String prefix = "INSERT INTO Airports_CS " + "(AirportId, AirportName, Longitude, Latitude, AirportCity, AirportCountry) ";
            command = prefix + sb.ToString();
            return command;
        }

        private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 30;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

            return cmd;
        }
        //************************************************************************************************** flight
        public int insertFL(Flight flight)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildInsertCommandFL(flight);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {

                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        private String BuildInsertCommandFL(Flight flight)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}' ,'{2}', '{3}', '{4}', '{5}','{6}','{7}' )", flight.FlightPath, flight.TakeoffAirport, flight.LandingAirport, flight.FlightAirline, flight.TakeoffTime, flight.LandingTime, flight.FlightDuration, flight.Price.ToString() );
            String prefix = "INSERT INTO MyFlights_CS " + "(FlightPath,TakeoffAirport,LandingAirport,FlightAirline,TakeoffTime,LandingTime,FlightDuration,Price) ";
            command = prefix + sb.ToString();

            return command;
        }

        //******************************************************************** Airline

        public int insertAL(Airline[] airlines)
        {
            int numEffected = 0;
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            for (int i = 0; i < airlines.Length; i++)
            {
                String cStr = BuildInsertCommandAL(airlines[i]);      // helper method to build the insert string

                cmd = CreateCommand(cStr, con);             // create the command
                try
                {
                    numEffected = cmd.ExecuteNonQuery(); // execute the command

                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
            return numEffected;
        }
        private String BuildInsertCommandAL(Airline airline)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            //use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}')", airline.AirlineId, airline.AirlineName);
            String prefix = "INSERT INTO Airlines_CS " + "(AirlineId, AirlineName) ";
            command = prefix + sb.ToString();
            return command;
        }

    }
}
