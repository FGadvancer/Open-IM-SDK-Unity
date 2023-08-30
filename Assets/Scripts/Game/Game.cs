using System;
using System.Collections.Generic;
using Dawn.Event;
using UnityEngine;
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