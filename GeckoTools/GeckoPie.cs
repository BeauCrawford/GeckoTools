using System.Collections.Generic;
using System.Drawing;

namespace GeckoTools
{
	public class GeckoPie : GeckoWidget
	{
		private class GeckoPieSlice
		{
			public int value { get; set; }
			public string label { get; set; }
			public string color { get; set; }
		}

		public GeckoPie()
		{
		}

		public GeckoPie Add(string sliceLabel, int sliceValue, Color sliceColor)
		{
			Guard.NotNullOrEmpty(sliceLabel, "sliceLabel");

			_slices.Add(new GeckoPieSlice() { label = sliceLabel, value = sliceValue, color = sliceColor.ToHex().TrimStart('#') });

			return this;
		}

		public GeckoPie Add(string sliceLabel, int sliceValue, string sliceColor)
		{
			Guard.NotNullOrEmpty(sliceLabel, "sliceLabel");

			_slices.Add(new GeckoPieSlice() { label = sliceLabel, value = sliceValue, color = sliceColor });

			return this;
		}

		private List<GeckoPieSlice> _slices = new List<GeckoPieSlice>();

		public override object GetDataObject()
		{
			return new { item = _slices.ToArray() };
		}
	}
}