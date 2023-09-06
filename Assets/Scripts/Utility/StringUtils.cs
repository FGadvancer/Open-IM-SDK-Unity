using System;
namespace Dawn
{
    public static class StringUtils
    {
        public static string DurationToStr1(float duration)
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
        public static string DurationToStr2(float duration)
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

        // 显示 时分
        public static string TimeStampToStr1(Int64 timestamp)
        {
            DateTime t = new DateTime(timestamp);
            return string.Format("{0:00}:{1:00}", t.Hour, t.Minute);
        }

        // 显示 时分秒
        public static string TimeStampToStr2(Int64 timestamp)
        {
            DateTime t = new DateTime(timestamp);
            return string.Format("{0:00}:{1:00}:{2:00}", t.Hour, t.Minute, t.Second);
        }
    }
}
