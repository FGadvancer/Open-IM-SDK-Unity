using System;
using System.Runtime.InteropServices;
namespace OpenIM
{
    public delegate void CB_I_S_S_I(int errorCode, string errMsg, string data, int progress);
    public delegate void CB_I_S(int eventID, string data);
    public delegate void CB_I_S_S(int errCode, string errMsg, string data);
    class OpenIMDLL
    {
#if (UNITY_IPHONE || UNITY_TVOS || UNITY_WEBGL || UNITY_SWITCH) && !UNITY_EDITOR
        const string OPENIMDLL = "__Internal";
#else
        const string OPENIMDLL = "openimsdk";
#endif

        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int init_sdk(CB_I_S cb, string operationID, string config);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void un_init_sdk(string operationID);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void login(CB_I_S_S cb, string operationID, string uid, string token);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void logout(CB_I_S_S cb, string operationID);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void network_status_changed(CB_I_S_S cb, string operationID);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int get_login_status(string operationID);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string get_login_user();
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string create_text_message(string operationID, string text);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string create_advanced_text_message(string operationID, string text, string messageEntityList);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string create_text_at_message(string operationID, string text, string atUserList, string atUsersInfo, string message);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string create_location_message(string operationID, string description, double longitude, double latitude);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string create_custom_message(string operationID, string data, string extension, string description);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string create_quote_message(string operationID, string text, string message);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string create_advanced_quote_message(string operationID, string text, string message, string messageEntityList);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string create_card_message(string operationID, string cardInfo);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string create_video_message_from_full_path(string operationID, string videoFullPath, string videoType, long duration, string snapshotFullPath);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string create_image_message_from_full_path(string operationID, string imageFullPath);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string create_sound_message_from_full_path(string operationID, string soundPath, Int64 duration);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string create_file_message_from_full_path(string operationID, string fileFullPath, string fileName);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string create_image_message(string operationID, string imagePath);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string create_image_message_by_url(string operationID, string sourcePicture, string bigPicture, string snapshotPicture);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string create_sound_message_by_url(string operationID, string soundBaseInfo);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string create_sound_message(string operationID, string soundPath, Int64 duration);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string create_video_message_by_url(string operationID, string videoBaseInfo);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string create_video_message(string operationID, string videoPath, string videoType, Int64 duration, string snapshotPath);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string create_file_message_by_url(string operationID, string fileBaseInfo);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string create_file_message(string operationID, string filePath, string fileName);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string create_merger_message(string operationID, string messageList, string title, string summaryList);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string create_face_message(string operationID, int index, string data);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern string create_forward_message(string operationID, string m);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_all_conversation_list(CB_I_S_S cb, string operationID);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_advanced_history_message_list(CB_I_S_S cb, string operationID, string getMessageOptions);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void send_message(CB_I_S_S_I cb, string operationID, string message, string recvID, string groupID, string offlinePushInfo);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_users_info(CB_I_S_S cCallback, string operationID, string userIDs);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_users_info_from_srv(CB_I_S_S cCallback, string operationID, string userIDs);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_self_info(CB_I_S_S cCallback, string operationID, string userInfo);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_self_user_info(CB_I_S_S cCallback, string operationID);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void update_msg_sender_info(CB_I_S_S cCallback, string operationID, string nickname, string faceURL);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void subscribe_users_status(CB_I_S_S cCallback, string operationID, string userIDs);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void unsubscribe_users_status(CB_I_S_S cCallback, string operationID, string userIDs);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_subscribe_users_status(CB_I_S_S cCallback, string operationID);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_user_status(CB_I_S_S cCallback, string operationID, string userIDs);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_specified_friends_info(CB_I_S_S cCallback, string operationID, string userIDList);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_friend_list(CB_I_S_S cCallback, string operationID);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_friend_list_page(CB_I_S_S cCallback, string operationID, int offset, int count);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void search_friends(CB_I_S_S cCallback, string operationID, string searchParam);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void check_friend(CB_I_S_S cCallback, string operationID, string userIDList);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void add_friend(CB_I_S_S cCallback, string operationID, string userIDReqMsg);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_friend_remark(CB_I_S_S cCallback, string operationID, string userIDRemark);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void delete_friend(CB_I_S_S cCallback, string operationID, string friendUserID);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_friend_application_list_as_recipient(CB_I_S_S cCallback, string operationID);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_friend_application_list_as_applicant(CB_I_S_S cCallback, string operationID);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void accept_friend_application(CB_I_S_S cCallback, string operationID, string userIDHandleMsg);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void refuse_friend_application(CB_I_S_S cCallback, string operationID, string userIDHandleMsg);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void add_black(CB_I_S_S cCallback, string operationID, string blackUserID);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_black_list(CB_I_S_S cCallback, string operationID);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void remove_black(CB_I_S_S cCallback, string operationID, string removeUserID);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void create_group(CB_I_S_S cCallback, string cOperationID, string cGroupReqInfo);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void join_group(CB_I_S_S cCallback, string cOperationID, string cGroupID, string cReqMsg, int cJoinSource);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void quit_group(CB_I_S_S cCallback, string cOperationID, string cGroupID);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void dismiss_group(CB_I_S_S cCallback, string cOperationID, string cGroupID);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void change_group_mute(CB_I_S_S cCallback, string cOperationID, string cGroupID, int cIsMute);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void change_group_member_mute(CB_I_S_S cCallback, string cOperationID, string cGroupID, string cUserID, int cMutedSeconds);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_group_member_role_level(CB_I_S_S cCallback, string cOperationID, string cGroupID, string cUserID, int cRoleLevel);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_group_member_info(CB_I_S_S cCallback, string cOperationID, string cGroupMemberInfo);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_joined_group_list(CB_I_S_S cCallback, string cOperationID);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_specified_groups_info(CB_I_S_S cCallback, string cOperationID, string cGroupIDList);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void search_groups(CB_I_S_S cCallback, string cOperationID, string cSearchParam);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_group_info(CB_I_S_S cCallback, string cOperationID, string cGroupInfo);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_group_verification(CB_I_S_S cCallback, string cOperationID, string cGroupID, int cVerification);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_group_look_member_info(CB_I_S_S cCallback, string cOperationID, string cGroupID, int cRule);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_group_apply_member_friend(CB_I_S_S cCallback, string cOperationID, string cGroupID, int cRule);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_group_member_list(CB_I_S_S cCallback, string cOperationID, string cGroupID, int cFilter, int cOffset, int cCount);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_group_member_owner_and_admin(CB_I_S_S cCallback, string cOperationID, string cGroupID);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_group_member_list_by_join_time_filter(CB_I_S_S cCallback, string cOperationID, string cGroupID, int cOffset, int cCount, Int64 cJoinTimeBegin, Int64 cJoinTimeEnd, string cFilterUserIDList);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_specified_group_members_info(CB_I_S_S cCallback, string cOperationID, string cGroupID, string cUserIDList);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void kick_group_member(CB_I_S_S cCallback, string cOperationID, string cGroupID, string cReason, string cUserIDList);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void transfer_group_owner(CB_I_S_S cCallback, string cOperationID, string cGroupID, string cNewOwnerUserID);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void invite_user_to_group(CB_I_S_S cCallback, string cOperationID, string cGroupID, string cReason, string cUserIDList);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_group_application_list_as_recipient(CB_I_S_S cCallback, string cOperationID);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void get_group_application_list_as_applicant(CB_I_S_S cCallback, string cOperationID);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void accept_group_application(CB_I_S_S cCallback, string cOperationID, string cGroupID, string cFromUserID, string cHandleMsg);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void refuse_group_application(CB_I_S_S cCallback, string cOperationID, string cGroupID, string cFromUserID, string cHandleMsg);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_group_member_nickname(CB_I_S_S cCallback, string cOperationID, string cGroupID, string cUserID, string cGroupMemberNickname);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void search_group_members(CB_I_S_S cCallback, string cOperationID, string cSearchParam);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void is_join_group(CB_I_S_S cCallback, string cOperationID, string cGroupID);
    }
}
