using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OpenIM;
public class CreateGroupCallBack : BaseCallBack
{
    public CreateGroupCallBack()
    {

    }
    public override void onError(int var1, string var2)
    {
        var info = "Error" + var1 + var2;
        UIManager.GetUIManager().Tip.ShowTipInfo(info);
    }

    public override void onSuccess(string var1)
    {
        var info = "Success  " + var1;
        UIManager.GetUIManager().Tip.ShowTipInfo(info);
        UIManager.GetUIManager().Main.OnCreateGroup(var1);
    }
}
public class UIMain : MonoBehaviour
{
    // Start is called before the first frame update
    public Button CreateGroup = null;
    public Text tip = null;

    void Start()
    {
        CreateGroup.onClick.AddListener(() =>
        {
            CreateGroupParams param = new CreateGroupParams();
            param.groupName = "yejian";
            param.notification = "33333333333333333";
            param.introduction = "";
            param.faceURL = "";
            param.groupType = 0;
            param.ex = "";
            UIManager.GetUIManager().Tip.ShowTipInfo("CreateGroup Click");
            OpenIMClient.CreateGroup(new CreateGroupCallBack(),param,"");
        });
    }

    public void OnCreateGroup(string createGroupInfo){
        tip.text = createGroupInfo;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
