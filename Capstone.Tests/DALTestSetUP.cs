using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using System.Data.SqlClient;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.DAL;
using Capstone.Models;


namespace Capstone.Tests
{
    [TestClass]
    public class DALTestSetUp
    {

        protected string ConnectionString { get; } = "Server=.\\SQLEXPRESS;Database=npcampground;Trusted_Connection=True;";
        protected int ParkId { get; private set; }
        protected int CampgroundId { get; private set; }
        protected int SiteId { get; private set; }
        protected int ReservationId { get; private set; }
        private TransactionScope transaction;

        [TestInitialize]
        public void Setup()

        {
            //Begin Transaction
            transaction = new TransactionScope();

            //Get the SQL script to run
            string sql = File.ReadAllText("sql-script.sql");
            //Execute the script
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();



                {
                    if (reader.Read())
                    {
                        this.ParkId = Convert.ToInt32(reader["parkId"]);
                        this.CampgroundId = Convert.ToInt32(reader["campgroundId"]);
                        this.SiteId = Convert.ToInt32(reader["siteId"]);
                        this.ReservationId = Convert.ToInt32(reader["reservationId"]);
                    }
                }
            }


        }
        [TestCleanup]
        public void Cleanup()
        {
            //Rollback transition
            transaction.Dispose();
        }
        protected int GetRowCount(string table)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM {table}", conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count;
            }
        }
    }
}

