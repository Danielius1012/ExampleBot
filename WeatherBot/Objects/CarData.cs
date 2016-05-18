using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherBot.Objects
{


    public class CarData
    {
        public Model[] Models { get; set; }
    }

    public class Model
    {
        public string model_name { get; set; }
        public string model_make_id { get; set; }
    }



}