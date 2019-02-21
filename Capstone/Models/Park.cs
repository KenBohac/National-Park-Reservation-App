using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Park
    {
        /// <summary>
        /// the park_id
        /// </summary>
        public int ParkId { get; set; }

        /// <summary>
        /// the Park Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// the park location
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// the Date Park was established
        /// </summary>
        public DateTime EstablishDate { get; set; }
        /// <summary>
        /// the Park's area
        /// </summary>
        public int Area { get; set; }
        /// <summary>
        /// Park's annual visitors
        /// </summary>
        public int Visitors { get; set; }
        /// <summary>
        /// Park's longer, written text description
        /// </summary>
        public string Description { get; set; }







    }
}
