using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    interface ISiteDAO
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
    }
}
