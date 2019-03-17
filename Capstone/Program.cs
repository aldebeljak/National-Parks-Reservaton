using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Capstone.DAL;
using Capstone.CLI;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the connection string from the appsettings.json file
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("Project");

            Menu menu = new Menu(connectionString);

            ViewParksMenu vpm = new ViewParksMenu(connectionString);
            vpm.Display();
        }
    }
}
