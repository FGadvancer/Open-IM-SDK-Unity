using System;
using System.Collections.Generic;
using UnityEngine;
using OpenIM;
public static class Game
{
    public static GameEntry Entry = null;
    public static UIManager UI = null;
    public static TimerManager Timer = null;
    public static GameConfig Config = null;
    public static EffectMgr Effect = null;
    public static EventDispator Event = null;
    public static HttpManager Http = null;
    static Dictionary<Type, ProcedureBase> procedures = new Dictionary<Type, ProcedureBase>();
    public static void Init()
    {
        var config = new IMConfig("http://125.124.195.201:10002", "ws://125.124.195.201:10001", Application.persistentDataPath, 1, true, Application.persistentDataPath, true);
        int res = OpenIMSDK.InitSDK(config, OnConnectStatusChange);
        Debug.Log("InitSDK res" + res);
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