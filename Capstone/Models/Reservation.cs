using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Reservation
    {/// <summary>
     /// Reservation Id
     /// </summary>
     
        public int ReservationId { get; set; }
        public int SiteId { get; set; }
        public string Name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime CreateDate { get; set; }
        public static int CalculateStay(DateTime fromDate, DateTime toDate)
        {
            TimeSpan ts = toDate -fromDate;
            int days = (int)ts.TotalDays;
            return days;
        }

    }
}
