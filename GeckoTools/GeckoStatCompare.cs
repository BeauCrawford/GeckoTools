namespace GeckoTools
{
	public class GeckoStatCompare : GeckoWidget
	{
		public GeckoStatCompare()
		{
		}

		public int CurrentValue { get; set; }
		public int PreviousValue { get; set; }

		public override object GetDataObject()
		{
			var values = new object[2];
			values[0] = new { value = CurrentValue };
			values[1] = new { value = PreviousValue };
			return new { item = values };
		}
	}
}