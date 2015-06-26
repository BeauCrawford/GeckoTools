namespace GeckoTools
{
	public class ValidationError
	{
		public ValidationError(GeckoWidget widget, string message)
		{
			Guard.NotNull(widget, "widget");
			Guard.NotNullOrEmpty(message, "message");

			Widget = widget;
			Message = message;
		}

		public GeckoWidget Widget { get; private set; }
		public string Message { get; private set; }
	}
}