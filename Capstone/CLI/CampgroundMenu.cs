using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;
using Capstone.DAL;
using System.Data.SqlClient;


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
                        Console.WriteLine($"Park Id: {campground.ParkId}  Campground: {campground.Name}   Fee: ${campground.DailyFee}:C2");
                    }

                }
                else if (choice == "2")
                {
                    Console.WriteLine("We left off here!"); //TODO we're right now
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
