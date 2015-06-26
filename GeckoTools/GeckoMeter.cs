using Newtonsoft.Json.Linq;

namespace GeckoTools
{
    public class GeckoMeter : GeckoWidget
    {
        public GeckoMeter()
        {
            Min = 0;
            Max = 100;
        }

        public int Min { get; set; }
        public int Max { get; set; }
        public int Value { get; set; }

        public override object GetDataObject()
        {
            var o = new JObject();
            o.Add("item", Value);
            o.Add("min", "value", Min);
            o.Add("max", "value", Max);
            return o;
        }
    }
}