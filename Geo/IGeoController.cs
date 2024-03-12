using Geo.Models;

namespace Geo
{
	public interface IGeoController
    {
        GeoResponse? GeocodeAddress(string city, string state, string country);
    }
}