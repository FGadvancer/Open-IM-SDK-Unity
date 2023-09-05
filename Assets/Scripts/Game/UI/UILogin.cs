using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OpenIM;
public class UILogin : UILogicBase
{
    TMP_InputField uid;
    TMP_InputField token;
    Button loginBtn;
    Button exitBtn;
    TextMeshProUGUI status;
    public override void Init()
    {
        loginBtn = GetComponent<Button>("login");
        exitBtn = GetComponent<Button>("exit");
        uid = GetComponent<TMP_InputField>("uid");
        token = GetComponent<TMP_InputField>("token");
    }
    public override void OnDestroy()
    {
    }
    public override void OnOpen()
    {
        var config = new IMConfig(2, "http://125.124.195.201:10002", "ws://125.124.195.201:10001", Application.persistentDataPath, 1, true, Application.persistentDataPath, true);
        int res = OpenIMSDK.InitSDK(config, OnConnectStatusChange);
        Debug.Log("Init SDK  " + res);
        OnClick(loginBtn, () =>
        {
            OpenIMSDK.Login(uid.text, token.text, OnLoginStatusChange);
        });
        OnClick(exitBtn, () =>
        {
            OpenIMSDK.Logout(OnLogoutStatus);
        });
    }
    public override void OnUpdate(float dt)
    {

    }
    public override void OnClose()
    {

    }
    public void OnConnectStatusChange(EventId id, string data)
    {
        Debug.Log(id + "  " + data);
    }
    public void OnLoginStatusChange(ErrorCode errCode, string errMsg, string data)
    {
        Debug.Log(errCode + "  " + errMsg + "  " + data);
    }
    public void OnLogoutStatus(ErrorCode errCode, string errMsg, string data)
    {
        Debug.Log(errCode + "  " + errMsg + "  " + data);
    }
}
