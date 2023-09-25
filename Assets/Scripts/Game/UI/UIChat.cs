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
    List<MsgStruct> msgDatas;
    public override void Init()
    {
        name = GetComponent<TextMeshProUGUI>("name");
        chatList = GetComponent<LoopListView2>("list");
        inputMsg = GetComponent<TMP_InputField>("bottom/message");
        sendBtn = GetComponent<Button>("bottom/send");
        closeBtn = GetComponent<Button>("close");
    }
    public override void OnDestroy()
    {
    }
    public override void OnOpen(object userData)
    {
        conversation = userData as LocalConversation;
        name.text = conversation.ShowName;

        OnClick(closeBtn, () =>
        {
            Game.UI.CloseUI("Chat");
        });
        OnClick(sendBtn, () =>
        {
            SendMsg();
        });
        inputMsg.onSubmit.RemoveAllListeners();
        inputMsg.onSubmit.AddListener((value) =>
        {
            SendMsg();
        });

        chatList.InitListView(0, (view, index) =>
        {
            if (index < 0) return null;
            var data = msgDatas[index];
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
            var args = new GetAdvancedHistoryMessageListParams()
            {
                UserID = Game.Player.UserID,
                LastMinSeq = conversation.MinSeq,
                GroupID = conversation.GroupID,
                ConversationID = conversation.ConversationID,
                StartClientMsgID = "",
                Count = 10,
            };
            OpenIMSDK.GetAdvancedHistoryMessageList(OnRecvHistoryMessage, args);
        }
        else
        {
            msgDatas = Game.Player.GetMsgRecord(conversation.UserID);
            RefreshList(chatList, msgDatas.Count, msgDatas.Count - 1, 0);
        }
        Game.Event.AddListener<MsgStruct>(EventType.RecvMsg, OnRecvNewMessage);
    }
    public void SendMsg()
    {
        if (inputMsg.text == "")
        {
            Game.UI.ShowTip("Message Cant Empty", 2.0f);
            return;
        }
        var message = OpenIMSDK.CreateTextMessage(inputMsg.text);
        OpenIMSDK.SendMessage(message, conversation.UserID, conversation.GroupID, "{}", OnSendMessage);
        inputMsg.text = "";
        inputMsg.ActivateInputField();
    }
    public void OnSendMessage(string operationId, ErrorCode errorCode, string errMsg, string data, int progress)
    {
        if (errorCode != ErrorCode.None)
        {
            Debug.Log(errorCode + "  " + errMsg);
            Game.UI.ShowError(errMsg, 1.0f, false, false);
            return;
        }
        Debug.Log("Recv => " + data);
        var msg = JsonUtil.FromJson<MsgStruct>(data);
        if (msg != null)
        {
            if (msgDatas[msgDatas.Count - 1].ClientMsgID != msg.ClientMsgID)
            {
                Game.Player.AddMsgRecord(conversation.UserID, msg);
                RefreshList(chatList, msgDatas.Count, msgDatas.Count - 1, 0);
            }
        }
    }

    public void OnRecvHistoryMessage(string operationId, ErrorCode code, string errMsg, AdvancedHistoryMessageData data)
    {
        if (code == ErrorCode.None)
        {
            foreach (var msg in data.MessageList)
            {
                Game.Player.AddMsgRecord(conversation.UserID, msg);
            }
            msgDatas = Game.Player.GetMsgRecord(conversation.UserID);
            RefreshList(chatList, msgDatas.Count, msgDatas.Count - 1, 0);
        }
        else
        {
            Game.UI.ShowTip(errMsg, 2f, false, false);
        }
    }
    public void OnRecvNewMessage(MsgStruct msg)
    {
        RefreshList(chatList, msgDatas.Count, msgDatas.Count - 1, 0);
    }
    public override void OnUpdate(float dt)
    {

    }
    public override void OnClose()
    {
        Game.Event.RemoveListener<MsgStruct>(EventType.RecvMsg, OnRecvNewMessage);
        chatList.Reset();
    }
}
