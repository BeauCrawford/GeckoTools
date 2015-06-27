using System.Collections.Generic;
using System.Linq;

namespace GeckoTools
{
	public class GeckoLeaderboard : GeckoWidget
	{
		private class GeckoLeaderboardItem
		{
			public string Label { get; set; }
			public decimal Value { get; set; }
			public int? PreviousRank { get; set; }

			public object GetDataObject()
			{
				if (PreviousRank.HasValue)
				{
					return new
					{
						label = Label,
						value = Value,
						previous_rank = PreviousRank.Value
					};
				}
				else
				{
					return new
					{
						label = Label,
						value = Value
					};
				}

			}
		}

		public GeckoLeaderboard()
		{
		}

		private List<GeckoLeaderboardItem> _items = new List<GeckoLeaderboardItem>();

		public GeckoLeaderboard Add(string label, decimal value, int? previousRank = null)
		{
			Guard.NotNullOrEmpty(label, "label");

			_items.Add(new GeckoLeaderboardItem() { Label = label, Value = value, PreviousRank = previousRank });

			return this;
		}

		public override object GetDataObject()
		{
			return new { items = _items.Select(i => i.GetDataObject()).ToArray() };
		}
	}
}
