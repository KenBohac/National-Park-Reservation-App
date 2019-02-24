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

            Reservation reservation = new Reservation();
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


        }
        public int CreateReservation(Reservation reservation)
        {
            int reservationId = 0;

            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO reservation VALUES (@siteId, @name, @from_date, @to_date, @create_date);", conn);
                    cmd.Parameters.AddWithValue("@siteId", reservation.SiteId);
                    cmd.Parameters.AddWithValue("@name", reservation.Name);
                    cmd.Parameters.AddWithValue("@from_date", reservation.FromDate);
                    cmd.Parameters.AddWithValue("@to_date", reservation.ToDate);
                    cmd.Parameters.AddWithValue("@create_date", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("SELECT MAX(reservation_id) from reservation;", conn);

                    reservationId = Convert.ToInt32(cmd.ExecuteScalar());


                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error has occured in getting your reservation");
                Console.WriteLine(ex.Message);
            }
            //reservationId will serve as the user's reservation confirmation number
            return reservationId;

        }
    }
}


