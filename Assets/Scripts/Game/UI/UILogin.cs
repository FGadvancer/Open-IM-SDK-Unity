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
        OnClick(loginBtn, () =>
        {
            OpenIMSDK.Login(uid.text, token.text, OnLoginStatusChange);
        });
        OnClick(exitBtn, () =>
        {
            OpenIMSDK.Logout(OnLogout);
        });
    }
    public void OnLoginStatusChange(ErrorCode errCode, string errMsg, string data)
    {
        Debug.LogError(errCode + "  " + errMsg + "  " + data);
        if (errCode == ErrorCode.LoginRepeatError)
        {
            Game.ChangeProcecure<ProcedureMain>();
        }
    }
    public void OnLogout(ErrorCode errCode, string errMsg, string data)
    {
        Debug.LogError(errCode + "  " + errMsg + "  " + data);
        if (errCode != ErrorCode.None)
        {
            // Game.UI.ShowError(data, 2, true, true);
        }
        else
        {
            // Game.UI.ShowTip("Logout Suc", 2, false, false);
        }
    }
    public override void OnUpdate(float dt)
    {

    }
    public override void OnClose()
    {
    }


}
