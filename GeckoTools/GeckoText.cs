using System.Collections.Generic;
using System.Linq;

namespace GeckoTools
{
	public class GeckoText : GeckoWidget
	{
		private class GeckoTextEntry
		{
			public GeckoTextEntry()
			{
			}

			public string Text { get; set; }

			public int Type { get; set; }

			public object GetData()
			{
				return new
				{
					text = Text,
					type = Type
				};
			}
		}

		public GeckoText()
		{
		}

		private List<GeckoTextEntry> _entries = new List<GeckoTextEntry>();

		private void Add(string text, int type)
		{
			Guard.NotNullOrEmpty(text, "text");

			_entries.Add(new GeckoTextEntry() { Text = text, Type = type });
		}

		public void Add(string text)
		{
			Add(text, 0);
		}

		public void AddAlert(string text)
		{
			Add(text, 1);
		}

		public void AddInfo(string text)
		{
			Add(text, 2);
		}

		public override object GetDataObject()
		{
			return new { item = _entries.Select(e => e.GetData()).ToArray() };
		}
	}
}