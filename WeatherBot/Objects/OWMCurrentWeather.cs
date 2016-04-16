using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherBot.Objects
{
    public class OWMCurrentWeather
    {
        public OWMCoordinate Coord { get; set; }

        public List<OWMWeather> Weather { get; set; }

        public string Base { get; set; }

        public OWMMain Main { get; set; }

        public OWMWind Wind { get; set; }

        public OWMCloud Clouds { get; set; }

        public OWMRain Rain { get; set; }

        public OWMSnow Snow { get; set; }

        /// <summary>
        /// Time of data calculation, unix, UTC 
        /// </summary>
        public DateTime Date { get; set; }

        public OWMSys Sys { get; set; }

        /// <summary>
        /// City ID
        /// </summary>
        [JsonProperty("id")]
        public string CityId { get; set; }

        /// <summary>
        /// City name 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Internal parameter 
        /// </summary>
        
        public string Cod { get; set; }
        
    }

    public class OWMSys
    {
        /// <summary>
        /// Internal parameter
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Internal parameter
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Internal parameter
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Country code (GB, JP etc.)
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// Sunrise time, unix, UTC
        /// </summary>
        [JsonProperty("sunrise")]
        public string Sunrise { get; set; }

        /// <summary>
        /// Sunset time, unix, UTC
        /// </summary>
        [JsonProperty("sunset")]
        public string Sunset { get; set; }
    }

    public class OWMSnow
    {
        /// <summary>
        /// Snow volume for the last 3 hours
        /// </summary>
        [JsonProperty("3h")]
        public string SnowVolume { get; set; }
    }

    public class OWMRain
    {
        /// <summary>
        /// Rain volume for the last 3 hours
        /// </summary>
        [JsonProperty("3h")]
        public string RainVolume { get; set; }
    }

    public class OWMCloud
    {
        /// <summary>
        /// Cloudiness, %
        /// </summary>
        [JsonProperty("all")]
        public string Cloudiness { get; set; }
    }

    public class OWMWind
    {
        /// <summary>
        /// Wind speed. Unit Default: meter/sec, Metric: meter/sec, Imperial: miles/hour.
        /// </summary>
        [JsonProperty("speed")]
        public string Speed { get; set; }

        /// <summary>
        /// Wind direction, degrees (meteorological)
        /// </summary>
        [JsonProperty("deg")]
        public string Direction { get; set; }
    }

    public class OWMCoordinate
    {
        /// <summary>
        /// City geo location, longitude
        /// </summary>
        [JsonProperty("lon")]
        public string Longitude { get; set; }

        /// <summary>
        /// City geo location, latitude
        /// </summary>
        [JsonProperty("lat")]
        public string Latitude { get; set; }
    }

    public class OWMWeather
    {
        /// <summary>
        /// Weather condition id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Group of weather parameters (Rain, Snow, Extreme etc.)
        /// </summary>
        [JsonProperty("main")]
        public string Main { get; set; }

        /// <summary>
        /// Weather condition within the group
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Weather icon id
        /// </summary>
        [JsonProperty("icon")]
        public string IconId { get; set; }
    }

    public class OWMMain
    {
        /// <summary>
        /// Temperature. Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit. 
        /// </summary>
        [JsonProperty("temp")]
        public string Temperature { get; set; }

        /// <summary>
        /// Atmospheric pressure (on the sea level, if there is no sea_level or grnd_level data), hPa
        /// </summary>
        [JsonProperty("pressure")]
        public string Pressure { get; set; }

        /// <summary>
        /// Humidity, %
        /// </summary>
        [JsonProperty("humidity")]
        public string Humidity { get; set; }

        /// <summary>
        /// Minimum temperature at the moment. This is deviation from current temp that is possible for large cities and megalopolises geographically expanded (use these parameter optionally). Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        /// </summary>
        [JsonProperty("temp_min")]
        public string TempMin { get; set; }

        /// <summary>
        /// Maximum temperature at the moment. This is deviation from current temp that is possible for large cities and megalopolises geographically expanded (use these parameter optionally). Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.
        /// </summary>
        [JsonProperty("temp_max")]
        public string TempMax { get; set; }

        /// <summary>
        /// Atmospheric pressure on the sea level, hPa
        /// </summary>
        [JsonProperty("sea_level")]
        public string SeaLevel { get; set; }

        /// <summary>
        /// Atmospheric pressure on the ground level, hPa
        /// </summary>
        [JsonProperty("grnd_level")]
        public string GroundLevel { get; set; }
    }
}