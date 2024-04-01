using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET.Views.Components.Weather
{
    public class WeatherModel : PageModel
    {
        public double TempCelsius {  get; set; }
        
        public double WindSpeed { get; set; }
        public void OnGet()
        {
        }
    }
}
