using UnityEngine;
using UnityEngine.UI;
using OpenIM;
using TMPro;
public class UILogin : UILogicBase
{
    Button loginBtn;
    TextMeshProUGUI status;
    public override void Init()
    {
        loginBtn = GetComponent<Button>("bg/login");
        status = GetComponent<TextMeshProUGUI>("bg/status");
    }

    public override void OnClose()
    {
    }

    public override void OnDestroy()
    {
    }

    public override void OnOpen()
    {
        var operationId = "12345";
        var config = "{\"platformID\": 3, \"apiAddr\": \"http://125.124.195.201:10002\", \"wsAddr\":\"ws://125.124.195.201:10001\",\"dataDir\": \"./\", \"logLevel\": 1, \"isLogStandardOutput\": true, \"logFilePath\": \"./\", \"isExternalExtensions\": true}";

        OnClick(loginBtn, () =>
        {
            int res = OpenIMClient.init_sdk(() =>
            {
                Debug.Log("OnConnecting");
                // status.text = "OnConnecting";
            }, () =>
            {
                Debug.Log("OnConnectSuc");
                // status.text = "OnConnectSuc";
            }, () =>
            {
                Debug.Log("OnKickedOffline");
                // status.text = "OnKickedOffline";
            }, () =>
            {
                Debug.Log("OnUserTokenExpire");
                // status.text = "OnUserTokenExpire";
            }, (err, msg) =>
            {
                Debug.Log(err + msg);
                // status.text = "OnConnectFailed";
            }, operationId, config);
            Debug.Log("Res = " + res);

            var id = "6959062403";
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiI2OTU5MDYyNDAzIiwiUGxhdGZvcm1JRCI6MywiZXhwIjoxNzAwNzIwOTg0LCJuYmYiOjE2OTI5NDQ2ODQsImlhdCI6MTY5Mjk0NDk4NH0.8otKTFrOCs8_ueV10rNOD-rzHrCT_EN0obKS9q79bIc";
            OpenIMClient.login((msg) =>
            {
                Debug.Log(msg);
            }, (err, msg) =>
            {
                Debug.Log(err + msg);
            }, id, token);

        });

    }
    public override void OnUpdate(float dt)
    {

    }
}
