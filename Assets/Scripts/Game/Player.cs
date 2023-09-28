using System.Collections.Generic;
using OpenIM;
public class Player
{
    public string UserID;
    public string Token;
    List<LocalConversation> mConversationData;
    Dictionary<string, List<MsgStruct>> mHistoryMsgDic;

    public List<LocalConversation> ConversationData
    {
        get
        {
            return mConversationData;
        }
        set
        {
            mConversationData = value;
        }
    }
    public Player(string userID)
    {
        UserID = userID;
        mHistoryMsgDic = new Dictionary<string, List<MsgStruct>>();
    }

    public void AddMsgRecord(string userID, MsgStruct msg)
    {
        List<MsgStruct> data;
        mHistoryMsgDic.TryGetValue(userID, out data);
        if (data == null)
        {
            data = new List<MsgStruct>();
            mHistoryMsgDic.Add(userID, data);
        }
        data.Add(msg);
    }

    public List<MsgStruct> GetMsgRecord(string userID)
    {
        List<MsgStruct> data;
        mHistoryMsgDic.TryGetValue(userID, out data);
        if (data == null)
        {
            data = new List<MsgStruct>();
            mHistoryMsgDic.Add(userID, data);
        }
        return data;
    }
    public bool HasHistory(string userID)
    {
        return mHistoryMsgDic.ContainsKey(userID);
    }
}