using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SuperScrollView;
using OpenIM;
using System.Collections.Generic;
public partial class UIMain
{
    LoopListView2 conversationlist;

    List<Conversation> conversationData;
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
            item.SetItemInfo(conversationData[index]);
            return obj;
        });
    }
    public void CloseChat()
    {
        conversationlist.Reset();
    }
    public void OnRecvConversationList(ErrorCode err, string errMsg, List<Conversation> list)
    {
        if (err == ErrorCode.None)
        {
            Debug.Log(list.Count);
            if (list != null)
            {
                conversationData = list;
                RefreshList(conversationlist, list.Count);
            }
        }
        else
        {
            Debug.LogError(errMsg);
        }
    }
}