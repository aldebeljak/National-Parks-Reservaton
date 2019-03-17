using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public class ParkSqlDAO : IParkDAO
    {
        private string ConnectionString;

        // Single Parameter Constructor
        public ParkSqlDAO(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Returns a list of all the parks in the database
        /// </summary>
        /// <returns></returns>
        public IList<ParkModel> GetParks()
        {
            List<ParkModel> parks = new List<ParkModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select * from park", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ParkModel park = ConvertReaderToPark(reader);
                        parks.Add(park);
                    }
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred reading parks.");
                Console.WriteLine(ex.Message);
                throw;
            }

            return parks;
        }

        private ParkModel ConvertReaderToPark(SqlDataReader reader)
        {
            ParkModel park = new ParkModel();
            park.Park_Id = Convert.ToInt32(reader["Park_Id"]);
            park.Name = Convert.ToString(reader["Name"]);
            park.Location = Convert.ToString(reader["Location"]);
            park.Establish_Date = Convert.ToDateTime(reader["Establish_Date"]);
            park.Area = Convert.ToInt32(reader["Area"]);
            park.Visitors = Convert.ToInt32(reader["Visitors"]);
            park.Description = Convert.ToString(reader["Description"]);

            return park;
        }
    }
}
