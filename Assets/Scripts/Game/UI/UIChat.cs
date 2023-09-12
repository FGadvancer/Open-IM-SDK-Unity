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
            UserID = Game.LocalData.LastUserID,
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
    public void OnRecvHistoryMessage(ErrorCode code, string errMsg, AdvancedHistoryMessageData data)
    {
        if (code == ErrorCode.None)
        {
            chatData = data;
            Game.Player.AddHistoryMessage(conversation.UserID, data);
            RefreshList(chatList, data.MessageList.Length);
        }
        else
        {
            Game.UI.ShowTip(errMsg, 0.2f, false, false);
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
