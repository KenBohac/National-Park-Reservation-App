using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Models;
using System.Linq;

namespace Capstone.CLI
{
    public class MainMenu
    {
        private ParkSqlDAO ParkDAO { get; set; }
        public void Run()
        {
            while (true)
            {
                Greeting();
                Console.WriteLine("Please make a selection from the Menu:");

                Console.WriteLine("1) View All Parks");
                Console.WriteLine("2) View Park Details");
                Console.WriteLine("3) Make Reservation");
                Console.WriteLine("4) Quit");
                string choice = Convert.ToString(Console.ReadLine());
                if (choice == "1")
                {
                    Console.Clear();
                    DisplayParks();
                    
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Enter the park id you would like to view");
                    int park = Convert.ToInt32(Console.ReadLine());
                    ViewParkDetails(park);
                    //TODO CreateReservation?
                }
                else if (choice == "3")
                {
                    //TODO CreateReservation
                }
                else if (choice == "4")
                {
                    break;
                }
                else
                    Console.WriteLine("Invalid input, please try again");


            }

        }
        public void DisplayParks()
        {
            IList<Park> parks = ParkDAO.GetAllParks();
            foreach(Park park in parks)
            {
                string para = ")";
                Console.WriteLine(park.ParkId.ToString() +para.PadRight(10) + park.Name.ToString().PadRight(5));
            }
            Console.ReadLine();
        }
        public void Greeting()
        {
            Console.WriteLine("Welcome to the National Park Campground Reservation System!");
            Console.WriteLine(@"        ______");
            Console.WriteLine(@"       /     /\");
            Console.WriteLine(@"      /     /  \");
            Console.WriteLine(@"     /_____/----\_    (  ");
            Console.WriteLine(@"    '     '          ).  ");
            Console.WriteLine(@"   _ ___          o (:') o   ");
            Console.WriteLine(@"  (@))_))        o ~/~~\~ o   ");
            Console.WriteLine(@"                  o  o  o");
        }
        public void ViewParkDetails(int parkId)
        {
            Park park = ParkDAO.GetPark(parkId);
            Console.WriteLine(park.Name);
            Console.WriteLine($"Location:{park.Location.PadLeft(5)}");
            Console.WriteLine($"Establish:{park.EstablishDate}");
            Console.WriteLine(park.Area);
            Console.WriteLine(park.Visitors);
            Console.WriteLine(park.Description);
            Console.ReadLine();
        }
        public MainMenu(ParkSqlDAO parkDAO)
        {
            this.ParkDAO = parkDAO;
        }
    }
}
