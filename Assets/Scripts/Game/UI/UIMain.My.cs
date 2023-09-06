using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SuperScrollView;
using OpenIM;
using System.Collections.Generic;
public partial class UIMain
{
    Button exitBtn;
    public void InitMy()
    {
        exitBtn = GetComponent<Button>("my/exit");
    }
    public void OpenMy()
    {
        OnClick(exitBtn, () =>
        {
            OpenIMSDK.Logout(OnLogout);
        });
    }
    public void CloseMy()
    {
    }
    public void OnLogout(ErrorCode errCode, string errMsg, string data)
    {
        Debug.Log("OnLogOut  " + errCode + errMsg + data);
        if (errCode != ErrorCode.None)
        {
            Game.UI.ShowError(errMsg, 2, true, true);
        }
        else
        {
            Game.ChangeProcecure<ProcedureLogin>();
        }
    }

}