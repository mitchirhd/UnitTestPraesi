using Geo;

Console.WriteLine("Hello, World!");

GeoController controller = new GeoController("16456e268fa17e1dd04f26e9d2b9cff9");
var manager = new GeoManager(controller);

var city1 = new Tuple<string, string, string>("Paderborn", "", "DE");
var city2 = new Tuple<string, string, string>("Hong Kong", "", "");

var x = manager.GetDistance(city1, city2);
var y = 2;