using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GeckoTools
{
	public class GeckoList : GeckoWidget
	{
		private class GeckoListItem
		{
			public GeckoListItem()
			{
				LabelColor = Color.White;
			}

			public string Title { get; set; }
			public string LabelName { get; set; }
			public Color LabelColor { get; set; }
			public string Description { get; set; }

			public object GetData()
			{
				object itemLabel = null;

				// "#ff2015"

				if (!string.IsNullOrWhiteSpace(LabelName))
				{
					itemLabel = new { name = LabelName, color = LabelColor.ToHex() };
				}

				return new
				{
					title = new { text = Title },
					label = itemLabel,
					description = Description
				};
			}
		}

		public GeckoList()
		{
		}

		private List<GeckoListItem> _items = new List<GeckoListItem>();

		public GeckoList Add(string title, string description, string labelName, Color labelColor)
		{
			_items.Add(new GeckoListItem() { Title = title, Description = description, LabelName = labelName, LabelColor = labelColor });

			return this;
		}

		public override object GetDataObject()
		{
			return _items.Select(i => i.GetData()).ToArray();
		}
	}
}