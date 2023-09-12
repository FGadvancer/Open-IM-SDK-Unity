using System;
using Newtonsoft.Json;
namespace OpenIM
{
    public class MessageReceipt
    {
        public string GroupID;
        public string UserID;
        public string[] MsgIDList;
        public Int64 ReadTime;
        public int MsgFrom;
        public int ContentType;
        public int SessionType;
    }

    public class MessageRevoked
    {
        public string RevokerID;
        public int RevokerRole;
        public string ClientMsgID;
        public string RevokerNickname;
        public Int64 RevokeTime;
        public Int64 SourceMessageSendTime;
        public string SourceMessageSendID;
        public string SourceMessageSenderNickname;
        public int SessionType;
        public Int64 Seq;
        public string Ex;
        public bool IsAdminRevoke;
    }

    public class MessageReaction
    {
        public string ClientMsgID;
        public int ReactionType;
        public int Counter;
        public string UserID;
        public string GroupID;
        public int SessionType;
        public string Info;
    }

    public class ImageInfo
    {
        public int Width;
        public int Height;
        public string Type;
        public Int64 Size;
    }

    public class PictureBaseInfo
    {
        public string UUID;
        public string Type;
        public Int64 Size;
        public int Width;
        public int Height;
        public string Url;
    }

    public class SoundBaseInfo
    {
        public string UUID;
        public string SoundPath;
        public string SourceURL;
        public Int64 DataSize;
        public Int64 Duration;
        public string SoundType;
    }

    public class VideoBaseInfo
    {
        public string VideoPath;
        public string VideoUUID;
        public string VideoURL;
        public string VideoType;
        public Int64 VideoSize;
        public Int64 Duration;
        public string SnapshotPath;
        public string SnapshotUUID;
        public Int64 SnapshotSize;
        public string SnapshotURL;
        public int SnapshotWidth;
        public int SnapshotHeight;
        public string SnapshotType;
    }

    public class FileBaseInfo
    {
        public string FilePath;
        public string UUID;
        public string SourceURL;
        public string FileName;
        public Int64 FileSize;
        public string FileType;
    }

    public class TextElem
    {
        public string Content;
    }

    public class CardElem
    {
        public string UserID;
        public string Nickname;
        public string FaceURL;
        public string Ex;
    }

    public class PictureElem
    {
        public string SourcePath;
        public PictureBaseInfo SourcePicture;
        public PictureBaseInfo BigPicture;
        public PictureBaseInfo SnapshotPicture;
    }

    public class SoundElem
    {
        public string UUID;
        public string SoundPath;
        public string SourceURL;
        public Int64 DataSize;
        public Int64 Duration;
        public string SoundType;
    }

    public class VideoElem
    {
        public string VideoPath;
        public string VideoUUID;
        public string VideoURL;
        public string VideoType;
        public Int64 VideoSize;
        public Int64 Duration;
        public string SnapshotPath;
        public string SnapshotUUID;
        public Int64 SnapshotSize;
        public string SnapshotURL;
        public int SnapshotWidth;
        public int SnapshotHeight;
        public string SnapshotType;
    }

    public class FileElem
    {
        public string FilePath;
        public string UUID;
        public string SourceURL;
        public string FileName;
        public Int64 FileSize;
        public string FileType;
    }

    public class MergeElem
    {
        public string Title;
        public string[] AbstractList;
        public MsgStruct[] MultiMessage;
        public MessageEntity[] MessageEntityList;
    }

    public class AtTextElem
    {
        public string Text;
        public string[] AtUserList;
        public AtInfo[] AtUsersInfo;
        public MsgStruct QuoteMessage;
        public bool IsAtSelf;
    }

    public class FaceElem
    {
        public int Index;
        public string Data;
    }

    public class LocationElem
    {
        public string Description;
        public double Longitude;
        public double Latitude;
    }

    public class CustomElem
    {
        public string Data;
        public string Description;
        public string Extension;
    }

    public class QuoteElem
    {
        public string Text;
        public MsgStruct QuoteMessage;
        public MessageEntity[] MessageEntityList;
    }

    public class NotificationElem
    {
        public string Detail;
    }

    public class AdvancedTextElem
    {
        public string Text;
        public MessageEntity[] MessageEntityList;
    }

    public class TypingElem
    {
        public string MsgTips;
    }

