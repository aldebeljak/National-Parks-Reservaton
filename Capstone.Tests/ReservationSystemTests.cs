using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.DAL;
using System.Transactions;
using System.IO;
using System.Data.SqlClient;
using System;

namespace Capstone.Tests
{
    [TestClass]
    public class ReservationSystemTests
    {
        protected string ConnectionString { get; } = "Server=.\\SQLEXPRESS;Database=npcampground;Trusted_Connection=True;";
        protected int NewReservationId { get; private set; }
        protected int CampsiteId { get; private set; }
        protected int CampgroundId { get; private set; }
        protected int ParkId { get; private set; }
        protected int ParkCount { get; private set; }
        protected int CampgroundCount { get; private set; }
        protected int CampsiteCount { get; private set; }
        protected int NewOpenFrom { get; private set; }
        protected int NewOpenTo { get; private set; }
        protected int NewCampgroundId { get; private set; }

        private TransactionScope transaction;

        [TestInitialize]
        public void Setup()
        {
            this.transaction = new TransactionScope();

            string sql = File.ReadAllText("test-script.sql");
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    this.NewReservationId = Convert.ToInt32(reader["newReservationId"]);
                    this.CampsiteId = Convert.ToInt32(reader["campsiteId"]);
                    this.CampgroundId = Convert.ToInt32(reader["campgroundId"]);
                    this.ParkId = Convert.ToInt32(reader["parkId"]);
                    this.ParkCount = Convert.ToInt32(reader["parkCount"]);
                    this.CampgroundCount = Convert.ToInt32(reader["campgroundCount"]);
                    this.CampsiteCount = Convert.ToInt32(reader["campsiteCount"]);
                    this.NewOpenFrom = Convert.ToInt32(reader["newOpenFrom"]);
                    this.NewOpenTo = Convert.ToInt32(reader["newOpenTo"]);
                    this.NewCampgroundId = Convert.ToInt32(reader["newCampgroundId"]);
                }
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.transaction.Dispose();
        }
    }
}
