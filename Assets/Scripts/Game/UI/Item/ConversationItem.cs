using UnityEngine.UI;
using TMPro;
using UnityEngine;
using OpenIM;
using System;
using Dawn;
public class ConversationItem
{
    UILogicBase ui;
    Transform parent;
    Image icon;
    TextMeshProUGUI name;
    TextMeshProUGUI lastMessage;
    TextMeshProUGUI time;

    public ConversationItem(UILogicBase ui, Transform parent)
    {
        this.ui = ui;
        this.parent = parent;
        icon = ui.GetComponent<Image>(parent, "icon");
        name = ui.GetComponent<TextMeshProUGUI>(parent, "name");
        lastMessage = ui.GetComponent<TextMeshProUGUI>(parent, "message");
        time = ui.GetComponent<TextMeshProUGUI>(parent, "time");
    }

    public void SetItemInfo(Conversation conversation)
    {
        // Debug.Log(JsonUtil.ToJson(conversation));
        Game.Http.SetImage(icon, conversation.faceURL);
        name.text = conversation.showName;
        var msg = conversation.GetLatestMsg();
        // Debug.Log(JsonUtil.ToJson(msg));
        if (msg != null)
        {
            lastMessage.text = msg.textElem.content;
        }
        else
        {
            lastMessage.text = "";
        }
        time.text = StringUtils.TimeStampToStr1(conversation.latestMsgSendTime);
    }
}