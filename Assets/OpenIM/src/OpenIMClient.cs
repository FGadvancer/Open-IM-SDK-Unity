using System.Collections;
using System.Collections.Generic;

using UnityEngine;
namespace OpenIM
{
    public class InitInfo{
            public int platform;
            public string api_addr;
            public string ws_addr;
            public string data_dir;
            public int log_level;
            public string object_storage;
            public string encryption_key;
    }

    public partial class OpenIMClient
    {
        static AndroidJavaClass _Instance = null;

               


        public static void Init()
        {
            _Instance = new AndroidJavaClass("open_im_sdk.Open_im_sdk");
            if (_Instance == null)
                Debug.LogError("not find open_im_sdk.Open_im_sdk");

            Debug.Log(_Instance);
        }

        public static void initSDK(InitInfo info)
        {
            if (_Instance == null) return;
            var args = JsonUtility.ToJson(info);
            Debug.Log("args = " + args);
            _Instance.CallStatic<bool>("initSDK",new OnConnListenerCallBack(),Time.realtimeSinceStartup.ToString(),args);
        }
    }

}
