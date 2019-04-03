using System;
using Capstone.Models;



namespace Capstone.CLI
{
    public class CampgroundMenu
    {

        public MainMenu MM { get; }
        public ParkService ParkService { get; }

        

        public CampgroundMenu(MainMenu mm)
        {
            this.MM = mm;
            this.ParkService = this.MM.ParkService;
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
                    ReservationMenu rm = new ReservationMenu(this);
                    rm.Run();
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
