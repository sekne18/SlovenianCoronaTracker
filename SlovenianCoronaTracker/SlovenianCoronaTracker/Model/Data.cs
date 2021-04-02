using System;
using System.Collections.Generic;
using System.Text;

namespace SlovenianCoronaTracker.Model
{
    public class Data
    {
        public int st_pozitivnih { get; set; }
        public int st_testov { get; set; }
        public double proc_pozitivnih { get; set; }
        public int st_umrlih { get; set; }
        public int st_hospitaliziranih { get; set; }
        public DateTime datum_podatkov { get; set; }

    }
}
