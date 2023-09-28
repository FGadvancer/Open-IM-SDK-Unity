using OpenIM;

public abstract class BaseHttpMsg
{
    public string ToJson()
    {
        return JsonUtil.ToJson(this);
    }
}