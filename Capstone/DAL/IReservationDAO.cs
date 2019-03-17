using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public interface IReservationDAO
    {
        int PlaceReservation(string name, int site_Id, DateTime from_Date, DateTime to_Date);
    }
}
