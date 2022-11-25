using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Models
{
    public class Districts
    {
        public List<DistrictsData> districts { get; set; }
    }

    public class DistrictsData
    {
        public int district_id { get; set; }
        public string district_name { get; set; }
    }
}
