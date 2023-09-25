using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SuperScrollView;
using OpenIM;
using System.Collections.Generic;
public partial class UIMain
{
    LoopListView2 conversationlist;

    public void InitChat()
    {
        conversationlist = GetComponent<LoopListView2>("chat/list");
    }
    public void OpenChat()
    {
        OpenIMSDK.GetConversationList(OnRecvConversationList);

        conversationlist.InitListView(0, (view, index) =>
        {
            if (index < 0) return null;
            var obj = view.NewListViewItem("item");
            if (!obj.IsInitHandlerCalled)
            {
                obj.UserObjectData = new ConversationItem(this, obj.transform);
                obj.IsInitHandlerCalled = true;
            }
            var item = obj.UserObjectData as ConversationItem;
            item.SetItemInfo(Game.Player.ConversationData[index]);
            return obj;
        });

        Game.Event.AddListener(EventType.OnConversationChange, OnConversationChange);
    }
    public void CloseChat()
    {
        Game.Event.RemoveListener(EventType.OnConversationChange, OnConversationChange);
        conversationlist.Reset();
    }
    public void OnConversationChange()
    {
        OpenIMSDK.GetConversationList(OnRecvConversationList);
    }
    public void OnRecvConversationList(ErrorCode err, string errMsg, List<LocalConversation> list)
    {
        if (err == ErrorCode.None)
        {
            if (list != null)
            {
                Game.Player.ConversationData = list;
                RefreshList(conversationlist, list.Count);
            }
        }
        else
        {
            Debug.LogError(errMsg);
        }
    }
}