using UnityEngine;
using OpenIM;
public class ProcedureLogin : ProcedureBase
{
    public override void Enter()
    {
        var status = OpenIMSDK.GetLoginStatus();
        if (status == LoginStatus.Logged)
        {
            Game.ChangeProcecure<ProcedureMain>();
        }
        else
        {
            Game.UI.ShowUI("Login");
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