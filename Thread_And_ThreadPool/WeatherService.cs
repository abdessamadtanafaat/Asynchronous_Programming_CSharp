using System.Net;

namespace Asynchronous_Programming_CSharp;

public class WeatherService
{
    private readonly string _apiUrl = "https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&current=temperature_2m,wind_speed_10m&hourly=temperature_2m,relative_humidity_2m,wind_speed_10m";

    public string FetchWeatherData()
    {
        var request = (HttpWebRequest)WebRequest.Create(_apiUrl);
        request.Method = "GET";

        using (var response = (HttpWebResponse)request.GetResponse())
        {
            using (var stream = response.GetResponseStream())
            {
                if (stream == null) return "NO DATA REVEIVED";
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd(); 
                }
            }
        }
    }
}