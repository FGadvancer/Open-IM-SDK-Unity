using System;
using UnityEngine;
using System.Collections.Generic;
[System.Serializable]
public class UIItem
{
    public string UIName;
    public UILogicComponent logic;
}
public class UIManager : MonoBehaviour
{
    public Canvas Root;
    public UIItem[] UIItems;
    Dictionary<string, UIItem> mUIItemDic;

    void Start()
    {
        mUIItemDic = new Dictionary<string, UIItem>();
        foreach (UIItem UI in UIItems)
        {
            mUIItemDic.Add(UI.UIName, UI);
            var type = Utility.Assembly.GetType(UI.logic.LogicTypeName);
            if (type == null)
            {

                Debug.LogError(UI.UIName + "Not Find UILogicComponent");
            }
            else
            {
                var uicomponent = UI.logic.GetComponent<UILogicComponent>();
                if (uicomponent == null)
                {
                    Debug.LogError(UI.UIName + "Not Find UILogicComponent");
                }
                else
                {
                    uicomponent.logic = (UILogicBase)Activator.CreateInstance(type);
                    uicomponent.logic.UIRoot = UI.logic.transform;
                    uicomponent.Init();
                }
            }
        }
    }
    void Update()
    {
        var dt = Time.deltaTime;
        foreach (UIItem UI in UIItems)
        {
            if (UI.logic.IsVisiable)
            {
                UI.logic.OnUpdate(dt);
            }
        }
    }
    void Destroy()
    {
        foreach (UIItem UI in UIItems)
        {
            UI.logic.OnClose();
            UI.logic.OnDestroy();
        }
    }

    public void ShowUI(string name, object userData = null)
    {
        UIItem ui;
        if (mUIItemDic.TryGetValue(name, out ui))
        {
            ui.logic.OnOpen(userData);
        }
        else
        {
            Debug.LogError(" Not Find UIName : " + name);
        }
    }

    public void CloseUI(string name)
    {
        UIItem ui;
        if (mUIItemDic.TryGetValue(name, out ui))
        {
            ui.logic.OnClose();
        }
        else
        {
            Debug.LogError(name + "Not Find UIName ");
        }
    }

    public void ShowError(string str, float duration, bool showMask, bool canClose)
    {
        UIItem ui;
        if (mUIItemDic.TryGetValue("Tip", out ui))
        {
            if (!ui.logic.IsVisiable)
            {
                ui.logic.OnOpen();
            }
            Game.Event.Broadcast<string, float, Color, bool, bool>(EventType.Tip, str, duration, Color.red, showMask, canClose);
        }
    }
    public void ShowTip(string tip, float duration)
    {
        ShowTip(tip, duration, false, false);
    }
    public void ShowTip(string tip, float duration, bool showMask, bool canClose)
    {
        UIItem ui;
        if (mUIItemDic.TryGetValue("Tip", out ui))
        {
            if (!ui.logic.IsVisiable)
            {
                ui.logic.OnOpen();
            }
            Game.Event.Broadcast<string, float, Color, bool, bool>(EventType.Tip, tip, duration, Color.green, showMask, canClose);
        }
    }
}


