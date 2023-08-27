using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
namespace OpenIM
{
    public class InitInfo{
            public int platformID;
            public string apiAddr;
            public string wsAddr;
            public string dataDir;
            public int logLevel;
            public bool isLogStandardOutput;
            public string logFilePath;
            public string isExternalExtensions;
    }

    public partial class OpenIMClient
    {
        static AndroidJavaClass _Instance = null;

        public static void Init()
        {
            _Instance = new AndroidJavaClass("open_im_sdk.Open_im_sdk");
            if (_Instance == null)
                Debug.LogError("not find open_im_sdk.Open_im_sdk");
        }
        #region Tools
        public static string GetTimeStamp(){
            return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString();
        }
        #endregion

        public static bool InitSDK(OnConnListenerCallBack callback,InitInfo info)
        {
            if (_Instance == null) 
                Init();

            var args = JsonUtility.ToJson(info);
            Debug.Log("args = " + args);
            return Instance.CallStatic<bool>("initSDK",callback,GetTimeStamp(),args);
        }
        
        public static void Login(BaseCallBack callback,string userID,string token){
            Debug.Log("Login userID = " + userID);
            Debug.Log("Login TOKEN = " + token);
            _Instance.CallStatic("login",callback,GetTimeStamp(),userID,token);
        }


    }
    
}
