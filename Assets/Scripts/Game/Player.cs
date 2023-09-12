using System.Collections.Generic;
using OpenIM;
public class Player
{
    public string UserID;
    public List<LocalConversation> ConversationData;
    Dictionary<string, AdvancedHistoryMessageData> mHistoryMsgDic;

    public Player(string userID)
    {
        UserID = userID;
        mHistoryMsgDic = new Dictionary<string, AdvancedHistoryMessageData>();
    }

    public void AddHistoryMessage(string userID, AdvancedHistoryMessageData data)
    {
        if (mHistoryMsgDic.ContainsKey(userID))
        {
            mHistoryMsgDic.Remove(userID);
        }
        mHistoryMsgDic.Add(userID, data);
    }

    public AdvancedHistoryMessageData GetHistoryMessage(string userID)
    {
        AdvancedHistoryMessageData data = null;
        mHistoryMsgDic.TryGetValue(userID, out data);
        return data;
    }
    public bool HasHistory(string userID)
    {
        return mHistoryMsgDic.ContainsKey(userID);
    }
}