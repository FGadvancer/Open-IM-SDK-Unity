﻿using System;
using System.Collections.Generic;
using UnityEngine;
using OpenIM;
using UnityEditor;

public static class Game
{
    public static GameEntry Entry = null;
    public static UIManager UI = null;
    public static TimerManager Timer = null;
    public static GameConfig Config = null;
    public static EffectMgr Effect = null;
    public static EventDispator Event = null;
    public static HttpManager Http = null;
    public static Player Player = null;
    static Dictionary<Type, ProcedureBase> procedures = new Dictionary<Type, ProcedureBase>();
    public static void Init()
    {
        var config = new IMConfig
        {
            PlatformID = (int)GetPlatFormID(),
            ApiAddr = "http://125.124.195.201:10002",
            WsAddr = "ws://125.124.195.201:10001",
            DataDir = Application.persistentDataPath,
            LogLevel = 1,
            IsLogStandardOutput = true,
            LogFilePath = Application.persistentDataPath,
            IsExternalExtensions = true
        };
        Player = new Player(Game.Config.TestID);
        bool suc = OpenIMSDK.InitSDK(config, OnConnectStatusChange);
        Debug.Log("InitSDK res " + suc);
        if (!suc)
        {
            Debug.LogError("Init SDK Error");
            EditorApplication.isPlaying = false;
            return;
        }
        OpenIMSDK.SetGroupListener(OnRecvGroup);
        OpenIMSDK.SetConversationListener(OnRecvConversation);
        OpenIMSDK.SetAdvancedMsgListener(OnRecvAdvancedMsg);
    }
    public static void Destroy()
    {
        OpenIMSDK.UnInitSDK();
    }
    public static void OnRecvConversation(EventId eid, string data)
    {

    }
    public static void OnRecvAdvancedMsg(EventId eid, string data)
    {

    }
    public static void OnRecvGroup(EventId eid, string data)
    {

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
    public static void OnConnectStatusChange(EventId id, string data)
    {
        Debug.Log(id + "  " + data);
        if (id == EventId.CONNECTING)
        {
        }
        else if (id == EventId.CONNECT_SUCCESS)
        {
            Game.ChangeProcecure<ProcedureMain>();
        }
        else if (id == EventId.CONNECT_FAILED)
        {
        }
        else if (id == EventId.KICKED_OFFLINE)
        {
        }
        else if (id == EventId.USER_TOKEN_EXPIRED)
        {
            Game.UI.ShowTip("User Token Expired", 2);
        }
    }
    public static void ChangeProcecure<T>() where T : ProcedureBase
    {
        ProcedureBase procedure;
        var suc = procedures.TryGetValue(typeof(T), out procedure);
        if (!suc)
        {
            procedure = System.Activator.CreateInstance<T>();
        }
        Game.Entry.ChangeProcedure(procedure);
    }
}