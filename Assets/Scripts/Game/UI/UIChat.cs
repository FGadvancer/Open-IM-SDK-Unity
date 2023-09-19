using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OpenIM;
using System.Collections.Generic;
using SuperScrollView;
public class UIChat : UILogicBase
{
    TextMeshProUGUI name;
    LoopListView2 chatList;
    TMP_InputField inputMsg;
    Button sendBtn;
    Button closeBtn;

    LocalConversation conversation;
    AdvancedHistoryMessageData chatData;
    public override void Init()
    {
        name = GetComponent<TextMeshProUGUI>("name");
        chatList = GetComponent<LoopListView2>("list");
        inputMsg = GetComponent<TMP_InputField>("message");
        sendBtn = GetComponent<Button>("send");
        closeBtn = GetComponent<Button>("close");
    }
    public override void OnDestroy()
    {
    }
    public override void OnOpen(object userData)
    {
        conversation = userData as LocalConversation;
        name.text = conversation.ShowName;
        var args = new GetAdvancedHistoryMessageListParams()
        {
            UserID = Game.Player.UserID,
            LastMinSeq = conversation.MinSeq,
            GroupID = conversation.GroupID,
            ConversationID = conversation.ConversationID,
            StartClientMsgID = "",
            Count = 10,
        };
        OnClick(closeBtn, () =>
        {
            Game.UI.CloseUI("Chat");
        });
        OnClick(sendBtn, () =>
        {
            if (inputMsg.text == "")
            {
                Game.UI.ShowTip("Message Cant Empty", 2.0f);
                return;
            }
            var message = OpenIMSDK.CreateTextMessage(inputMsg.text);
            Debug.Log(message);
            for (int i = 0; i < 1000; i++)
            {
                OpenIMSDK.SendMessage(message, conversation.UserID, conversation.GroupID, "{}", OnSendMessage);
            }
        });

        chatList.InitListView(0, (view, index) =>
        {
            if (index < 0) return null;
            var data = chatData.MessageList[index];
            bool isSelf = data.SendID == Game.Player.UserID;
            var obj = view.NewListViewItem(isSelf ? "item2" : "item1");
            if (!obj.IsInitHandlerCalled)
            {
                obj.UserObjectData = new MessageItem(this, obj.transform);
                obj.IsInitHandlerCalled = true;
            }
            var item = obj.UserObjectData as MessageItem;
            item.SetItemInfo(isSelf, data);
            return obj;
        });
        if (!Game.Player.HasHistory(conversation.UserID))
        {
            OpenIMSDK.GetAdvancedHistoryMessageList(OnRecvHistoryMessage, args);
        }
        else
        {
            chatData = Game.Player.GetHistoryMessage(conversation.UserID);
            RefreshList(chatList, chatData.MessageList.Length);
        }
    }

    public void OnSendMessage(string operationId, ErrorCode errorCode, string errMsg, string data, int progress)
    {
        Debug.Log(operationId + errorCode + errMsg + data + progress);
    }

    public void OnRecvHistoryMessage(string operationId, ErrorCode code, string errMsg, AdvancedHistoryMessageData data)
    {
        Debug.Log(operationId + "　" + code + " " + errMsg);
        if (code == ErrorCode.None)
        {
            chatData = data;
            Game.Player.AddHistoryMessage(conversation.UserID, data);
            RefreshList(chatList, data.MessageList.Length);
        }
        else
        {
            Game.UI.ShowTip(errMsg, 2f, false, false);
        }
    }
    public override void OnUpdate(float dt)
    {

    }
    public override void OnClose()
    {
        chatList.Reset();
    }
}
