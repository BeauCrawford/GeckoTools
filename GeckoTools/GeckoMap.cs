using System.Collections.Generic;
using System.Linq;

namespace GeckoTools
{
	public class GeckoMap : GeckoWidget
	{
		public GeckoMap()
		{
			Points = new List<GeckoMapPoint>();
		}

		public List<GeckoMapPoint> Points { get; private set; }

		public GeckoMap AddCity(string city, string state, string country, int size = 2, string color = "d8f709")
		{
			Guard.NotNullOrEmpty(city, "city");
			Guard.NotNullOrEmpty(state, "state");
			Guard.NotNullOrEmpty(country, "country");
			Guard.NotNullOrEmpty(color, "color");

			Points.Add(new GeckoMapCity() { City = city, State = state, Country = country, Size = size, Color = color });
			return this;
		}

		public override object GetDataObject()
		{
			return new { points = new { point = Points.Select(p => p.GetData()).ToArray() } };
		}
	}
}

/*
{
  "points": {
	"point": [
	  {
		"city": {
		  "city_name": "London",
		  "country_code": "GB"
		},
		"size": 10
	  },
	  {
		"city": {
		  "city_name": "San Francisco",
		  "country_code": "US",
		  "region_code": "CA"
		}
	  },
	  {
		"latitude": "22.2670",
		"longitude": "114.1880",
		"color": "d8f709"
	  },
	  {
		"latitude": "-33.94336",
		"longitude": "18.896484",
		"size": 5
	  },
	  {
		"host": "geckoboard.com",
		"color": "77dd77",
		"size": 6
	  },
	  {
		"ip": "178.125.193.227"
	  }
	]
  }
}
*/