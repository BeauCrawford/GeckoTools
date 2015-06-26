namespace GeckoTools
{
	public class GeckoTextEntry
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
}