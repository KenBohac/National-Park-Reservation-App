using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using System.Data.SqlClient;
using Capstone.Models;

namespace Capstone.CLI
{
    public class ReservationMenu
    {
        public Reservation reservation = new Reservation(); 

        public CampgroundMenu CM {get;}


        public ReservationMenu (CampgroundMenu cm)
        {
            this.CM = cm;
            
        }

        public void Run()
        {
            while (true)
            {
                SearchDate();
                reservation.SiteId = CLIHelper.GetInteger("What is the site ID you would like to reserve:");
                reservation.Name = CLIHelper.GetString("What is your name");
                int confirmation = CM.ParkService.CreateReservation(this.reservation);
                if (confirmation > 0)
                {
                    Console.WriteLine($"Your confirmation number is {confirmation}");
                    break;
                }
                else
                {
                    Console.WriteLine($"Your reservation failed to create.");
                    Console.WriteLine($"Press any key to continue");
                    Console.ReadKey();
                }
            }

        }
        public void SearchDate()
        {
            Console.WriteLine("Please enter the campground id, your expected arrival date, and your departure date?");
            Console.WriteLine("Enter the park campground ID:");
            int campground = int.Parse(Console.ReadLine());
            this.reservation.FromDate = CLIHelper.GetDateTime("Enter arrival date: YYYY-MM-DD");
            this.reservation.ToDate = CLIHelper.GetDateTime("Enter the date of the day you are leaving: YYYY-MM-DD");

            if (this.CM.ParkService.CheckForOpen(campground, this.reservation.FromDate, this.reservation.ToDate))
            {
                IList<Site> openSites = this.CM.ParkService.SearchForOpenSites(campground, this.reservation.FromDate, this.reservation.ToDate);
                decimal cost = this.CM.ParkService.GetCampground(campground).DailyFee;
                int stayLength = this.CM.ParkService.CalculateStay(this.reservation.FromDate, this.reservation.ToDate);
                decimal total = cost * stayLength;
                Console.WriteLine("Site No.".PadRight(20) + "Max occupancy".PadRight(20) + "Accessible?".PadRight(20) + "RV Length".PadRight(20) + "Utility".PadRight(20) + "Cost of Stay");
                foreach (Site site in openSites)
                {
                    Console.WriteLine(site.SiteNumber.ToString().PadRight(20) + site.MaxOccupancy.ToString().PadRight(20) + site.Accessible.ToString().PadRight(20) + site.MaxRVLength.ToString().PadRight(20) + site.Utilities.ToString().PadRight(20) + "$" + total.ToString());
                }
            }
            else Console.WriteLine("Please try again with another date, we're booked!");

            
        }




    }
}
