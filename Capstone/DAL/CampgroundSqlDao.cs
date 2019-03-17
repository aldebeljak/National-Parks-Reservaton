using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAL
{
    public class CampgroundSqlDAO : ICampgroundDAO
    {
        public CampgroundSqlDAO(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private string ConnectionString;

        public IList<CampgroundModel> GetCampgrounds(int park_Id)
        {
            List<CampgroundModel> campgrounds = new List<CampgroundModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select * from campground where park_id = @park_id", conn);
                    cmd.Parameters.AddWithValue("@park_id", park_Id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CampgroundModel campground = ConvertReaderToCampground(reader);
                        campgrounds.Add(campground);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error occurred reading campgrounds from database.");
                Console.WriteLine(ex.Message);
                throw;
            }

            return campgrounds;
        }

        private CampgroundModel ConvertReaderToCampground(SqlDataReader reader)
        {
            CampgroundModel campground = new CampgroundModel();

            campground.Campground_Id = Convert.ToInt32(reader["campground_Id"]);
            campground.Park_Id = Convert.ToInt32(reader["park_Id"]);
            campground.Name = Convert.ToString(reader["name"]);
            campground.Open_From_MM = Convert.ToInt32(reader["open_from_mm"]);
            campground.Open_To_MM = Convert.ToInt32(reader["open_to_mm"]);
            campground.Daily_Fee = Convert.ToDecimal(reader["daily_fee"]);

            return campground;
        }

        public bool IsOpen(CampgroundModel campground, DateTime startDate, DateTime endDate)
        {
            return (startDate.Month >= campground.Open_From_MM && startDate.Month <= campground.Open_To_MM && endDate.Month >= campground.Open_From_MM && endDate.Month <= campground.Open_To_MM);
        }
    }
}
