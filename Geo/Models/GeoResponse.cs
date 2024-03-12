using System.Text.Json;
using System.Text.Json.Serialization;

namespace Geo.Models
{
	public class GeoResponse
	{
		[JsonPropertyName("name")]
		public string? Name { get; set; }
		
		[JsonPropertyName("lat")]
		public double Lat { get; set; }

		[JsonPropertyName("lon")]
		public double Lon{ get; set; }

		[JsonPropertyName("country")]
		public string? Country { get; set; }
		
		[JsonPropertyName("state")]
		public string? State { get; set; }

		public static GeoResponse? DeserializeFromJsonAsync(string jsonResponse, string countrycode)
		{
			return JsonSerializer.Deserialize<List<GeoResponse>>(jsonResponse)
					.FirstOrDefault(r => r.Country == countrycode);
		}
	}
}