using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;
using Capstone.DAL;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;


namespace Capstone.CLI
{
    public class CampgroundMenu
    {
        public MainMenu MM { get; }

        public CampgroundMenu(MainMenu mm)
        {
            this.MM = mm; 
        }
        
        public void Run()
        {
            while (true)
            {

                Console.WriteLine("Campground Menu");
                Console.WriteLine();
                Console.WriteLine("1 ) View Campgrounds");
                Console.WriteLine("2 ) Search Sites for Open Date");
                Console.WriteLine("3 ) Return to Previous Screen");
                Console.WriteLine();
                Console.WriteLine("Enter your choice:");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("View campsites by Park Id. Enter Park Id:");
                    int parkChoice = int.Parse(Console.ReadLine());

                    foreach (Campground campground in MM.ParkService.GetAllCampgrounds(parkChoice))
                    {
                        Console.WriteLine($"Campground ID: {campground.CampgroundId}  Campground: {campground.Name}   Fee: ${campground.DailyFee}");
                    }

                }
                else if (choice == "2")
                {
                    Console.WriteLine("Please enter the campground id, your expected arrival date, and your departure date?");
                    Console.WriteLine("Enter the park campground ID:");
                    int campground = int.Parse(Console.ReadLine());
                    DateTime startDate = CLIHelper.GetDateTime("Enter arrival date: YYYY-MM-DD");
                    DateTime endDate = CLIHelper.GetDateTime("Enter the date of the day you are leaving: YYYY-MM-DD");
                    
                    if (this.MM.ParkService.CheckForOpen(campground, startDate, endDate))
                    {
                        IList<Site> openSites = this.MM.ParkService.SearchForOpenSites(campground, startDate, endDate);
                        decimal cost = this.MM.ParkService.GetCampground(campground).DailyFee;
                        int stayLength = this.MM.ParkService.CalculateStay(startDate, endDate);
                        decimal total = cost * stayLength;
                        Console.WriteLine("Site No.".PadRight(20),"Max occupancy".PadRight(20),"Accessible?".PadRight(20),"RV Length".PadRight(20),"Utility".PadRight(20),"Cost of Stay");
                        foreach (Site site in openSites)
                        {
                            Console.WriteLine(site.SiteNumber.ToString().PadRight(20), site.MaxOccupancy.ToString().PadRight(20), site.Accessible.ToString().PadRight(20),site.MaxRVLength.ToString().PadRight(20), "$"+total.ToString());
                        }
                    }
                    else Console.WriteLine("Please try again with another date, we're booked!");
                }
                else if (choice == "3")
                {
                    MM.Run();

                }
                else
                {
                    Console.WriteLine("Invalid Input. Press any key to continue");
                    Console.ReadKey();

                }
            }
        }
    }
}
