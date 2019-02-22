using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Capstone.DAL;
using Capstone.Models;


namespace Capstone
{
   public class ParkService
    {
        private IParkDAO ParkDAO;

        private ICampgroundDAO CampgroundDAO;

        private ISiteDAO SiteDAO;

        private IReservationDAO ReservationDAO;

        public ParkService(IParkDAO parkDAO, ICampgroundDAO campgroundDAO, ISiteDAO siteDAO, IReservationDAO reservationDAO)
        {
            this.ParkDAO = parkDAO;
            this.CampgroundDAO = campgroundDAO;
            this.SiteDAO = siteDAO;
            this.ReservationDAO = reservationDAO;

        }

        public IList<Park> GetAllParks()
        {
            return this.ParkDAO.GetAllParks();
            
        }
        
    }
}
