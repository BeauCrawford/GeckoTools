using System.Collections.Generic;

namespace GeckoTools
{
	public class GeckoStatTrend : GeckoWidget
	{
		public GeckoStatTrend()
		{
			PreviousValues = new List<decimal>();
		}

		public decimal CurrentValue { get; set; }

		public List<decimal> PreviousValues { get; private set; }

		public override object GetDataObject()
		{
			return new
			{
				item = new object[]
				{
					new { value = CurrentValue, type = "text" },
					PreviousValues.ToArray()
				}
			};
		}
	}
}
