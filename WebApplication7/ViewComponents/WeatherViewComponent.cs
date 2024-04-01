
using ASP.NET.Views.Components.Weather;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class WeatherViewComponent : ViewComponent
{


    public async Task<IViewComponentResult> InvokeAsync(string lat, string lng)
    {
        dynamic data;
        try
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(
                    $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lng}&appid=33326712deb20b6df0aed9f628abdaf6"
                );
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();

                data = JsonConvert.DeserializeObject(jsonString);

            }
        }
        catch {
            data = null;
        }

        if (data is not null) { 
        double tempCelsius = Math.Round((double)data.main.temp - 273.15);
       
        double windSpeed = (double)data.wind.speed;

        var model = new WeatherModel
        {
            TempCelsius = tempCelsius,

            WindSpeed = windSpeed,
        };

        return View("Weather", model);
    }
    return View("Weather");
    }
}

