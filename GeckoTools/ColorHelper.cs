using System;
using System.Drawing;

namespace GeckoTools
{
	public static class ColorHelper
	{
		private static readonly Random random = new Random();

		public static Color Random()
		{
			return Color.FromArgb(random.Next(200, 255), random.Next(150, 255), random.Next(150, 255));
		}

		public static Color Lighten(Color color)
		{
			float correctionFactor = 0.5f;
			float red = (255 - color.R) * correctionFactor + color.R;
			float green = (255 - color.G) * correctionFactor + color.G;
			float blue = (255 - color.B) * correctionFactor + color.B;
			Color lighterColor = Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
			return lighterColor;
		}

		public static Color Lighten(Color color, int passes)
		{
			for (int i = 1; i <= passes; i++)
			{
				color = Lighten(color);
			}

			return color;
		}
	}
}