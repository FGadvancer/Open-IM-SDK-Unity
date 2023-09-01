using OpenIM;
using UnityEngine;

public class LoginMgr : OnConnListener, BaseListener
{
    IMConfig config;
    public LoginMgr(IMConfig config)
    {
        this.config = config;
        Debug.Log(JsonUtility.ToJson(config));
        int res = OpenIM.OpenIM.InitSDK(this, JsonUtility.ToJson(config));
        Debug.Log("InitSDK " + res);
    }
    public void Login(string id, string token)
    {
        OpenIM.OpenIM.Login(this, id, token);
    }
    public void LogOut()
    {
        OpenIM.OpenIM.LogOut(this);
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
    public void OnError(int code, string msg)
    {
        Debug.Log(msg);
        Game.Event.Broadcast<int, string>(EventType.LoginFailed, code, msg);
    }
    public void OnSuccess(string msg)
    {
        Debug.Log(msg);
        Game.Event.Broadcast<string>(EventType.LoginSuc, msg);
    }
}