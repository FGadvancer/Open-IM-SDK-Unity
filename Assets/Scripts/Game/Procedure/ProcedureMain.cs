using UnityEngine;

public class ProcedureMain : ProcedureBase
{
    public override void Enter()
    {
        Game.UI.ShowUI("Main");
    }

    public override void Exit()
    {
        Game.UI.CloseUI("Main");
    }

    public override void Update(float dt)
    {
    }
}