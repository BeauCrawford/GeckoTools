using System.Drawing;
using Newtonsoft.Json.Linq;

namespace GeckoTools
{
    public static class Extensions
    {
        public static void Add(this JObject parent, string propertyName, string childKey, JToken childValue)
        {
            var child = new JObject();
            child.Add(childKey, childValue);
            parent.Add(propertyName, child);
        }

        public static string ToHex(this Color color)
        {
            return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }
    }
}