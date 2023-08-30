using UnityEngine;
public class ProcedureLogin : ProcedureBase
{
    public override void Enter()
    {
        Game.UI.ShowUI("Login");
    }

    public override void Exit()
    {
        Game.UI.CloseUI("Login");
    }

    public override void Update(float dt)
    {
    }
}