using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.Text;

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
        public static int InitSDK(OnConnListener cb, string operationId, string config)
        {
            SDKInstance.QueueOnMainThread((obj) =>
            {
                Debug.Log("Init SDKInstance");
            }, null);
            return OpenIMSDK.init_sdk(() =>
            {
                cb.OnConnecting();
            }, () =>
            {
                cb.OnConnectSuccess();
            },
            () =>
            {
                cb.OnKickedOffline();
            }, () =>
            {
                cb.OnUserTokenExpired();
            }, (code, msg) =>
            {
                cb.OnConnectFailed(code, msg);
            }, operationId, config);
        }

        public static void Login(BaseListener cb, string uid, string token)
        {
            OpenIMSDK.login((msg) =>
            {
                cb.OnSuccess(msg);
            }, (code, msg) =>
            {
                cb.OnFailed(code, msg);
            }, uid, token);
        }
    }
}
