using Newtonsoft.Json;
namespace OpenIM
{
    public static class JsonUtil
    {
        public static string ToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public static T FromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}