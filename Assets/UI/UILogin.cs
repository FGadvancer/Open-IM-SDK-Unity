using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OpenIM;
public class UILogin: MonoBehaviour
{
    public string IM_API_URL = "http://121.37.25.71:10002";
    public string APP_AUTH_URL = "http://121.37.25.71:10004";
    public string IM_WS_URL = "ws://121.37.25.71:10001";
    // public string UID = "2455144319";
    // public string TOKEN = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVSUQiOiIyNDU1MTQ0MzE5IiwiUGxhdGZvcm0iOiJBbmRyb2lkIiwiZXhwIjoxNjczMzIwNDY0LCJuYmYiOjE2NjU1NDQxNjQsImlhdCI6MTY2NTU0NDQ2NH0.rMoqzVahPIFt33NcvjAL4Sc5j840yFBG12lFFgA9S-o";

    public InputField UID = null;
    public InputField TOKEN = null;
    public Button LoginButton = null;
    public class ConnectCallBack: OnConnListenerCallBack{
        public ConnectCallBack()
        {
        }

        public override void onConnectFailed(int var1, string var2){
            UIManager.GetUIManager().Tip.ShowTipInfo("Connect Failed");
        }
        public override void onConnectSuccess(){
            UIManager.GetUIManager().Tip.ShowTipInfo("Connect Success");
        }
        public override void onConnecting(){
            UIManager.GetUIManager().Tip.ShowTipInfo("Connect Connecting");
        }
        public override void onKickedOffline(){
            UIManager.GetUIManager().Tip.ShowTipInfo("KickedOff");
        }

        public override void onUserTokenExpired(){
            UIManager.GetUIManager().Tip.ShowTipInfo("Token Expired");
        }
    }

    public class LoginCallBack: BaseCallBack{
        public LoginCallBack(){

        }
        public override void onError(int var1,string var2){
            var info = "Login Error" + var1 + var2;
            UIManager.GetUIManager().Tip.ShowTipInfo(info);
        }

        public override void onSuccess(string var1){
            var info = "Login Success  " + var1;
            UIManager.GetUIManager().Tip.ShowTipInfo(info);
            UIManager.GetUIManager().ShowMain();
        }
    }

    void Start()
    {
    #if UNITY_ANDROID
        InitInfo info = new InitInfo();
        info.platform = 2;
        info.api_addr = IM_API_URL;
        info.ws_addr = IM_WS_URL;
        info.data_dir = Application.persistentDataPath;
        info.log_level = 1;
        info.object_storage = "minio";
        info.encryption_key = "";
        OpenIMClient.InitSDK(new ConnectCallBack(),info);

        LoginButton.onClick.AddListener(()=>{
            OpenIMClient.Login(new LoginCallBack(),UID.text,TOKEN.text);
        });
    #endif
    }
}