    public class MsgStruct
    {
        public string ClientMsgID;
        public string ServerMsgID;
        public Int64 CreateTime;
        public Int64 SendTime;
        public int SessionType;
        public string SendID;
        public string RecvID;
        public int MsgFrom;
        public int ContentType;
        public int SenderPlatformID;
        public string SenderNickname;
        public string SenderFaceURL;
        public string GroupID;
        public string Content;
        public Int64 Seq;
        public bool IsRead;
        public int Status;
        public bool IsReact;
        public bool IsExternalExtensions;
        // public sdkws.OfflinePushInfo OfflinePush;
        public string AttachedInfo;
        public string Ex;
        public string LocalEx;
        public TextElem TextElem;
        public CardElem CardElem;
        public PictureElem PictureElem;
        public SoundElem SoundElem;
        public VideoElem VideoElem;
        public FileElem FileElem;
        public MergeElem MergeElem;
        public AtTextElem AtTextElem;
        public FaceElem FaceElem;
        public LocationElem LocationElem;
        public CustomElem CustomElem;
        public QuoteElem QuoteElem;
        public NotificationElem NotificationElem;
        public AdvancedTextElem AdvancedTextElem;
        public TypingElem TypingElem;
        public AttachedInfoElem AttachedInfoElem;
    }

    public class AtInfo
    {
        public string AtUserID;
        public string GroupNickname;
    }

    public class AttachedInfoElem
    {
        public GroupHasReadInfo GroupHasReadInfo;
        public bool IsPrivateChat;
        public int BurnDuration;
        public Int64 HasReadTime;
        public bool NotSenderNotificationPush;
        public MessageEntity[] MessageEntityList;
        public bool IsEncryption;
        public bool InEncryptStatus;
        public ReactionElem[] MessageReactionElem;
        public UploadProgress Progress;
    }

    public class UploadProgress
    {
        public Int64 Total;
        public Int64 Save;
        public Int64 Current;
        public string UploadID;
    }

    public class ReactionElem
    {
        public int Counter;
        public int Type;
        public UserReactionElem[] UserReactionList;
        public bool CanRepeat;
        public string Info;
    }

    public class UserReactionElem
    {
        public string UserID;
        public int Counter;
        public string Info;
    }

    public class MessageEntity
    {
        public string Type;
        public int Offset;
        public int Length;
        public string Url;
        public string Ex;
    }

    public class GroupHasReadInfo
    {
        public string[] HasReadUserIDList;
        public int HasReadCount;
        public int GroupMemberCount;
    }

    

    public class CmdJoinedSuperGroup
    {
        public string OperationID;
    }

    public class OANotificationElem
    {
        public string NotificationName;
        public string NotificationFaceURL;
        public int NotificationType;
        public string Text;
        public string Url;
        public int MixType;
        // public struct Image;
        public string SourceUrl;
        public string SnapshotUrl;
        // public string SourceUrl;
        // public string SnapshotUrl;
        public Int64 Duration;
        // public string SourceUrl;
        public string FileName;
        public Int64 FileSize;
    }

    public class MsgDeleteNotificationElem
    {
        public string GroupID;
        public bool IsAllDelete;
        public string[] SeqList;
    }
    public class LocalFriend
    {
        public string OwnerUserID;
        public string FriendUserID;
        public string Remark;
        public Int64 CreateTime;
        public int AddSource;
        public string OperatorUserID;
        public string Nickname;
        public string FaceURL;
        // public int //Gender; 
        // public string //PhoneNumber; 
        // public uint //Birth; 
        // public string //Email; 
        // public string Ex;
        public string AttachedInfo;
    }

    public class LocalFriendRequest
    {
        public string FromUserID;
        public string FromNickname;
        public string FromFaceURL;
        // public int //FromGender; 
        public string ToUserID;
        public string ToNickname;
        public string ToFaceURL;
        // public int //ToGender; 
        public int HandleResult;
        public string ReqMsg;
        public Int64 CreateTime;
        public string HandlerUserID;
        public string HandleMsg;
        public Int64 HandleTime;
        public string Ex;
        public string AttachedInfo;
    }

    public class LocalGroup
    {
        public string GroupID;
        public string GroupName;
        public string Notification;
        public string Introduction;
        public string FaceURL;
        public Int64 CreateTime;
        public int Status;
        public string CreatorUserID;
        public int GroupType;
        public string OwnerUserID;
        public int MemberCount;
        public string Ex;
        public string AttachedInfo;
        public int NeedVerification;
        public int LookMemberInfo;
        public int ApplyMemberFriend;
        public Int64 NotificationUpdateTime;
        public string NotificationUserID;
    }

