namespace KGD.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
        "FreezingGG", "BracingGG", "ChillyGG", "CoolGG", "MildGG", "WarmGG", "BalmyGG", "HotGG", "SwelteringGG", "ScorchingGG"
    };

        public Task<WeatherForecast[]> GetForecastAsync(DateOnly startDate)
        {
            return Task.FromResult(Enumerable.Range(1, Summaries.Length).Select(index => new WeatherForecast
            {
                Id = index,
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray());
        }
    }
}