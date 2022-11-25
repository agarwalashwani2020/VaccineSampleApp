using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Models
{
    public class CentersData
    {
        public List<Centers> centers { get; set; }
    }

    public class Centers
    {
        public int center_id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string state_name { get; set; }
        public string district_name { get; set; }
        public string block_name { get; set; }
        public List<Sessions> sessions { get; set; }
        public List<VaccineFees> vaccine_fees { get; set; }
    }

    public class Sessions
    {
        public string date { get; set; }
        public int available_capacity { get; set; }
        public int min_age_limit { get; set; }
        public bool allow_all_age { get; set; }
        public string vaccine { get; set; }
        public List<Slots> slots { get; set; }
        public int available_capacity_dose1 { get; set; }
        public int available_capacity_dose2 { get; set; }
    }

    public class Slots
    {
        public string time { get; set; }
        public int seats { get; set; }
    }

    public class VaccineFees
    {
        public string vaccine { get; set; }
        public string fee { get; set; }
    }
}

