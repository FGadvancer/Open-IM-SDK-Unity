using open_im_sdk;
using UnityEngine;

public class ChatApp : MonoBehaviour
{
    public UILogin UILogin;
    public UIMain UIMain;

    static string WsAddr = "ws://14.29.168.56:20001";
    static string ApiAddr = "http://14.29.168.56:20002";
    // public static string WsAddr = "ws://14.29.213.197:50001";
    // public static string ApiAddr = "http://14.29.213.197:50002";
    void Awake()
    {
        InitListen();
        var suc = Player.CurPlayer.Init(WsAddr, ApiAddr);
        if (!suc)
        {
            Debug.Log("Init Error");
        }
    }
    void OnDestroy()
    {
        Player.CurPlayer.UnLogin();
        Player.CurPlayer.Destroy();
    }
    void Start()
    {
        UILogin.gameObject.SetActive(true);
        UIMain.gameObject.SetActive(false);
    }
    void Update()
    {
        Player.CurPlayer.Update();
    }

    void InitListen()
    {
        var dispator = Player.CurPlayer.Dispator;
        dispator.AddListener(EventType.OnLoginSuc, () =>
        {
            UILogin.gameObject.SetActive(false);
            UIMain.gameObject.SetActive(true);
        });
        dispator.AddListener(EventType.OnTokenExpired, () =>
        {
            UILogin.gameObject.SetActive(true);
            UIMain.transform.gameObject.SetActive(false);
            Debug.Log("Token Expired");
        });
        dispator.AddListener(EventType.OnConversationSyncFailed, () =>
        {
            UILogin.gameObject.SetActive(true);
            UIMain.transform.gameObject.SetActive(false);
            Player.CurPlayer.UnLogin();
        });
    }
}
