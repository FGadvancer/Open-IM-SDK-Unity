using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.Text;
namespace OpenIMClient
{

public interface OnConnListener
{
    void OnConnecting();
    void OnConnectSuccess();
    void OnKickedOffline();
    void OnUserTokenExpired();
    void OnConnectFailed(int code, string msg);
}

    public partial class OpenIMClient
    {

        public static  int InitSDK(OnConnListener callback, string operationId, string config)
        {
            return OpenIMClientProxy.init_sdk(callback.OnConnecting, callback.OnConnectSuccess,
            callback.OnKickedOffline,callback.OnUserTokenExpired,callback.OnConnectFailed,operationId, config);
        }
    }

}
