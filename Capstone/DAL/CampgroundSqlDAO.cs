using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Models;
using System.Data.SqlClient;


namespace Capstone.DAL
{
    public class CampgroundSqlDAO : ICampgroundDAO
    {
        private string connectionString;
        public CampgroundSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;

        }
        public IList<Campground> GetAllCampgrounds(int parkId)
        {
            List<Campground> campgrounds = new List<Campground>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM campground WHERE park_id =@parkId;", conn);
                    cmd.Parameters.AddWithValue("@parkId", parkId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Campground campground = ConvertReaderToCampground(reader);
                        campgrounds.Add(campground);
                    }

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occured while searching camgrounds.");
                Console.WriteLine(ex.Message);
            }
            return campgrounds;


        }
        private Campground ConvertReaderToCampground(SqlDataReader reader)
        {
            Campground campground = new Campground();
            campground.CampgroundId = Convert.ToInt32(reader["campground_id"]);
            campground.ParkId = Convert.ToInt32(reader["park_id"]);
            campground.Name = Convert.ToString(reader["name"]);
            campground.OpenFromMM = Convert.ToInt32(reader["open_from_mm"]);
            campground.OpenToMM = Convert.ToInt32(reader["open_to_mm"]);
            campground.DailyFee = Convert.ToDecimal(reader["daily_fee"]);

            return campground;
        }
        public Campground GetCampground(int campground_id)
        {

            Campground campground = new Campground();
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM campground WHERE campground_id = @campground_id", conn);
                    cmd.Parameters.AddWithValue("@campground_id", campground_id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        campground = ConvertReaderToCampground(reader);

                    }

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occured while searching camgrounds.");
                Console.WriteLine(ex.Message);
            }
            return campground;

        }
    }

}
