using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAL
{
    public class ReservationSqlDAO : IReservationDAO
    {
        public ReservationSqlDAO(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private string ConnectionString;

        public int PlaceReservation(string name, int site_Id, DateTime from_Date, DateTime to_Date)
        {
            int reservationId;

            try
            {
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("insert into reservation values (@site_Id, @name, @from_date, @to_date,NULL)", conn);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@from_date", from_Date);
                    cmd.Parameters.AddWithValue("@to_date", to_Date);
                    cmd.Parameters.AddWithValue("@site_Id", site_Id);

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("select @@Identity",conn);
                    reservationId = Convert.ToInt32(cmd.ExecuteScalar());
                 }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error occurred placing reservation");
                Console.WriteLine(ex.Message);
                throw;
            }

            return reservationId;
        }
    }
}
