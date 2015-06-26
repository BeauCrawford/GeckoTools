using System.Collections.Generic;
using System.Linq;

namespace GeckoTools
{
	public class GeckoText : GeckoWidget
	{
		public GeckoText()
		{
			Entries = new List<GeckoTextEntry>();
		}

		public List<GeckoTextEntry> Entries { get; private set; }

		public override object GetDataObject()
		{
			return new { item = Entries.Select(e => e.GetData()).ToArray() };
		}
	}
}
