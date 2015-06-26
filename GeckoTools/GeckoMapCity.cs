using System.Drawing;

namespace GeckoTools
{
	public class GeckoMapCity : GeckoMapPoint
	{
		public GeckoMapCity()
		{
		}

		public string City { get; set; }
		public string State { get; set; }
		public string Country { get; set; }
		public int Size { get; set; }
		public string Color { get; set; }

		public override object GetData()
		{
			return new
			{
				city = new
				{
					city_name = City,
					country_code = Country,
					region_code = State
				},

				size = Size,
				color = string.IsNullOrWhiteSpace(Color) ? System.Drawing.Color.Blue.ToHex().TrimStart('#') : Color.TrimStart('#')
			};
		}
	}
}