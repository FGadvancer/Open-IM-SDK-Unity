using System;

namespace OpenIM
{
    public delegate void OnConnectStatus(EventId eventId, string data);
    public delegate void OnLoginStatus(ErrorCode errCode, string errMsg, string data);
    public delegate void OnLogOutStatus(ErrorCode errCode, string errMsg, string data);
    public delegate void OnNetworkStatus(ErrorCode errorCode, string errMsg, string data);
    public delegate void OnSendMessage(ErrorCode errorCode, string errMsg, string data, int progress);
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
}