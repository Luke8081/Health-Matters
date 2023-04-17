using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health_Matters
{
    class Forecast
    {

        public class Clouds
        {
            public int all { get; set; }
        }

        public class List
        {
            public int dt { get; set; }
            public Main main { get; set; }
            public List<Weather> weather { get; set; }
            public Clouds clouds { get; set; }
            public double pop { get; set; }
            public string dt_txt { get; set; }
            public Rain rain { get; set; }
        }

        public class Main
        {
            public double temp { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
        }

        public class Rain
        {
            [JsonProperty("3h")]
            public double _3h { get; set; }
        }

        public class Root
        {
            public string cod { get; set; }
            public int message { get; set; }
            public int cnt { get; set; }
            public List<List> list { get; set; }
        }

        public class Weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string icon { get; set; }
            public string description { get; set; }
        }
    }
}
