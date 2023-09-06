using UnityEngine;

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
            if (obj == null) return "null";
            if (typeof(T).GetInterface("IList") != null)
            {
                Pack<T> pack = new Pack<T>();
                pack.data = obj;
                string json = JsonUtility.ToJson(pack);
                return json.Substring(8, json.Length - 9);
            }
            return JsonUtility.ToJson(obj);
        }
        public static T FromJson<T>(string json)
        {
            if (json == "null" && typeof(T).IsClass) return default(T);
            if (typeof(T).GetInterface("IList") != null)
            {
                json = "{\"data\":{data}}".Replace("{data}", json);
                Pack<T> pack = JsonUtil.FromJson<Pack<T>>(json);
                return pack.data;
            }
            return JsonUtility.FromJson<T>(json);
        }
    }
}