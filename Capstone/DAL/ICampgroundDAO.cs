using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;
namespace Capstone.DAL
{
    interface ICampgroundDAO
    {
        /// <summary>
        /// Gets an individual campground.
        /// </summary>
        /// <param name="campgroundId"></param>
        /// <returns></returns>
        Campground GetCampground(int campgroundId);
        /// <summary>
        /// Returns a list of all campgrounds in a park.
        /// </summary>
        /// <param name="parkId"></param>
        /// <returns></returns>
        IList<Campground> GetAllCampgrounds(int parkId);
    }
}
