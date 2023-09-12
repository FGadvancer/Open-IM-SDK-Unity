using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using SuperScrollView;
using OpenIM;
using System.Collections.Generic;
public enum MenuTab
{
    Chat, AddressBook, Work, My
}

public partial class UIMain : UILogicBase
{

    Transform chatTrans;
    Transform addressBookTrans;
    Transform workTrans;
    Transform myTrans;
    Toggle chatToggle;
    Toggle addressBookToggle;
    Toggle workToggle;
    Toggle myToggle;

    MenuTab curTab;

    public override void Init()
    {
        InitChat();
        InitMy();
        chatTrans = GetComponent<RectTransform>("chat");
        addressBookTrans = GetComponent<RectTransform>("addressbook");
        workTrans = GetComponent<RectTransform>("work");
        myTrans = GetComponent<RectTransform>("my");
        chatToggle = GetComponent<Toggle>("bottom/chat");
        addressBookToggle = GetComponent<Toggle>("bottom/addressbook");
        workToggle = GetComponent<Toggle>("bottom/work");
        myToggle = GetComponent<Toggle>("bottom/my");
    }
    public override void OnOpen(object userData)
    {
        OpenChat();
        OpenMy();

        OnToggle(chatToggle, (isOn) =>
        {
            if (isOn) { ShowTab(MenuTab.Chat); }
        });
        OnToggle(addressBookToggle, (isOn) =>
        {
            if (isOn) { ShowTab(MenuTab.AddressBook); }
        });
        OnToggle(workToggle, (isOn) =>
        {
            if (isOn) { ShowTab(MenuTab.Work); }
        });
        OnToggle(myToggle, (isOn) =>
        {
            if (isOn) { ShowTab(MenuTab.My); }
        });

        chatToggle.isOn = true;
        addressBookToggle.isOn = false;
        workToggle.isOn = false;
        myToggle.isOn = false;
        ShowTab(MenuTab.Chat);
    }

    public void ShowTab(MenuTab tab)
    {
        curTab = tab;
        chatTrans.gameObject.SetActive(tab == MenuTab.Chat);
        addressBookTrans.gameObject.SetActive(tab == MenuTab.AddressBook);
        workTrans.gameObject.SetActive(tab == MenuTab.Work);
        myTrans.gameObject.SetActive(tab == MenuTab.My);
    }




    public override void OnUpdate(float dt)
    {

    }

    public override void OnClose()
    {
        CloseChat();
        CloseMy();
    }

    public override void OnDestroy()
    {
    }
}
