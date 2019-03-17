using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Capstone.DAL;
using Capstone.Models;
using Microsoft.Extensions.Configuration;

namespace Capstone.CLI
{
    public class Menu
    {

        public CampsiteSqlDAO CampsiteSqlDAO { get; }

        public CampgroundSqlDAO CampgroundSqlDAO { get; }

        public ReservationSqlDAO ReservationSqlDAO { get; }

        public ParkSqlDAO ParkSqlDAO { get; }

        public Dictionary<int, string> MonthNames { get; } = new Dictionary<int, string>
        {
            {1,"January" },
            {2,"February" },
            {3,"March" },
            {4,"April" },
            {5,"May" },
            {6,"June" },
            {7,"July" },
            {8,"August" },
            {9,"September" },
            {10,"October" },
            {11,"November" },
            {12,"December" }
        };


        public Menu(string connectionString)
        {   
            this.ParkSqlDAO = new ParkSqlDAO(connectionString);
            this.CampgroundSqlDAO = new CampgroundSqlDAO(connectionString);
            this.CampsiteSqlDAO = new CampsiteSqlDAO(connectionString);
            this.ReservationSqlDAO = new ReservationSqlDAO(connectionString);
        }
    }
}
