using OpenIM;
using UnityEngine;

public class LoginMgr : OnConnListener, BaseListener
{
    IMConfig config;
    public LoginMgr(IMConfig config)
    {
        this.config = config;
        Debug.Log(JsonUtility.ToJson(config));
        int res = OpenIM.OpenIM.InitSDK(this, "12345", JsonUtility.ToJson(config));
        Debug.Log("InitSDK " + res);
    }


    public void Login(string id, string token)
    {
        OpenIM.OpenIM.Login(this, id, token);
    }
    public void OnConnectFailed(int code, string msg)
    {
        Debug.Log("OnConnectFailed");
    }
    public void OnConnecting()
    {
        Debug.Log("OnConnecting");
    }
    public void OnConnectSuccess()
    {
        Debug.Log("OnConnectSUC");
    }
    public void OnKickedOffline()
    {
        Debug.Log("OnOffile");
    }
    public void OnUserTokenExpired()
    {
        Debug.Log("Expired");
    }
    public void OnFailed(int code, string msg)
    {
        SDKInstance.QueueOnMainThread((obj) =>
        {
            Game.Event.Broadcast<int, string>(EventType.LoginFailed, code, msg);
        }, this);
    }
    public void OnSuccess(string msg)
    {
        Debug.Log("OnSuc" + msg);
        Game.Event.Broadcast<string>(EventType.LoginSuc, msg);
    }
}