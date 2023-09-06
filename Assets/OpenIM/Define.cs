using System;
using System.Collections.Generic;

namespace OpenIM
{

    public enum EventId
    {
        CONNECTING,
        CONNECT_SUCCESS,
        CONNECT_FAILED,
        KICKED_OFFLINE,
        USER_TOKEN_EXPIRED,
    }
    public enum ErrorCode
    {
        None = 0,
        LoginRepeatError = 10102
    }
    [Serializable]
    public class IMConfig
    {
        public int platformID;
        public string apiAddr;
        public string wsAddr;
        public string dataDir;
        public int logLevel;
        public bool isLogStandardOutput;
        public string logFilePath;
        public bool isExternalExtensions;

        public IMConfig(int p, string a, string w, string d, int l, bool ilso, string lfp, bool iee)
        {
            platformID = p;
            apiAddr = a;
            wsAddr = w;
            dataDir = d;
            logLevel = l;
            isLogStandardOutput = ilso;
            logFilePath = lfp;
            isExternalExtensions = iee;
        }
    }


    [Serializable]
    public class Conversation
    {
        public string conversationID;
        public int conversationType;
        public int userID;
        public string groupID;
        public string showName;
        public string faceURL;
        public int recvMsgOpt;
        public int unreadCount;
        public int groupAtType;
        public string latestMsg;
        public Int64 latestMsgSendTime;
        public string draftText;
        public Int64 draftTextTime;
        public bool isPinned;
        public bool isPrivateChat;
        public int burnDuration;
        public bool isNotInGroup;
        public Int64 updateUnreadCountTime;
        public string attachedInfo;
        public string ex;
        public Int64 maxSeq;
        public Int64 minSeq;
        public Int64 hasReadSeq;
        public Int64 msgDestructTime;
        public bool isMsgDestruct;
    }

}

