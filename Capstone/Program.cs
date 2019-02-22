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
            IParkDAO parkDAO = new ParkSqlDAO(connectionString);
            ICampgroundDAO campgroundDAO = new CampgroundSqlDAO(connectionString);
            ISiteDAO siteDAO = new SiteSqlDAO(connectionString);
            IReservationDAO reservationDAO = new ReservationSqlDAO(connectionString);
            ParkService ps = new ParkService(parkDAO, campgroundDAO, siteDAO, reservationDAO);

            MainMenu mainmenu = new MainMenu(ps);
            mainmenu.Run();

        }
    }
}
