using System;

public static class StringUtils
{
    public static string GetShowAddress(string address)
    {
        if (address.Length <= 0)
        {
            return "";
        }
        if (address.Length >= 8)
        {
            return address.Substring(0, 5) + "..." + address.Substring(address.Length - 4, 4);
        }
        return address;
    }

    public static string TimeToStr1(float duration)
    {
        duration = duration < 0 ? 0 : duration;
        TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(duration));
        string str = "";
        if (ts.Hours > 0)
        {
            str = String.Format("{0:00}", ts.Hours) + ":" + String.Format("{0:00}", ts.Minutes) + ":" + String.Format("{0:00}", ts.Seconds);
        }
        if (ts.Hours == 0 && ts.Minutes > 0)
        {
            str = "00:" + String.Format("{0:00}", ts.Minutes) + ":" + String.Format("{0:00}", ts.Seconds);
        }
        if (ts.Hours == 0 && ts.Minutes == 0)
        {
            str = "00:00:" + String.Format("{0:00}", ts.Seconds);
        }
        return str;
    }
    public static string TimeToStr2(float duration)
    {
        duration = duration < 0 ? 0 : duration;
        TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(duration));
        string str = "";
        if (ts.Minutes > 0)
        {
            str = String.Format("{0:00}", ts.Minutes) + ":" + String.Format("{0:00}", ts.Seconds);
        }
        if (ts.Minutes == 0)
        {
            str = "00:" + String.Format("{0:00}", ts.Seconds);
        }
        return str;
    }
}