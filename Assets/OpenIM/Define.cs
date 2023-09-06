using System;
using System.Collections.Generic;
using UnityEngine;
namespace OpenIM
{
    public enum PlatFormID
    {
        None = 0,
        IOSPlatformID = 1,
        AndroidPlatformID = 2,
        WindowsPlatformID = 3,
        OSXPlatformID = 4,
        WebPlatformID = 5,
        MiniWebPlatformID = 6,
        LinuxPlatformID = 7,
        AndroidPadPlatformID = 8,
        IPadPlatformID = 9,
        AdminPlatformID = 10,
    }

    [Serializable]
    public class IMConfig
    {
        public PlatFormID platformID = GetPlatFormID();
        public string apiAddr;
        public string wsAddr;
        public string dataDir;
        public int logLevel;
        public bool isLogStandardOutput;
        public string logFilePath;
        public bool isExternalExtensions;

        public IMConfig(string a, string w, string d, int l, bool ilso, string lfp, bool iee)
        {
            apiAddr = a;
            wsAddr = w;
            dataDir = d;
            logLevel = l;
            isLogStandardOutput = ilso;
            logFilePath = lfp;
            isExternalExtensions = iee;
        }

        public static PlatFormID GetPlatFormID()
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE || UNITY_STANDALONE_WIN
            return PlatFormID.WindowsPlatformID;
#elif UNITY_ANDROID
            return PlatFormID.AndroidPadPlatformID;
#elif UNITY_IOS
            return PlatFormID.IOSPlatformID;
#endif
        }
    }
    [Serializable]
    public class OfflinePushInfo
    {
        public string title;
        public string desc;
        public string ex;
        public string iOSPushSound;
        public bool iOSBadgeCount;
        public string signalInfo;
    }

    [Serializable]
    public class TextElem
    {
        public string content;
    }

    [Serializable]
    public class CardElem
    {

        public string userID;
        public string nickname;
        public string faceURL;
        public string ex;
    }
    [Serializable]
    public class PictureBaseInfo
    {
        public string uuid;
        public string type;
        public Int64 size;
        public int width;
        public int height;
        public string url;
    }

    [Serializable]
    public class PictureElem
    {
        public string sourcePath;
        public PictureBaseInfo sourcePicture;
        public PictureBaseInfo bigPicture;
        public PictureBaseInfo snapshotPicture;
    }

    [Serializable]
    public class SoundElem
    {
        public string uuid;
        public string soundPath;
        public string sourceURL;
        public Int64 dataSize;
        public Int64 duration;
        public string soundType;
    }

    [Serializable]
    public class VideoElem
    {
        public string videoPath;
        public string videoUUID;
        public string videoUrl;
        public string videoType;
        public Int64 videoSize;
        public Int64 duration;
        public string snapshotPath;
        public string snapshotUUID;
        public Int64 snapshotSize;
        public string snapshotUrl;
        public int snapshotWidth;
        public int snapshotHeight;
        public string snapshotType;
    }

    [Serializable]
    public class FileElem
    {
        public string filePath;
        public string uuid;
        public string sourceUrl;
        public string fileName;
        public Int64 fileSize;
        public string fileType;
    }

    [Serializable]
    public class FaceElem
    {

        public int index;
        public string data;
    }

    [Serializable]
    public class LocationElem
    {
        public string description;
        public float longitude;
        public float latitude;
    }

    [Serializable]
    public class CustomElem
    {

        public string data;
        public string description;
        public string extension;
    }

    [Serializable]
    public class MessageEntity
    {
        public string type;
        public int offset;
        public int length;
        public string url;
        public string ex;
    }
    [Serializable]
    public class QuoteElem
    {
        public string text;
        public Message quoteMessage;
        public MessageEntity[] messageEntityList;
    }

    [Serializable]
    public class NotificationElem
    {
        public string detail;
    }

    [Serializable]
    public class AdvancedTextElem
    {
        public string text;
        public MessageEntity[] messageEntityList;
    }

    [Serializable]
    public class TypingElem
    {
        public string msgTips;
    }

    [Serializable]
    public class Message
    {
        public string clientMsgID;
        public string serverMsgID;
        public Int64 createTime;
        public Int64 sendTime;
        public int sessionType;
        public string sendID;
        public string recvID;
        public int msgFrom;
        public int contentType;
        public int senderPlatformID;
        public string senderNickname;
        public string senderFaceURL;
        public string groupID;
        public string content;
        public Int64 seq;
        public bool isRead;
        public int status;
        public bool isReact;
        public bool isExternalExtensions;
        public OfflinePushInfo offlinePush;
        public string attachedInfo;
        public string ex;
        public string localEx;
        public TextElem textElem;
        public CardElem cardElem;
        public PictureElem pictureElem;
        public SoundElem soundElem;
        public VideoElem videoElem;
        public FileElem fileElem;
        // public MergeElem mergeElem;
        // public AtTextElem atTextElem;
        public FaceElem faceElem;
        public LocationElem locationElem;
        public CustomElem customElem;
        public QuoteElem quoteElem;
        public NotificationElem notificationElem;
        public AdvancedTextElem advancedTextElem;
        public TypingElem typingElem;
        // public AttachedInfoElem attachedInfoElem;
    }

    [Serializable]
    public class Conversation
    {
        private Message _latestMsg;
        public string conversationID;
        public int conversationType;
        public string userID;
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

        public Message GetLatestMsg()
        {
            if (_latestMsg == null)
            {
                _latestMsg = JsonUtil.FromJson<Message>(latestMsg);
            }
            return _latestMsg;
        }
    }

}

