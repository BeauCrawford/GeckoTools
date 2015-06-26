using System.Collections.Generic;

namespace GeckoTools
{
	public abstract class GeckoWidget
	{
		protected GeckoWidget()
		{
		}

		public abstract object GetDataObject();

		public IEnumerable<ValidationError> Validate()
		{
			var errors = new List<ValidationError>();
			Validate(errors);
			return errors;
		}

		protected virtual void Validate(List<ValidationError> errors)
		{
		}
	}
}