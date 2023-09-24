using UnityEngine.UI;
using TMPro;
using UnityEngine;
using OpenIM;
using System;
public class MessageItem
{
    UILogicBase ui;
    Transform parent;

    Image icon;
    TextMeshProUGUI message;
    public MessageItem(UILogicBase ui, Transform parent)
    {
        this.ui = ui;
        this.parent = parent;
        icon = ui.GetComponent<Image>(parent, "icon");
        message = ui.GetComponent<TextMeshProUGUI>(parent, "message/txt");
    }

    public void SetItemInfo(bool isSelf, MsgStruct msg)
    {
        message.text = msg.TextElem.Content;
          
    }
}