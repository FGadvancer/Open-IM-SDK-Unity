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
        public enum FuncBindKey
        {
            Conn,
            Login,
            Logout,
        }
        static Dictionary<FuncBindKey, Delegate> callBackBindDic = new Dictionary<FuncBindKey, Delegate>();
        static System.Random operationIDGen = new System.Random();
        static string GetOperationID()
        {
            return operationIDGen.Next().ToString();
        }
        public static void OnConnectStatusChange(int eventId, string data)
        {
            SDKHelper.QueueOnMainThread(() =>
            {
                Delegate cb = null;
                var suc = callBackBindDic.TryGetValue(FuncBindKey.Conn, out cb);
                if (suc)
                {
                    cb.DynamicInvoke(eventId, data);
                }
            });
        }
        public static void OnLoginStatusChange(int errCode, string msg, string data)
        {
            SDKHelper.QueueOnMainThread(() =>
            {
                Delegate cb = null;
                var suc = callBackBindDic.TryGetValue(FuncBindKey.Login, out cb);
                if (suc)
                {
                    cb.DynamicInvoke(errCode, msg, data);
                }
            });
        }

        public static void OnLoginOut(int errCode, string msg, string data)
        {
            SDKHelper.QueueOnMainThread(() =>
            {
                Delegate cb = null;
                var suc = callBackBindDic.TryGetValue(FuncBindKey.Logout, out cb);
                if (suc)
                {
                    cb.DynamicInvoke(errCode, msg, data);
                }
            });
        }
        static void Register(FuncBindKey key, Delegate cb)
        {
            if (callBackBindDic.ContainsKey(key))
            {
                callBackBindDic.Remove(key);
            }
            callBackBindDic.Add(key, cb);
        }
        public static int InitSDK(IMConfig config, OnConnectStatus cb)
        {
            Register(FuncBindKey.Conn, cb);
            SDKHelper.Initialize();
            return OpenIMDLL.init_sdk(OnConnectStatusChange, GetOperationID(), JsonUtility.ToJson(config));
        }

        public static void Login(string uid, string token, OnLoginStatus cb)
        {
            Register(FuncBindKey.Login, cb);
            OpenIMDLL.login(OnLoginStatusChange, GetOperationID(), uid, token);
        }

        public static void Logout(OnLogOutStatus cb)
        {
            Register(FuncBindKey.Logout, cb);
            OpenIMDLL.logout(OnLoginOut, GetOperationID());
        }
    }
}
