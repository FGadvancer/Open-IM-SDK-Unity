using Newtonsoft.Json;
namespace OpenIM
{
    public static class JsonUtil
    {
        private class Pack<T>
        {
            public T data;
        }
        public static string ToJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public static T FromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}