public class HttpUrl
{
    public static string AccountCheck;
    public static void Init(string hostPrefix)
    {
        AccountCheck = string.Format("{0}/user/account_check", hostPrefix);
    }
}