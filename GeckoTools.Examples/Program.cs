using System;
using System.Configuration;
using System.Drawing;

namespace GeckoTools.Examples
{
	class Program
	{
		static void Main(string[] args)
		{
			GeckoStatText();

			Console.WriteLine();
			Console.WriteLine("Done...");
			Console.ReadLine();
		}

		private static string GetAppSetting(string key)
		{
			Guard.NotNullOrEmpty(key, "key");

			var setting = ConfigurationManager.AppSettings[key];

			if (string.IsNullOrWhiteSpace(setting))
			{
				throw new InvalidOperationException("AppSetting does not exist: " + key);
			}
			else
			{
				return setting;
			}
		}

		private static void Send(GeckoWidget widget, string key)
		{
			var client = new GeckoClient("https://push.geckoboard.com/v1/send/", GetAppSetting("GeckoBoardApiKey"));

			client.Send(widget, GetAppSetting(key));

			Console.WriteLine("Sent: " + widget.GetType().Name);
		}

		private static void GeckoStatText()
		{
			var widget = new GeckoStatText();
			widget.Text = "This is a test";
			widget.Value = 507;

			Send(widget, "GeckoStatText");
		}

		private static void GeckoMonitor()
		{
			var widget = new GeckoMonitor();
			widget.Up = true;
			widget.Downtime = "5 minutes ago";
			widget.ResponseTime = "123 ms";

			Send(widget, "GeckoMonitor");
		}

		private static void GeckoLeaderboard()
		{
			var widget = new GeckoLeaderboard();
			widget.Add("Item 1", 100);
			widget.Add("Item 2", 200, 3);
			widget.Add("Item 3", 300);

			Send(widget, "GeckoLeaderboard");
		}

		private static void GeckoList()
		{
			var widget = new GeckoList();
			widget.Add("Item 1", "500");
			widget.Add("Item 2", "600");
			widget.Add("Item 3", "700");
			widget.Add("Item 4", "800");

			Send(widget, "GeckoList");
		}

		private static void GeckoListWithLabels()
		{
			var widget = new GeckoList();
			widget.Add("Item 1", "500", "Hot", Color.Red);
			widget.Add("Item 2", "600");
			widget.Add("Item 3", "700");
			widget.Add("Item 4", "800");

			Send(widget, "GeckoListWithLabels");
		}

		private static void GeckoText()
		{
			var widget = new GeckoText();
			widget.Add("Item 1");
			widget.AddInfo("Item 2");
			widget.AddAlert("Item 3");

			Send(widget, "GeckoText");
		}

		private static void GeckoPie()
		{
			var widget = new GeckoPie();

			var color = Color.Blue;

			widget.Add("Item 1", 10, color);
			widget.Add("Item 2", 20, ColorHelper.Lighten(color, 1));
			widget.Add("Item 3", 30, ColorHelper.Lighten(color, 2));
			widget.Add("Item 4", 40, ColorHelper.Lighten(color, 3));

			Send(widget, "GeckoPie");
		}

		private static void GeckoMap()
		{
			var widget = new GeckoMap();

			widget.AddCity("Atlanta", "GA", "US");
			widget.AddCity("Los Angeles", "CA", "US");
			widget.AddCity("Chicago", "IL", "US");
			widget.AddCity("Dallas", "TX", "US");
			widget.AddCity("New York", "NY", "US");
			widget.AddCity("Denver", "CO", "US");
			widget.AddCity("San Francisco", "CA", "US");
			widget.AddCity("Charlotte", "NC", "US");
			widget.AddCity("Las Vegas", "NV", "US");
			widget.AddCity("Phoenix", "AZ", "US");
			widget.AddCity("Houston", "TX", "US");
			widget.AddCity("Miami", "FL", "US");
			widget.AddCity("Seattle", "WA", "US");
			widget.AddCity("Newark", "NJ", "US");
			widget.AddCity("Orlando", "FL", "US");
			widget.AddCity("Minneapolis", "MN", "US");
			widget.AddCity("Detroit", "MI", "US");
			widget.AddCity("Boston", "MA", "US");
			widget.AddCity("Philadelphia", "PA", "US");
			widget.AddCity("New York", "NY", "US");
			widget.AddCity("Fort Lauderdale", "FL", "US");
			widget.AddCity("Washington, D.C.", "MD", "US");
			widget.AddCity("Chicago", "IL", "US");
			widget.AddCity("Salt Lake City", "UT", "US");
			widget.AddCity("Washington, D.C.", "VA", "US");
			widget.AddCity("Honolulu", "HI", "US");
			widget.AddCity("San Diego", "CA", "US");
			widget.AddCity("Tampa", "FL", "US");
			widget.AddCity("Portland", "OR", "US");

			Send(widget, "GeckoMap");
		}
	}
}
