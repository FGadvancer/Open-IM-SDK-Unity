using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace OpenIM
{
    public abstract class OnConnListenerCallBack : AndroidJavaProxy
    {
        public OnConnListenerCallBack() : base("open_im_sdk_callback.OnConnListener")
        {
        }

        public abstract void onConnectFailed(int var1, string var2);
        public abstract void onConnectSuccess();
        public abstract void onConnecting();
        public abstract void onKickedOffline();

        public abstract void onUserTokenExpired();
    }

    public abstract class BaseCallBack : AndroidJavaProxy
    {
        public BaseCallBack() : base("open_im_sdk_callback.Base"){
        }

        public abstract void onError(int var1,string var2);

        public abstract void onSuccess(string var1);
    }
}   

