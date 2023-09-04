using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.Text;
namespace OpenIM
{
    public delegate void CB_I_S(int eventName, string data);
    public delegate void CB_I_S_S(int errCode, string errMsg, string data);
    public delegate void CB_I_S_S_I(int errCode, string errMsg, string data, int progress);
    public class OpenIMDLL
    {
#if (UNITY_IPHONE || UNITY_TVOS || UNITY_WEBGL || UNITY_SWITCH) && !UNITY_EDITOR
        const string OPENIMDLL = "__Internal";
#else
        const string OPENIMDLL = "openimsdk";
#endif

        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int init_sdk(CB_I_S cCallback, string operationID, string config);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void un_init_sdk(string operationID);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void login(CB_I_S_S cCallback, string operationID, string uid, string token);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void logout(CB_I_S_S cCallback, string operationID);
        [DllImport(OPENIMDLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern void network_status_changed(CB_I_S_S cCallback, string operationID);
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
        public static extern void send_message(CB_I_S_S_I cCallback, string operationID, string message, string recvID, string groupID, string offlinePushInfo);
    }
}
