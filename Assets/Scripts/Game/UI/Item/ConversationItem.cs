using UnityEngine.UI;
using TMPro;
using UnityEngine;
using OpenIM;
using System;
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
        Debug.Log(JsonUtility.ToJson(conversation));
        Game.Http.SetImage(icon, conversation.faceURL);
        name.text = conversation.showName;
        // lastMessage.text = conversation.latestMsg;
        var dateTime = new DateTime(conversation.latestMsgSendTime);
        time.text = string.Format("{0}:{1}", dateTime.Hour, dateTime.Minute);
    }
}