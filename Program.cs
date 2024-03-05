using Geo;

Console.WriteLine("Hello, World!");

GeoController controller = new GeoController("16456e268fa17e1dd04f26e9d2b9cff9");
string s = await controller.GeocodeAddress("Berlin", "", "Germany");
