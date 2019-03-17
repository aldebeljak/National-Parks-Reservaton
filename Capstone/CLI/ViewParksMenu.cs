using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Models;

namespace Capstone.CLI
{
    public class ViewParksMenu : Menu
    {
        public string ConnectionString { get; }

        public ViewParksMenu(string connectionString):base(connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public void Display()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("View Parks");
                Console.WriteLine("----------");
                IList<ParkModel> parks = new List<ParkModel>();
                parks = base.ParkSqlDAO.GetParks();

                for (int i=0; i < parks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {parks[i].Name}");
                }
                Console.WriteLine("Q)uit");
                try
                {
                    Console.WriteLine();
                    Console.Write("Pick a Park: ");
                    string choice = Console.ReadLine();
                    if (choice.ToLower() == "q")
                    {
                        break;
                    }

                    int numChoice = int.Parse(choice);

                    if (numChoice <= parks.Count && numChoice > 0)
                    {
                        ParksInformationMenu pim = new ParksInformationMenu(parks[numChoice - 1], ConnectionString);
                        pim.Display();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry! Try again.");
                        Console.Write("Press any key to continue");
                        Console.ReadKey();
                        continue;
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Invalid entry! Try again.");
                    Console.WriteLine(ex.Message);
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                    continue;
                }
            }
        }
    }
}
