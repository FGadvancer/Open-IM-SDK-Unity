using UnityEngine;
using OpenIM;
public class ProcedureLogin : ProcedureBase
{
    public override void Enter()
    {
        var status = OpenIMSDK.GetLoginStatus();
        Debug.Log("LoginStatus =>" + status);
        if (status == LoginStatus.Logged)
        {
            Game.ChangeProcecure<ProcedureMain>();
        }
        else if (status == LoginStatus.Logout)
        {
            Game.UI.ShowUI("Login");
        }
        else
        {
            Game.UI.ShowTip("Logining", 2);
        }
    }

    public override void Exit()
    {
        Game.UI.CloseUI("Login");
    }

    public override void Update(float dt)
    {
    }
}