using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace OpenIM
{
    public partial class OpenIMClient
    {
        public class OnConnListenerCallBack : AndroidJavaProxy
        {
            public OnConnListenerCallBack() : base ("open_im_sdk_callback.OnConnListener")
            {

            }

            public void onConnectFailed(int var1, string var2)
            {
                
            }
            public void onConnectSuccess()
            {

            }
            public void onKickedOffline()
            {
                
            }

            public void onUserTokenExpired()
            {

            }
        }
    }
}

