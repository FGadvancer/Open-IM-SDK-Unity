using System;

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