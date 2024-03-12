using Geo.Models;

namespace Geo
{
	
	public class GeoController : IGeoController
	{
		private readonly HttpClient _client;
		private readonly string _apiKey;
		
		public GeoController(string apiKey)
		{
			_client = new HttpClient();
			_apiKey = apiKey;
		}
		
		public GeoResponse? GeocodeAddress(string city, string state, string country)
		{
			try
			{
				string url = $"http://api.openweathermap.org/geo/1.0/direct?q={city},{state},{country}&limit=5&appid={_apiKey}";

				HttpResponseMessage response = _client.GetAsync(url).Result;

				if (response.IsSuccessStatusCode)
				{
					string responseBody = response.Content.ReadAsStringAsync().Result;
					return GeoResponse.DeserializeFromJsonAsync(responseBody, country);
				}
				else
				{
					var s = response.Content.ReadAsStringAsync();
					Console.WriteLine($"Failed to geocode address. Status code: {response.StatusCode}");
					return null;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"An error occurred while geocoding address: {ex.Message}");
				return null;
			}
		}
	}
}