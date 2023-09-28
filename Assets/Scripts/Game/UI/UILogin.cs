using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OpenIM;
public class UILogin : UILogicBase
{
    TMP_InputField uid;
    Button loginBtn;
    Button registerBtn;
    public override void Init()
    {
        loginBtn = GetComponent<Button>("login");
        registerBtn = GetComponent<Button>("register");
        uid = GetComponent<TMP_InputField>("uid");
    }
    public override void OnDestroy()
    {
    }
    public override void OnOpen(object userData)
    {
        uid.text = Game.Player.UserID;
        OnClick(loginBtn, () =>
        {
            Game.Http.Post(HttpUrl.AccountCheck, new AccountCheckArgs(uid.text).ToJson(), (suc, data) =>
            {
                Debug.Log(suc);
                Debug.Log(data);
            });
            // OpenIMSDK.Login(uid.text, Game.Player.Token, OnLoginStatusChange);
        });
        OnClick(registerBtn, () =>
        {

        });
    }
    public void OnLoginStatusChange(ErrorCode errCode, string errMsg, string data)
    {
        Debug.Log(errCode + errMsg + data);
        if (errCode == ErrorCode.LoginRepeatError)
        {
            Game.UI.ShowError(errMsg, 2);
        }
        else if (errCode == ErrorCode.None)
        {

        }
    }

    public override void OnUpdate(float dt)
    {

    }
    public override void OnClose()
    {
    }


}
