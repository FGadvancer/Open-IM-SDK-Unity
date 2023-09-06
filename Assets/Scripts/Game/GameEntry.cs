using UnityEngine;

public class GameEntry : MonoBehaviour
{
    public UIManager UI;
    public TimerManager Timer;
    public EffectMgr Effect;
    public HttpManager Http;
    public string EnterProcedureName;
    ProcedureBase curProcedure;
    void Awake()
    {
        Game.Entry = this;
        Game.UI = UI;
        Game.Timer = Timer;
        Game.Http = Http;
        Game.Event = new EventDispator();
        Game.Config = Resources.Load("GameConfig", typeof(GameConfig)) as GameConfig;
        Game.Effect = Effect;
    }

    void Start()
    {
        Game.Init();
    }

    void Update()
    {
        if (curProcedure == null)
        {
            if (EnterProcedureName == "ProcedureLogin")
            {
                Game.ChangeProcecure<ProcedureLogin>();
            }
        }
        if (curProcedure != null)
        {
            curProcedure.Update(Time.deltaTime);
        }
    }

    void OnDestroy()
    {
        Debug.Log(" GameEntry Destroy()");
        if (Game.LocalData != null)
        {
            Debug.Log(" GameEntry SaveLocalData" + JsonUtility.ToJson(Game.LocalData));
            PlayerPrefs.SetString(Game.Config.LocalDataSaveName, JsonUtility.ToJson(Game.LocalData));
        }
    }

    public void ChangeProcedure(ProcedureBase procedure)
    {
        if (procedure == null)
        {
            return;
        }
        if (curProcedure != null)
        {
            curProcedure.Exit();
        }
        curProcedure = procedure;
        curProcedure.Enter();
    }

    public ProcedureBase GetCurProcedure()
    {
        return curProcedure;
    }
}
