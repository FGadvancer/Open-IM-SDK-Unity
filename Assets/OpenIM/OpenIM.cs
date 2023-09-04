using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenIM
{
    public static class OpenIMSDK
    {
        static System.Random operationIDGen = new System.Random();
        static string GetOperationID()
        {
            return operationIDGen.Next().ToString();
        }
        public static int InitSDK(IMConfig config, CB_I_S cb)
        {
            SDKHelper.QueueOnMainThread(() => { Debug.Log("Init SDKHelper"); });
            return OpenIMDLL.init_sdk(cb, GetOperationID(), JsonUtility.ToJson(config));
        }

        public static void Login(string uid, string token, CB_I_S_S cb)
        {
            OpenIMDLL.login(cb, GetOperationID(), uid, token);
        }

        public static void LogOut(CB_I_S_S cb)
        {
            OpenIMDLL.logout(cb, GetOperationID());
        }
    }
}
