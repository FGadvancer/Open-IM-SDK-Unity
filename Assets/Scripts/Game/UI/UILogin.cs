using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OpenIM;
public class UILogin : UILogicBase
{
    Button loginBtn;
    Button exitBtn;
    TextMeshProUGUI status;
    public override void Init()
    {
        loginBtn = GetComponent<Button>("login");
        exitBtn = GetComponent<Button>("exit");
    }
    public override void OnDestroy()
    {
    }
    public override void OnOpen()
    {
        var config = new IMConfig(3, "http://125.124.195.201:10002", "ws://125.124.195.201:10001", Application.persistentDataPath, 1, true, Application.persistentDataPath, true);
        int res = OpenIMSDK.InitSDK(config, Utils.WrapperCB_I_S(OnConnectStatusChange));
        Debug.Log("Init SDK  " + res);
        OnClick(loginBtn, () =>
        {
            var uid = "6959062403";
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiI2OTU5MDYyNDAzIiwiUGxhdGZvcm1JRCI6MywiZXhwIjoxNzAwNzIwOTg0LCJuYmYiOjE2OTI5NDQ2ODQsImlhdCI6MTY5Mjk0NDk4NH0.8otKTFrOCs8_ueV10rNOD-rzHrCT_EN0obKS9q79bIc";
            OpenIMSDK.Login(uid, token, Utils.WrapperCB_I_S_S(OnLoginStatusChange));
        });
        OnClick(exitBtn, () =>
        {
            OpenIMSDK.LogOut(Utils.WrapperCB_I_S_S(OnLoginStatusChange));
        });

        Game.Event.AddListener<int, string>(EventType.LoginFailed, (code, msg) =>
        {
            status.text = msg;
        });
        Game.Event.AddListener<string>(EventType.LoginSuc, (msg) =>
        {
            status.text = msg;
        });
    }
    public override void OnUpdate(float dt)
    {

    }
    public override void OnClose()
    {

    }
    public void OnConnectStatusChange(int eventId, string data)
    {
        Debug.Log(eventId + "  " + data);
    }
    public void OnLoginStatusChange(int errCode, string errMsg, string data)
    {
        Debug.Log(errCode + "  " + errMsg + "  " + data);
    }

}
