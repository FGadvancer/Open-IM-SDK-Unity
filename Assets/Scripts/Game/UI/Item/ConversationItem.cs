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

    Button btn;
    public ConversationItem(UILogicBase ui, Transform parent)
    {
        this.ui = ui;
        this.parent = parent;
        icon = ui.GetComponent<Image>(parent, "icon");
        name = ui.GetComponent<TextMeshProUGUI>(parent, "name");
        lastMessage = ui.GetComponent<TextMeshProUGUI>(parent, "message");
        time = ui.GetComponent<TextMeshProUGUI>(parent, "time");
        btn = ui.GetComponent<Button>(parent, "");
    }

    public void SetItemInfo(LocalConversation conversation)
    {
        Game.Http.SetImage(icon, conversation.FaceURL);
        name.text = conversation.ShowName;
        var msg = conversation.GetLatestMsg();
        // Debug.Log(JsonUtil.ToJson(msg));
        if (msg != null)
        {
            lastMessage.text = msg.TextElem.Content;
        }
        else
        {
            lastMessage.text = "";
        }
        time.text = StringUtils.TimeStampToStr1(conversation.LatestMsgSendTime);
        ui.OnClick(btn, () =>
        {
            Game.UI.ShowUI("Chat", conversation);
        });
    }
}