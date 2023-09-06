using System.Collections.Generic;
using UnityEngine;
using System;

namespace OpenIM
{
    public enum EventId
    {
        CONNECTING,
        CONNECT_SUCCESS,
        CONNECT_FAILED,
        KICKED_OFFLINE,
        USER_TOKEN_EXPIRED,
    }
    public enum ErrorCode
    {
        None = 0,
        LoginRepeatError = 10102
    }
    public delegate void OnConnectStatus(EventId eventId, string data);
    public delegate void OnLoginStatus(ErrorCode errCode, string errMsg, string data);
    public delegate void OnLogOutStatus(ErrorCode errCode, string errMsg, string data);
    public delegate void OnNetworkStatus(ErrorCode errorCode, string errMsg, string data);
    public delegate void OnSendMessage(ErrorCode errorCode, string errMsg, string data, int progress);
    public delegate void OnRecvConversationList(ErrorCode errorCode, string errMsg, List<Conversation> list);
    public static class OpenIMSDK
    {
        public enum FuncBindKey
        {
            Conn,
            Login,
            Logout,
            RecvConversationMsg,
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
        public static void OnRecvConversationList(int errCode, string errMsg, string data)
        {
            SDKHelper.QueueOnMainThread(() =>
            {
                Delegate cb = null;
                var suc = callBackBindDic.TryGetValue(FuncBindKey.RecvConversationMsg, out cb);
                if (suc)
                {
                    Debug.Log(data);
                    var list = JsonUtil.FromJson<List<Conversation>>(data);
                    cb.DynamicInvoke((ErrorCode)errCode, errMsg, list);
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
            Debug.Log("InitSDK  " + JsonUtil.ToJson(config));
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

        public static void GetConversationList(OnRecvConversationList cb)
        {
            Register(FuncBindKey.RecvConversationMsg, cb);
            OpenIMDLL.get_all_conversation_list(OnRecvConversationList, GetOperationID());
        }
    }
}
