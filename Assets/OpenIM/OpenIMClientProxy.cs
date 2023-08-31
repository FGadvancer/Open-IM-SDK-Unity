using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.Text;
namespace OpenIMClientProxy
{
    public delegate void CB();
    public delegate void CB_I_S(int code, string msg);
    public delegate void CB_S(string msg);



    public partial class OpenIMClientProxy
    {
#if (UNITY_IPHONE || UNITY_TVOS || UNITY_WEBGL || UNITY_SWITCH) && !UNITY_EDITOR
        const string OPENIMDLL = "__Internal";
#else
        const string OPENIMDLL = "openim";
#endif

        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int init_sdk(Action onConnecting, Action onConnectSuccess, Action onKickedOffline, Action onUserTokenExpired, Action<int, string> onConnectFailed, string operationId, string config);

        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void login(CB_S onSuccess, CB_I_S OnFailed, string uid, string token);
    }

}
