using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class CampgroundModel
    {
        public int Campground_Id { get; set; }
        public int Park_Id { get; set; }
        public string Name { get; set; }
        public int Open_From_MM { get; set; }
        public int Open_To_MM { get; set; }
        public decimal Daily_Fee { get; set; }
    }
}
