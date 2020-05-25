using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace PCcamAdmin.Models
{
    public class Laptop
    {
        public Laptop()
        {
            date = new DateTime();
        }

        public string Brand { get; set; }
        public string Name { get; set; }
        public string price { get; set; }
        public Processor proc { get; set; }
        public string graphics { get; set; }
        public string Os { get; set; }
        public int RAM { get; set; }
        public DateTime date { get; set; }
        public string storage { get; set; }
        public string screen { get; set; }
        public string mainimg { get; set; }

        public List<Imgs> imgs { get; set; }

        public override string ToString()
        {
            return Brand + "  " + Name;
        }
    }
    /*#
        Add When User Wants Click Save
     */
    public class Imgs
    {
        public string folder { get; set; }
        public string imgname { get; set; }
        public string imgurl { get; set; }
    }

    public class Processor
    {
        public string name { get; set; }
        public int cores { get; set; }
        public int threads { get; set; }
        public double clockspeed { get; set; }
        public string cache { get; set; }
    }
}
