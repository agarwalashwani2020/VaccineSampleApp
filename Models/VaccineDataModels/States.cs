using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class States
    {
        public List<StateData> states { get; set; }
    }

    public class StateData
    {
        public int state_id { get; set; }
        public string state_name { get; set; }
    }
}
