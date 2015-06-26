using System.Collections.Generic;
namespace GeckoTools
{
	public class GeckoStatText : GeckoWidget
	{
		public GeckoStatText()
		{
		}

		public string Prefix { get; set; }
		public string Text { get; set; }
		public int Value { get; set; }

		protected override void Validate(List<ValidationError> errors)
		{
			if (string.IsNullOrWhiteSpace(Text))
			{
				errors.Add(new ValidationError(this, "Text is required"));
			}
		}

		public override object GetDataObject()
		{
			var values = new object[1];
			values[0] = new { value = Value, text = Text, prefix = Prefix };
			return new { item = values };
		}
	}
}