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
        static System.Random operationIDGen = new System.Random();
        static string GetOperationID()
        {
            return operationIDGen.Next().ToString();
        }
        public static int InitSDK(OnConnListener cb, string config)
        {
            SDKHelper.QueueOnMainThread((obj) => { Debug.Log("Init SDKInstance..."); }, null);
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
            }, GetOperationID(), config);
        }

        public static void Login(BaseListener cb, string uid, string token)
        {
            OpenIMSDK.login((data) =>
            {
                SDKHelper.QueueOnMainThread((obj) => { cb.OnSuccess(data); }, null);
            }, (errCode, errMsg) =>
            {
                SDKHelper.QueueOnMainThread((obj) => { cb.OnError(errCode, errMsg); }, null);
            }, uid, token);
        }

        public static void LogOut(BaseListener cb)
        {
            OpenIMSDK.logout((data) =>
            {
                SDKHelper.QueueOnMainThread((obj) => { cb.OnSuccess(data); }, null);
            }, (errCode, errMsg) =>
            {
                SDKHelper.QueueOnMainThread((obj) => { cb.OnError(errCode, errMsg); }, null);
            }, GetOperationID());
        }
    }
}
