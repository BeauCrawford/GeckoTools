
namespace GeckoTools
{
	public class GeckoMonitor : GeckoWidget
	{
		public bool Up { get; set; }

		public string Downtime { get; set; }

		public string ResponseTime { get; set; }

		public override object GetDataObject()
		{
			return new { status = Up ? "Up" : "Down", downTime = Downtime, responseTime = ResponseTime };
		}
	}
}

/*
{
  "status": "Up",
  "downTime": "9 days ago",
  "responseTime": "593 ms"
}
*/