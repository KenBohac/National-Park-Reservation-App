using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;
using Capstone.DAL;
using System.Data.SqlClient;


namespace Capstone.DAL
{


    public class ReservationSqlDAO : IReservationDAO
    {
        private string connectionString;

        public ReservationSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Reservation> GetAllReservations(int siteId)
        {
            List<Reservation> reservations = new List<Reservation>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM site WHERE site_id = @siteId");
                    cmd.Parameters.AddWithValue("@siteId", siteId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Reservation reservation = ConvertReaderToReservation(reader);
                        reservations.Add(reservation);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occured while reading sites");
                Console.WriteLine(ex.Message);
            }
            return reservations;
        }

        private Reservation ConvertReaderToReservation(SqlDataReader reader)
        {
            Reservation reservation = new Reservation();
            reservation.ReservationId = Convert.ToInt32(reader["reservation_id"]);
            reservation.SiteId = Convert.ToInt32(reader["site_id"]);
            reservation.Name = Convert.ToString(reader["name"]);
            reservation.FromDate = Convert.ToDateTime(reader["from_date"]);
            reservation.ToDate = Convert.ToDateTime(reader["to_date"]);
            reservation.CreateDate = Convert.ToDateTime(reader["create_date"]);

            return reservation;
        }
        public Reservation GetReservation(int reservationId)
        {

            Reservation reservation= new Reservation();
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM reservation WHERE reservation_id = @reservationId", conn);
                    cmd.Parameters.AddWithValue("@reservationId", reservationId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                       reservation = ConvertReaderToReservation(reader);
                    }

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error has occured in getting your reservation");
                Console.WriteLine(ex.Message);
            }
            return reservation;


        } public IList <Reservation> SearchForReservation (int campgroundId, DateTime startdate, DateTime endDate)
        {
            IList <Reservation>  reservations  = new List <Reservation>();

            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(, conn);
                    cmd.Parameters.AddWithValue("", );
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Reservation reservation = ConvertReaderToReservation(reader);

                    }

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error has occured in getting your reservation");
                Console.WriteLine(ex.Message);
            }
            return reservations;
        }
            
    }
}


