using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Models;

namespace Capstone.CLI
{
    public class MainMenu
    {
        private ParkSqlDAO ParkDAO { get; set; }
        public void Run()
        {
           
        }
        public void DisplayParks()
        {
            IList<Park> parks = ParkDAO.GetAllParks();
            foreach(Park park in parks)
            {

                Console.WriteLine(park.ParkId.ToString().PadRight(10) + ')' + park.Name.ToString().PadRight(5));
            }
            Console.ReadLine();
        }
        public MainMenu(ParkSqlDAO parkDAO)
        {
            this.ParkDAO = parkDAO;
        }
    }
}
