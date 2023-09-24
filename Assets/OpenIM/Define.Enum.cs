using System;
using System.Collections.Generic;
using UnityEngine;
namespace OpenIM
{
    public enum ErrorCode
    {
        None = 0,
        LoginRepeatError = 10102
    }
    public enum EventId
    {
        CONNECTING,
        CONNECT_SUCCESS,
        CONNECT_FAILED,
        KICKED_OFFLINE,
        USER_TOKEN_EXPIRED,
        JOINED_GROUP_ADDED,
        JOINED_GROUP_DELETED,
        GROUP_MEMBER_ADDED,
        GROUP_MEMBER_DELETED,
        GROUP_APPLICATION_ADDED,
        GROUP_APPLICATION_DELETED,
        GROUP_INFO_CHANGED,
        GROUP_DISMISSED,
        GROUP_MEMBER_INFO_CHANGED,
        GROUP_APPLICATION_ACCEPTED,
        GROUP_APPLICATION_REJECTED,
        FRIEND_APPLICATION_ADDED,
        FRIEND_APPLICATION_DELETED,
        FRIEND_APPLICATION_ACCEPTED,
        FRIEND_APPLICATION_REJECTED,
        FRIEND_ADDED,
        FRIEND_DELETED,
        FRIEND_INFO_CHANGED,
        BLACK_ADDED,
        BLACK_DELETED,
        SYNC_SERVER_START,
        SYNC_SERVER_FINISH,
        SYNC_SERVER_PROGRESS,
        SYNC_SERVER_FAILED,
        NEW_CONVERSATION,
        CONVERSATION_CHANGED,
        TOTAL_UNREAD_MESSAGE_COUNT_CHANGED,
        RECV_NEW_MESSAGE,
        RECV_C2C_READ_RECEIPT,
        RECV_GROUP_READ_RECEIPT,
        NEW_RECV_MESSAGE_REVOKED,
        RECV_MESSAGE_EXTENSIONS_CHANGED,
        RECV_MESSAGE_EXTENSIONS_DELETED,
        RECV_MESSAGE_EXTENSIONS_ADDED,
        RECV_OFFLINE_NEW_MESSAGE,
        MSG_DELETED,
        RECV_NEW_MESSAGES,
        RECV_OFFLINE_NEW_MESSAGES,
        SELF_INFO_UPDATED,
        USER_STATUS_CHANGED,
        RECV_CUSTOM_BUSINESS_MESSAGE,
        MESSAGE_KV_INFO_CHANGED,
        UPLOAD_FILE_CALLBACK_OPEN,
        UPLOAD_FILE_CALLBACK_PART_SIZE,
        UPLOAD_FILE_CALLBACK_HASH_PART_PROGRESS,
        UPLOAD_FILE_CALLBACK_HASH_PART_COMPLETE,
        UPLOAD_FILE_CALLBACK_UPLOAD_ID,
        UPLOAD_FILE_CALLBACK_UPLOAD_PART_COMPLETE,
        UPLOAD_FILE_CALLBACK_UPLOAD_COMPLETE,
        UPLOAD_FILE_CALLBACK_COMPLETE,
    }
    public enum LoginStatus
    {
        Logout = 1,
        Logging = 2,
        Logged = 3,
    }
    public enum MsgStatus
    {
        Default,
        Sending,
        SendSuccess,
        SendFailed,
        Deleted,
        Filtered,
    }
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
}

