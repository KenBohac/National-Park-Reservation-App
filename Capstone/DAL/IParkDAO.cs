using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public interface IParkDAO
    {
        /// <summary>
        /// Returns a list of all parks.
        /// </summary>
        /// <returns></returns>
        IList<Park> GetAllParks();
        /// <summary>
        /// Returns an individual park.
        /// </summary>
        /// <param name="parkId"></param>
        /// <returns></returns>
        Park GetPark(int parkId);

    }
}
