using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OpenIM;
public class UILogin : UILogicBase
{
    TMP_InputField uid;
    TMP_InputField token;
    Button loginBtn;
    TextMeshProUGUI status;
    public override void Init()
    {
        loginBtn = GetComponent<Button>("login");
        uid = GetComponent<TMP_InputField>("uid");
        token = GetComponent<TMP_InputField>("token");
    }
    public override void OnDestroy()
    {
    }
    public override void OnOpen(object userData)
    {
        uid.text = Game.Config.TestID;
        token.text = Game.Config.TestToken;

        OnClick(loginBtn, () =>
        {
            OpenIMSDK.Login(uid.text, token.text, OnLoginStatusChange);
        });
    }
    public void OnLoginStatusChange(ErrorCode errCode, string errMsg, string data)
    {
        if (errCode == ErrorCode.LoginRepeatError)
        {
            Game.Player.UserID = uid.text;
            Game.ChangeProcecure<ProcedureMain>();
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
