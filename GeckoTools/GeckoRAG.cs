using System.Collections.Generic;
namespace GeckoTools
{
	public class GeckoRAG : GeckoWidget
	{
		public GeckoRAG()
		{
		}

		public int RedCount { get; set; }
		public string RedText { get; set; }

		public int AmberCount { get; set; }
		public string AmberText { get; set; }

		public int GreenCount { get; set; }
		public string GreenText { get; set; }

		protected override void Validate(List<ValidationError> errors)
		{
			if (string.IsNullOrWhiteSpace(RedText))
			{
				errors.Add(new ValidationError(this, "RedText"));
			}

			if (string.IsNullOrWhiteSpace(AmberText))
			{
				errors.Add(new ValidationError(this, "AmberText"));
			}

			if (string.IsNullOrWhiteSpace(GreenText))
			{
				errors.Add(new ValidationError(this, "GreenText"));
			}
		}

		public override object GetDataObject()
		{
			var values = new object[3];
			values[0] = new { value = RedCount, text = RedText };
			values[1] = new { value = AmberCount, text = AmberText };
			values[2] = new { value = GreenCount, text = GreenText };

			return new { item = values };
		}
	}
}
