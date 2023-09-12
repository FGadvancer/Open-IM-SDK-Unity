using System;
using Newtonsoft.Json;
namespace OpenIM
{
    public class IMConfig
    {
        [JsonProperty("platformID")]
        public int PlatformID;
        [JsonProperty("apiAddr")]
        public string ApiAddr;
        [JsonProperty("wsAddr")]
        public string WsAddr;
        [JsonProperty("dataDir")]
        public string DataDir;
        [JsonProperty("logLevel")]
        public uint LogLevel;
        [JsonProperty("isLogStandardOutput")]
        public bool IsLogStandardOutput;
        [JsonProperty("logFilePath")]
        public string LogFilePath;
        [JsonProperty("isExternalExtensions")]
        public bool IsExternalExtensions;
    }
    public class GetHistoryMessageListParams
    {
        public string UserID;
        public string GroupID;
        public string ConversationID;
        public string StartClientMsgID;
        public int Count;
    }
    public class SetConversationStatusParams
    {
        public string UserId;
        public int Status;
    }

    public class SearchLocalMessagesParams
    {
        public string ConversationID;
        public string[] KeywordList;
        public int KeywordListMatchType;
        public string[] SenderUserIDList;
        public int[] MessageTypeList;
        public Int64 SearchTimePosition;
        public Int64 SearchTimePeriod;
        public int PageIndex;
        public int Count;
    }


    public class GetAdvancedHistoryMessageListParams
    {
        [JsonProperty("userID")]
        public string UserID;
        [JsonProperty("lastMinSeq")]
        public Int64 LastMinSeq;
        [JsonProperty("groupID")]
        public string GroupID;
        [JsonProperty("conversationID")]
        public string ConversationID;
        [JsonProperty("startClientMsgID")]
        public string StartClientMsgID;
        [JsonProperty("count")]
        public int Count;
    }
}