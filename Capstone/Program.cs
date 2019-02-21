using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Data.SqlClient;
using Capstone.Models;
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
            ParkSqlDAO parkDAO = new ParkSqlDAO(connectionString);
            MainMenu mainmenu = new MainMenu(parkDAO);
            mainmenu.Run();

        }
    }
}
