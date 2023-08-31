using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.Text;
using Dawn.Event;

namespace OpenIM
{
    public interface BaseListener
    {
        void OnSuccess(string msg);
        void OnFailed(int code, string msg);
    }
    public interface OnConnListener
    {
        void OnConnecting();
        void OnConnectSuccess();
        void OnKickedOffline();
        void OnUserTokenExpired();
        void OnConnectFailed(int code, string msg);
    }

    public static class OpenIM
    {
        public static int InitSDK(OnConnListener callback, string operationId, string config)
        {
            return OpenIMSDK.init_sdk(callback.OnConnecting, callback.OnConnectSuccess,
            callback.OnKickedOffline, callback.OnUserTokenExpired, callback.OnConnectFailed, operationId, config);
        }

        public static void Login(BaseListener callback, string uid, string token)
        {
            OpenIMSDK.login(callback.OnSuccess, callback.OnFailed, uid, token);
        }
    }

}
