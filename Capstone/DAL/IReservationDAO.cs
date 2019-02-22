using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public interface IReservationDAO
    {
        /// <summary>
        /// Returns an individual reservation.
        /// </summary>
        /// <param name="reservationId"></param>
        /// <returns></returns>
        Reservation GetReservation(int reservationId);
        /// <summary>
        /// Returns a list of all reservations on a site.
        /// </summary>
        /// <param name="siteId"></param>
        /// <returns></returns>
        IList<Reservation> GetAllReservations(int siteId);

        
    }
    
}
