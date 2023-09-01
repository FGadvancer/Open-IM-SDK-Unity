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
        void OnSuccess(string data);
        void OnError(int errCode, string errMsg);
    }
    public interface OnConnListener
    {
        void OnConnecting();
        void OnConnectSuccess();
        void OnKickedOffline();
        void OnUserTokenExpired();
        void OnConnectFailed(int errCode, string errMsg);
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
            }, (errCode, errMsg) =>
            {
                cb.OnConnectFailed(errCode, errMsg);
            }, operationId, config);
        }

        public static void Login(BaseListener cb, string uid, string token)
        {
            OpenIMSDK.login((data) =>
            {
                cb.OnSuccess(data);
            }, (errCode, errMsg) =>
            {
                cb.OnError(errCode, errMsg);
            }, uid, token);
        }
    }
}
