using System;

namespace StreamConsole
{
    public class CookieCutter
    {
        public string DoughType { get; set; }
        public string CookieType { get; set; }

        public int BladeSharpness { get; set; }

        public CookieCutter(string doughType, string cookieType, int bladeSharpness)
        {
            DoughType = doughType;
            CookieType = cookieType;
            BladeSharpness = bladeSharpness;
        }

        public int CutCookie()
        {
            BladeSharpness--;
            return BladeSharpness;
        }

        public DateTime RemindMeToCutCookieOn(int days)
        {
            return DateTime.Now;
        }
        
    }
}