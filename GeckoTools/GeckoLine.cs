using System.Collections.Generic;
using System.Drawing;

namespace GeckoTools
{
	public class GeckoLine : GeckoWidget
	{
		public GeckoLine()
		{
			XAxisLabels = new List<string>();
			YAxisLabels = new List<string>();
			Values = new List<int>();
			LineColor = Color.Red;
		}

		public List<string> XAxisLabels { get; private set; }
		public List<string> YAxisLabels { get; private set; }
		public List<int> Values { get; private set; }
		public Color LineColor { get; set; }

		public override object GetDataObject()
		{
			return new
			{
				x_axis = new { labels = XAxisLabels },
				y_axis = new { labels = YAxisLabels },
				series = new[] { new { data = Values.ToArray() } }
			};
		}
	}
}

/*
{
  "x_axis": {
	"labels": ["May", "Jun", "Jul", "Aug", "Sep"]
  },
  "series": [
	{
	  "data": [
		10, 2, 24, 18, 35
	  ]
	}
  ]
}
*/