    public class LocalGroupMember
    {
        public string GroupID;
        public string UserID;
        public string Nickname;
        public string FaceURL;
        public int RoleLevel;
        public Int64 JoinTime;
        public int JoinSource;
        public string InviterUserID;
        public Int64 MuteEndTime;
        public string OperatorUserID;
        public string Ex;
        public string AttachedInfo;
    }

    public class LocalGroupRequest
    {
        public string GroupID;
        public string GroupName;
        public string Notification;
        public string Introduction;
        public string GroupFaceURL;
        public Int64 CreateTime;
        public int Status;
        public string CreatorUserID;
        public int GroupType;
        public string OwnerUserID;
        public int MemberCount;
        public string UserID;
        public string Nickname;
        public string UserFaceURL;
        // public int //Gender; 
        public int HandleResult;
        public string ReqMsg;
        public string HandledMsg;
        public Int64 ReqTime;
        public string HandleUserID;
        public Int64 HandledTime;
        public string Ex;
        public string AttachedInfo;
        public int JoinSource;
        public string InviterUserID;
    }

    public class LocalUser
    {
        public string UserID;
        public string Nickname;
        public string FaceURL;
        public Int64 CreateTime;
        public int AppMangerLevel;
        public string Ex;
        public string AttachedInfo;
        public int GlobalRecvMsgOpt;
    }

    public class LocalBlack
    {
        public string OwnerUserID;
        public string BlockUserID;
        public string Nickname;
        public string FaceURL;
        // public int //Gender; 
        public Int64 CreateTime;
        public int AddSource;
        public string OperatorUserID;
        public string Ex;
        public string AttachedInfo;
    }

    public class LocalSeqData
    {
        public string UserID;
        public uint Seq;
    }

    public class LocalSeq
    {
        public string ID;
        public uint MinSeq;
    }

    public class LocalChatLog
    {
        public string ClientMsgID;
        public string ServerMsgID;
        public string SendID;
        public string RecvID;
        public int SenderPlatformID;
        public string SenderNickname;
        public string SenderFaceURL;
        public int SessionType;
        public int MsgFrom;
        public int ContentType;
        public string Content;
        public bool IsRead;
        public int Status;
        public Int64 Seq;
        public Int64 SendTime;
        public Int64 CreateTime;
        public string AttachedInfo;
        public string Ex;
        public string LocalEx;
        public bool IsReact;
        public bool IsExternalExtensions;
        public Int64 MsgFirstModifyTime;
    }

    public class LocalErrChatLog
    {
        public Int64 Seq;
        public string ClientMsgID;
        public string ServerMsgID;
        public string SendID;
        public string RecvID;
        public int SenderPlatformID;
        public string SenderNickname;
        public string SenderFaceURL;
        public int SessionType;
        public int MsgFrom;
        public int ContentType;
        public string Content;
        public bool IsRead;
        public int Status;
        public Int64 SendTime;
        public Int64 CreateTime;
        public string AttachedInfo;
        public string Ex;
    }

    public class TempCacheLocalChatLog
    {
        public string ClientMsgID;
        public string ServerMsgID;
        public string SendID;
        public string RecvID;
        public int SenderPlatformID;
        public string SenderNickname;
        public string SenderFaceURL;
        public int SessionType;
        public int MsgFrom;
        public int ContentType;
        public string Content;
        public bool IsRead;
        public int Status;
        public Int64 Seq;
        public Int64 SendTime;
        public Int64 CreateTime;
        public string AttachedInfo;
        public string Ex;
    }

    public class LocalConversation
    {
        public string ConversationID;
        public int ConversationType;
        public string UserID;
        public string GroupID;
        public string ShowName;
        public string FaceURL;
        public int RecvMsgOpt;
        public int UnreadCount;
        public int GroupAtType;
        public string LatestMsg;
        public Int64 LatestMsgSendTime;
        public string DraftText;
        public Int64 DraftTextTime;
        public bool IsPinned;
        public bool IsPrivateChat;
        public int BurnDuration;
        public bool IsNotInGroup;
        public Int64 UpdateUnreadCountTime;
        public string AttachedInfo;
        public string Ex;
        public Int64 MaxSeq;
        public Int64 MinSeq;
        public Int64 HasReadSeq;
        public Int64 MsgDestructTime;
        public bool IsMsgDestruct;

