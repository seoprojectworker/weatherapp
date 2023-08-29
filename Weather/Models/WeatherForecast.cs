namespace Weather.Models
{
    public class WeatherForecast
    {
        public string Date { get; set; }
        public Temperature Temperature { get; set; }
        public string Summary { get; set; }
    }

    public class Temperature
    {
        public double Celsius { get; set; }
        public double Fahrenheit { get; set; }
    }

}
