using System.Collections.Generic;

namespace GeckoTools
{
	public class GeckoStatTrend : GeckoWidget
	{
		public GeckoStatTrend()
		{
			PreviousValues = new List<int>();
		}

		public int CurrentValue { get; set; }

		public List<int> PreviousValues { get; private set; }

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
