using System.Globalization;

namespace Server.resources.rsf
{
    public static class Util
    {
    }

    public static class CultChange
    {
        public static string Cc(this float value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
