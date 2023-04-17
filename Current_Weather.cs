using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health_Matters
{
    class Current_Weather
    {
        public class Main
        {
            public double temp { get; set; }
        }

        public class Root
        {
            public Coord coord { get; set; }
            public List<Weather> weather { get; set; }
            public Main main { get; set; }
        }


        public class Weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }
        public class Coord
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }
    }
}
