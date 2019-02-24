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
        /// <summary>
        /// Returns a list of all parks.
        /// </summary>
        /// <returns></returns>
        public IList<Park> GetAllParks()
        {
            return this.ParkDAO.GetAllParks();
        }
        /// <summary>
        /// Returns an individual park.
        /// </summary>
        /// <param name="parkId"></param>
        /// <returns></returns>
        public Park GetPark(int parkId)
        {
            return this.ParkDAO.GetPark(parkId);
        }
        /// <summary>
        /// Returns a list of all the campgrounds of the given input park.
        /// </summary>
        /// <param name="parkId"></param>
        /// <returns></returns>
        public IList<Campground> GetAllCampgrounds(int parkId)
        {
            return this.CampgroundDAO.GetAllCampgrounds(parkId);
        }
        /// <summary>
        /// Returns an individual campground of the given input campground id.
        /// </summary>
        /// <param name="campgroundId"></param>
        /// <returns></returns>
        public Campground GetCampground(int campgroundId)
        {
            return this.CampgroundDAO.GetCampground(campgroundId);
        }
        /// <summary>
        /// Returns a list of all sites in a given input campground id.
        /// </summary>
        /// <param name="campgroundId"></param>
        /// <returns></returns>
        public IList<Site> GetAllSites(int campgroundId)
        {
            return this.SiteDAO.GetAllSites(campgroundId);
        }
        /// <summary>
        /// Returns an individual site given an input site id.
        /// </summary>
        /// <param name="siteId"></param>
        /// <returns></returns>
        public Site GetSite(int siteId)
        {
            return this.SiteDAO.GetSite(siteId);
        }
        /// <summary>
        /// Returns a list of all reservations for a given site.
        /// </summary>
        /// <param name="campgroundId"></param>
        /// <returns></returns>
        public IList<Reservation> GetAllReservations(int siteId)
        {
            return this.ReservationDAO.GetAllReservations(siteId);
        }
        public Reservation GetReservation(int reservationId)
        {
            return this.ReservationDAO.GetReservation(reservationId);
        }
        public IList<Site> SearchForOpenSites(int campgroundId, DateTime startDate, DateTime endDate)
        {
            return this.SiteDAO.SearchForOpenSites(campgroundId, startDate, endDate);
        }
        public bool CheckForOpen(int campgroundId, DateTime startDate, DateTime endDate)
        {
             
            IList<Site> searchResult = SearchForOpenSites(campgroundId, startDate, endDate);
            bool result = searchResult.Count > 0 ? result = true : result = false;

            return result;
        }
        public int CalculateStay(DateTime fromDate, DateTime toDate)
        {
            TimeSpan ts = toDate - fromDate;
            int days = (int)ts.TotalDays;
            return days;
        }
    }


}
