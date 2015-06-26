using System;

namespace GeckoTools
{
	public static class Guard
	{
		public static void NotNullOrEmpty(string value, string parameterName)
		{
			if (value == null)
			{
				throw new ArgumentNullException(parameterName);
			}

			if (string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentException(parameterName);
			}
		}

		public static void NotNull(object value, string parameterName)
		{
			if (value == null)
			{
				throw new ArgumentNullException(parameterName);
			}
		}
	}
}