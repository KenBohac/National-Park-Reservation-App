using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public interface ISiteDAO
    {
        /// <summary>
        /// Returns a specific site.
        /// </summary>
        /// <param name="site_Id"></param>
        /// <returns></returns>
        Site GetSite(int siteId);
        /// <summary>
        /// Return all cites in a campground.
        /// </summary>
        /// <param name="campgroundId"></param>
        /// <returns></returns>
        IList<Site> GetAllSites(int campgroundId);
        /// <summary>
        /// Searches for an open site, by input park id and entered dates. Returns open sites in the parameters.
        /// </summary>
        /// <param name="campgroundId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        IList<Site> SearchForOpenSites(int campgroundId, DateTime startDate, DateTime endDate);
    }
}
