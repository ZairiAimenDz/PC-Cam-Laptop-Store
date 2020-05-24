using System;
using System.Collections.Generic;
using System.Text;

namespace PCcamAdmin.Models
{
    public class Laptop
    {
        public string Brand { get; set; }
        public string Name { get; set; }
        public Processor proc { get; set; }
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