        MsgStruct LatestMsgStruct;
        public MsgStruct GetLatestMsg()
        {
            if (LatestMsgStruct == null)
            {
                LatestMsgStruct = JsonUtil.FromJson<MsgStruct>(LatestMsg);
            }
            return LatestMsgStruct;
        }
    }

    public class LocalConversationUnreadMessage
    {
        public string ConversationID;
        public string ClientMsgID;
        public Int64 SendTime;
        public string Ex;
    }

    public class LocalAdminGroupRequest
    {
    }

    public class LocalChatLogReactionExtensions
    {
        public string ClientMsgID;
        public byte[] LocalReactionExtensions;
    }

    public class LocalWorkMomentsNotification
    {
        public string JsonDetail;
        public Int64 CreateTime;
    }

    public class WorkMomentNotificationMsg
    {
        public int NotificationMsgType;
        public string ReplyUserName;
        public string ReplyUserID;
        public string Content;
        public string ContentID;
        public string WorkMomentID;
        public string UserID;
        public string UserName;
        public string FaceURL;
        public string WorkMomentContent;
        public int CreateTime;
    }

    public class LocalWorkMomentsNotificationUnreadCount
    {
        public int UnreadCount;
    }

    public class NotificationSeqs
    {
        public string ConversationID;
        public Int64 Seq;
    }

    public class LocalUpload
    {
        public string PartHash;
        public string UploadID;
        public string UploadInfo;
        public Int64 ExpireTime;
        public Int64 CreateTime;
    }

    public class ConversationArgs
    {
        public string ConversationID;
        public string[] ClientMsgIDList;
    }

    public class FindMessageListCallback
    {
        public int TotalCount;
        public SearchByConversationResult[] FindResultItems;
    }

    public class AdvancedHistoryMessageData
    {
        public MsgStruct[] MessageList;
        public Int64 LastMinSeq;
        public bool IsEnd;
        public int ErrCode;
        public string ErrMsg;
    }

    public class SearchLocalMessagesCallback
    {
        public int TotalCount;
        public SearchByConversationResult[] SearchResultItems;
    }

    public class SearchByConversationResult
    {
        public string ConversationID;
        public int ConversationType;
        public string ShowName;
        public string FaceURL;
        public int MessageCount;
        public MsgStruct[] MessageList;
    }

    public class SetMessageReactionExtensionsCallback
    {
        public string Key;
        public string Value;
        public int ErrCode;
        public string ErrMsg;
    }

    public class AddMessageReactionExtensionsCallback
    {
        public string Key;
        public string Value;
        public int ErrCode;
        public string ErrMsg;
    }

    public class GetTypekeyListResp
    {
        public SingleTypeKeyInfoSum[] TypeKeyInfoList;
    }

    public class SingleTypeKeyInfoSum
    {
        public string TypeKey;
        public Int64 Counter;
        public Info[] InfoList;
        public bool IsContainSelf;
    }

    public class SingleTypeKeyInfo
    {
        public string TypeKey;
        public Int64 Counter;
        public bool IsCanRepeat;
        public int Index;
        // public map[string] Info InfoList; 
    }

    public class Info
    {
        public string UserID;
        public string Ex;
    }

    public class AddFriendParams
    {
        public string ToUserID;
        public string ReqMsg;
    }

    public class ProcessFriendApplicationParams
    {
        public string ToUserID;
        public string HandleMsg;
    }

    public class SearchFriendsParam
    {
        public string[] KeywordList;
        public bool IsSearchUserID;
        public bool IsSearchNickname;
        public bool IsSearchRemark;
    }

    public class GetFriendListPage
    {
    }

    public class SearchFriendItem
    {
        public int Relationship;
    }

    public class SetFriendRemarkParams
    {
        public string ToUserID;
        public string Remark;
    }

    public class CreateGroupBaseInfoParam
    {
        public int GroupType;
    }

    public class SearchGroupsParam
    {
        public string[] KeywordList;
        public bool IsSearchGroupID;
        public bool IsSearchGroupName;
    }

    public class SearchGroupMembersParam
    {
        public string GroupID;
        public string[] KeywordList;
        public bool IsSearchUserID;
        public bool IsSearchMemberNickname;
        // public count //offset,; 
        public int Offset;
        public int Count;
    }

    public class SetGroupInfoParam
    {
        public string GroupName;
        public string Notification;
        public string Introduction;
        public string FaceURL;
        public string Ex;
        public int NeedVerification;
    }

    public class SetGroupMemberInfoParam
    {
        public string GroupID;
        public string UserID;
        public string Ex;
    }
}