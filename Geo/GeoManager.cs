

namespace Geo
{
	public class GeoManager
	{
		public IGeoController Controller { get; set; }
		
		public GeoManager(IGeoController controller)
		{
			Controller = controller;
		}
		
		public double GetDistance(Tuple<string, string, string> values1, Tuple<string, string, string> values2)
		{
			var geo1 = Controller.GeocodeAddress(values1.Item1 ?? "", values1.Item2 ?? "", values1.Item3);
			var geo2 = Controller.GeocodeAddress(values2.Item1 ?? "", values2.Item2 ?? "", values2.Item3);

			if (geo1 == null || geo2 == null)
				return 0;

			var lat1 = DegreeToRadians(geo1.Lat);
			var lat2 = DegreeToRadians(geo2.Lat);
			var lon1 = DegreeToRadians(geo1.Lon);
			var lon2 = DegreeToRadians(geo2.Lon);

			// acos(sin(lat1)*sin(lat2)+cos(lat1)*cos(lat2)*cos(lon2-lon1))*6371
			return Math.Acos(Math.Sin(lat1) * Math.Sin(lat2) 
				   + Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(lon2 - lon1)) * 6371;
		}
		
		
		
		private double DegreeToRadians(double degrees)
		{
			return degrees * Math.PI / 180.0;
		}
	}
}