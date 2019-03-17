using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public interface ICampgroundDAO
    {
        IList<CampgroundModel> GetCampgrounds(int park_Id);
        bool IsOpen(CampgroundModel campground, DateTime fromDate, DateTime toDate);
    }
}
