using System.Collections.Generic;
using UnityEngine;
using System;

namespace OpenIM
{
    public delegate void OnConnectStatus(EventId eventId, string data);
    public delegate void OnLoginStatus(ErrorCode errCode, string errMsg, string data);
    public delegate void OnLogOutStatus(ErrorCode errCode, string errMsg, string data);
    public delegate void OnNetworkStatus(ErrorCode errorCode, string errMsg, string data);
    public delegate void OnSendMessage(ErrorCode errorCode, string errMsg, string data, int progress);
    public delegate void OnRecvConversationList(ErrorCode errorCode, string errMsg, List<Conversation> list);
    public delegate void OnRecvHistoryList(ErrorCode errorCode, string errMsg, List<Conversation> list);
    public static class OpenIMSDK
    {
        enum FuncBindKey
        {
            Conn,
            Login,
            Logout,
            RecvConversationMsg,
            RecvHistoryMessage,
        }
        static Dictionary<FuncBindKey, Delegate> callBackBindDic = new Dictionary<FuncBindKey, Delegate>();
        static System.Random operationIDGen = new System.Random();
        static string GetOperationID()
        {
            return operationIDGen.Next().ToString();
        }
        static void CallBindFunc<T1, T2>(FuncBindKey key, T1 t1, T2 t2)
        {
            SDKHelper.QueueOnMainThread(() =>
            {
                Delegate cb;
                var suc = callBackBindDic.TryGetValue(key, out cb);
                if (suc)
                {
                    cb.DynamicInvoke(t1, t2);
                }
            });
        }
        static void CallBindFunc<T1, T2, T3>(FuncBindKey key, T1 t1, T2 t2, T3 t3)
        {
            SDKHelper.QueueOnMainThread(() =>
            {
                Delegate cb;
                var suc = callBackBindDic.TryGetValue(key, out cb);
                if (suc)
                {
                    cb.DynamicInvoke(t1, t2, t3);
                }
            });
        }
        static void CallBindFunc<T1, T2, T3, T4>(FuncBindKey key, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            SDKHelper.QueueOnMainThread(() =>
            {
                Delegate cb;
                var suc = callBackBindDic.TryGetValue(key, out cb);
                if (suc)
                {
                    cb.DynamicInvoke(t1, t2, t3, t4);
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
        public static void OnConnectStatusChange(int eventId, string data)
        {
            CallBindFunc<int, string>(FuncBindKey.Conn, eventId, data);
        }
        public static int InitSDK(IMConfig config, OnConnectStatus cb)
        {
            Register(FuncBindKey.Conn, cb);
            SDKHelper.Initialize();
            Debug.Log("InitSDK  " + JsonUtil.ToJson(config));
            return OpenIMDLL.init_sdk(OnConnectStatusChange, GetOperationID(), JsonUtility.ToJson(config));
        }
        public static LoginStatus GetLoginStatus()
        {
            return (LoginStatus)OpenIMDLL.get_login_status(GetOperationID());
        }
        public static void OnLoginStatusChange(int errCode, string msg, string data)
        {
            CallBindFunc<ErrorCode, string, string>(FuncBindKey.Login, (ErrorCode)errCode, msg, data);
        }
        public static void Login(string uid, string token, OnLoginStatus cb)
        {
            Register(FuncBindKey.Login, cb);
            OpenIMDLL.login(OnLoginStatusChange, GetOperationID(), uid, token);
        }
        public static void OnLoginOut(int errCode, string msg, string data)
        {
            CallBindFunc<ErrorCode, string, string>(FuncBindKey.Logout, (ErrorCode)errCode, msg, data);
        }
        public static void Logout(OnLogOutStatus cb)
        {
            Register(FuncBindKey.Logout, cb);
            OpenIMDLL.logout(OnLoginOut, GetOperationID());
        }
        public static void OnRecvConversationList(int errCode, string errMsg, string data)
        {
            var list = JsonUtil.FromJson<List<Conversation>>(data);
            CallBindFunc<ErrorCode, string, List<Conversation>>(FuncBindKey.RecvConversationMsg, (ErrorCode)errCode, errMsg, list);
        }
        public static void GetConversationList(OnRecvConversationList cb)
        {
            Register(FuncBindKey.RecvConversationMsg, cb);
            OpenIMDLL.get_all_conversation_list(OnRecvConversationList, GetOperationID());
        }
        public static void RecvAdvancedHistoryMessage(int errCode, string errMsg, string data)
        {
            CallBindFunc<ErrorCode, string, List<Conversation>>(FuncBindKey.RecvConversationMsg, (ErrorCode)errCode, errMsg, null);
        }
        public static void GetAdvancedHistoryMessageList(OnRecvHistoryList cb)
        {
            Register(FuncBindKey.RecvHistoryMessage, cb);
            OpenIMDLL.get_advanced_history_message_list(RecvAdvancedHistoryMessage, GetOperationID(), "");
        }

    }
}
