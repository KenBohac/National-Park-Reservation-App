using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;
using System.Data.SqlClient;



namespace Capstone.DAL
{
    
    public class SiteSqlDAO : ISiteDAO
    {
        private string connectionString;

        public SiteSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Site> GetAllSites(int campgroundId)
        {
            List<Site> sites = new List<Site>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM site WHERE campground_id = @campgroundid");
                    cmd.Parameters.AddWithValue("@campgroundid", campgroundId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Site site = ConvertReaderToSite(reader);
                        sites.Add(site);
                    }
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine("An error occured while reading sites");
                Console.WriteLine(ex.Message);
            }
            return sites;
        }

        private Site ConvertReaderToSite(SqlDataReader reader)
        {
            Site site = new Site();
            site.SiteId = Convert.ToInt32(reader["site_id"]);
            site.CampgroundId = Convert.ToInt32(reader["campground_id"]);
            site.SiteNumber = Convert.ToInt32(reader["site_number"]);
            site.MaxOccupancy = Convert.ToInt32(reader["max_occupancy"]);
            site.Accessible = Convert.ToBoolean(reader["accessible"]);
            site.MaxRVLength = Convert.ToInt32(reader["max_rv_length"]);
            site.Utilities = Convert.ToBoolean(reader["utilities"]);

            return site;
        }
        public Site GetSite(int siteId)
        {

            Site site = new Site();
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM site WHERE site_id = @siteId", conn);
                    cmd.Parameters.AddWithValue("@siteId", siteId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        site = ConvertReaderToSite(reader);
                    }

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error has occured in getting your site");
                Console.WriteLine(ex.Message);
            }
            return site;
        }
        public IList<Site> SearchForOpenSites(int campgroundId, DateTime startDate, DateTime endDate)
        {
            IList<Site> openSites = new List<Site>();

            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = @"SELECT TOP 5 * FROM site 
                                WHERE site.site_id NOT IN 
                                (SELECT reservation.site_id FROM reservation 
                                WHERE @StartDate BETWEEN reservation.from_date 
                                AND reservation.to_date OR @EndDate between reservation.from_date AND reservation.to_date)
                                AND @campgroundId = site.campground_id;";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@campgroundId", campgroundId);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Site openSite = ConvertReaderToSite(reader);
                        openSites.Add(openSite);
                    }

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error has occured in getting your reservation");
                Console.WriteLine(ex.Message);
            }
            return openSites;
        }
    }
}
