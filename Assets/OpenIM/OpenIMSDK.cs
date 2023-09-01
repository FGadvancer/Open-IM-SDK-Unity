using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.Text;
namespace OpenIM
{
    public delegate void CB();
    public delegate void CB_I_S(int errCode, string errMsg);
    public delegate void CB_S(string data);
    public class OpenIMSDK
    {
#if (UNITY_IPHONE || UNITY_TVOS || UNITY_WEBGL || UNITY_SWITCH) && !UNITY_EDITOR
        const string OPENIMDLL = "__Internal";
#else
        const string OPENIMDLL = "openimsdk";
#endif

        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int init_sdk(CB onConnecting, CB onConnectSuccess, CB onKickedOffline, CB onUserTokenExpired, CB_I_S onConnectFailed, string operationId, string config);

        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void login(CB_S onSuccess, CB_I_S OnError, string uid, string token);

        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void logout(CB_S onSuccess, CB_I_S OnError, string operationId);

    }
}
