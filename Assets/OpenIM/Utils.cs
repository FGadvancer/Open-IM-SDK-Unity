using System;
using UnityEngine;

namespace OpenIM
{
    public static class Utils
    {
        public static CB_I_S WrapperCB_I_S(CB_I_S callBack)
        {
            CB_I_S wrapper = (eventName, data) =>
            {
                Debug.Log(eventName + data);
                // SDKHelper.QueueOnMainThread(() =>
                // {
                //     Debug.Log(callBack + " " + eventName + " " + data);
                //     // callBack(eventName, data);
                // });
            };
            return wrapper;
        }
        public static CB_I_S_S WrapperCB_I_S_S(CB_I_S_S callBack)
        {
            CB_I_S_S wrapper = (errCode, errMsg, data) =>
            {
                Debug.Log(errCode + errMsg + data);
                // SDKHelper.QueueOnMainThread(() =>
                // {
                //     Debug.Log(callBack.ToString());
                //     Debug.Log(errCode + errMsg + data);
                // });
            };
            return wrapper;
        }
        public static CB_I_S_S_I WrapperCB_I_S_S_I(CB_I_S_S_I callBack)
        {
            CB_I_S_S_I wrapper = (errCode, errMsg, data, progress) =>
            {
                Debug.Log(errCode + errMsg + data + progress);
                // SDKHelper.QueueOnMainThread(() =>
                // {
                //     try
                //     {
                //         callBack(errCode, errMsg, data, progress);
                //     }
                //     catch (Exception e)
                //     {
                //         Debug.LogError(e.ToString());
                //     }
                // });
            };
            return wrapper;
        }
    }
}