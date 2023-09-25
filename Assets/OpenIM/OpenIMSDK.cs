using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using AOT;
namespace OpenIM
{
    public delegate void OnConnectStatus(EventId eventId, string data);
    public delegate void OnLoginStatus(ErrorCode errCode, string errMsg, string data);
    public delegate void OnLogOutStatus(ErrorCode errCode, string errMsg, string data);
    public delegate void OnNetworkStatus(ErrorCode errorCode, string errMsg, string data);
    public delegate void SendMessage(string operationId, ErrorCode errorCode, string errMsg, string data, int progress);
    public delegate void OnRecvConversationList(ErrorCode errorCode, string errMsg, List<LocalConversation> list);
    public delegate void OnRecvHistoryList(string operationId, ErrorCode errorCode, string errMsg, AdvancedHistoryMessageData list);
    public delegate void GlobalListener(EventId eventId, string data);
    public static class OpenIMSDK
    {
        enum FuncBindKey
        {
            Conn,
            Login,
            Logout,
            SendMessage,
            RecvConversationMsg,
            RecvHistoryMessage,
            GroupListener,
            ConversitionListener,
            AdvancedMsgListener,
            BatchMsgListener,
            UserListener,
            FriendListener,
            CustomBusinessListener,
        }
        static Dictionary<FuncBindKey, Delegate> callBackBindDic = new Dictionary<FuncBindKey, Delegate>();
        // static System.Random operationIDGen = new System.Random(System.DateTime.Now.Millisecond);
        static string GetOperationID()
        {
            // return operationIDGen.Next(10000,100000000).ToString();
            return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString();
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
        static void CallBindFunc<T1, T2, T3, T4, T5>(FuncBindKey key, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            SDKHelper.QueueOnMainThread(() =>
            {
                Delegate cb;
                var suc = callBackBindDic.TryGetValue(key, out cb);
                if (suc)
                {
                    cb.DynamicInvoke(t1, t2, t3, t4, t5);
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

        [MonoPInvokeCallback(typeof(print))]
        public static void Print(string info)
        {
            Debug.Log(info);
        }
        [MonoPInvokeCallback(typeof(CB_I_S))]
        public static void OnConnectStatusChange(int eventId, string data)
        {
            CallBindFunc(FuncBindKey.Conn, eventId, data);
        }
        public static bool InitSDK(IMConfig config, OnConnectStatus cb)
        {
            SDKHelper.Initialize();
            OpenIMDLL.set_print(Print);
            Register(FuncBindKey.Conn, cb);
            var _operationID = GetOperationID();
            var _config = JsonUtility.ToJson(config);
            return OpenIMDLL.init_sdk(OnConnectStatusChange, _operationID, _config);
        }
        public static void UnInitSDK()
        {
            OpenIMDLL.un_init_sdk(GetOperationID());
        }
        public static LoginStatus GetLoginStatus()
        {
            return (LoginStatus)OpenIMDLL.get_login_status(GetOperationID());
        }
        [MonoPInvokeCallback(typeof(CB_S_I_S_S))]
        public static void OnLoginStatusChange(string operationId, int errCode, string msg, string data)
        {
            CallBindFunc(FuncBindKey.Login, (ErrorCode)errCode, msg, data);
        }
        public static void Login(string uid, string token, OnLoginStatus cb)
        {
            Register(FuncBindKey.Login, cb);
            OpenIMDLL.login(OnLoginStatusChange, GetOperationID(), uid, token);
        }
        public static void OnLoginOut(string operationId, int errCode, string msg, string data)
        {
            CallBindFunc(FuncBindKey.Logout, (ErrorCode)errCode, msg, data);
        }

        [MonoPInvokeCallback(typeof(CB_S_I_S_S))]
        public static void Logout(OnLogOutStatus cb)
        {
            Register(FuncBindKey.Logout, cb);
            OpenIMDLL.logout(OnLoginOut, GetOperationID());
        }
        [MonoPInvokeCallback(typeof(CB_S_I_S_S))]
        public static void OnRecvConversationList(string operationID, int errCode, string errMsg, string data)
        {
            var list = JsonUtil.FromJson<List<LocalConversation>>(data);
            CallBindFunc(FuncBindKey.RecvConversationMsg, (ErrorCode)errCode, errMsg, list);
        }
        public static void GetConversationList(OnRecvConversationList cb)
        {
            Register(FuncBindKey.RecvConversationMsg, cb);
            var operationId = GetOperationID();
            OpenIMDLL.get_all_conversation_list(OnRecvConversationList, operationId);
        }
        [MonoPInvokeCallback(typeof(CB_S_I_S_S))]
        public static void RecvAdvancedHistoryMessage(string operationId, int errCode, string errMsg, string data)
        {
            var msgData = errCode == (int)ErrorCode.None ? JsonUtil.FromJson<AdvancedHistoryMessageData>(data) : null;
            CallBindFunc(FuncBindKey.RecvHistoryMessage, operationId, (ErrorCode)errCode, errMsg, msgData);
        }
        public static void GetAdvancedHistoryMessageList(OnRecvHistoryList cb, GetAdvancedHistoryMessageListParams args)
        {
            Register(FuncBindKey.RecvHistoryMessage, cb);
            OpenIMDLL.get_advanced_history_message_list(RecvAdvancedHistoryMessage, GetOperationID(), JsonUtil.ToJson(args));
        }
        [MonoPInvokeCallback(typeof(CB_I_S))]
        public static void OnGroupListener(int eid, string data)
        {
            CallBindFunc(FuncBindKey.GroupListener, (EventId)eid, data);
        }
        public static void SetGroupListener(GlobalListener cb)
        {
            Register(FuncBindKey.GroupListener, cb);
            OpenIMDLL.set_group_listener(OnGroupListener);
        }

        [MonoPInvokeCallback(typeof(CB_I_S))]
        static void OnConversationListener(int eid, string data)
        {
            CallBindFunc(FuncBindKey.ConversitionListener, (EventId)eid, data);
        }
        public static void SetConversationListener(GlobalListener cb)
        {
            Register(FuncBindKey.ConversitionListener, cb);
            OpenIMDLL.set_conversation_listener(OnConversationListener);
        }

        [MonoPInvokeCallback(typeof(CB_I_S))]
        static void OnAdvancedMsgListener(int eid, string data)
        {
            CallBindFunc(FuncBindKey.AdvancedMsgListener, (EventId)eid, data);
        }
        public static void SetAdvancedMsgListener(GlobalListener cb)
        {
            Register(FuncBindKey.AdvancedMsgListener, cb);
            OpenIMDLL.set_advanced_msg_listener(OnAdvancedMsgListener);
        }

        public static string CreateTextMessage(string text)
        {
            IntPtr strPtr = OpenIMDLL.create_text_message(GetOperationID(), text);
            string res = Marshal.PtrToStringAnsi(strPtr);
            // TODO 导致闪退
            // Marshal.FreeHGlobal(strPtr);
            return res;
        }
        [MonoPInvokeCallback(typeof(CB_S_I_S_S_I))]
        static void OnSendMessage(string operationId, int errorCode, string errMsg, string data, int progress)
        {
            CallBindFunc(FuncBindKey.SendMessage, operationId, (ErrorCode)errorCode, errMsg, data, progress);
        }
        public static void SendMessage(string messageFlag, string recvId, string groupId, string offlinePushInfo, SendMessage cb)
        {
            Register(FuncBindKey.SendMessage, cb);
            var opid = GetOperationID();
            OpenIMDLL.send_message(OnSendMessage, opid, messageFlag, recvId, groupId, offlinePushInfo);
        }
    }
}