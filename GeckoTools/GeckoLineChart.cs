using System.Collections.Generic;
using System.Drawing;

namespace GeckoTools
{
	public class GeckoLineChart : GeckoWidget
	{
		public GeckoLineChart()
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
				item = Values.ToArray(),

				settings = new
				{
					axisx = XAxisLabels.ToArray(),
					axisy = YAxisLabels.ToArray(),
					color = LineColor.ToHex()
				}
			};
		}
	}
}
