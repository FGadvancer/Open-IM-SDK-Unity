using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OpenIM;

public class UILogin : UILogicBase
{
    Button loginBtn;
    TextMeshProUGUI status;
    LoginMgr loginMgr;
    public override void Init()
    {

        loginMgr = new LoginMgr(new IMConfig(3, "http://125.124.195.201:10002", "ws://125.124.195.201:10001", Application.persistentDataPath, 1, true, Application.persistentDataPath, true));
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

        OnClick(loginBtn, () =>
        {
            loginMgr.Login("6959062403", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiI2OTU5MDYyNDAzIiwiUGxhdGZvcm1JRCI6MywiZXhwIjoxNzAwNzIwOTg0LCJuYmYiOjE2OTI5NDQ2ODQsImlhdCI6MTY5Mjk0NDk4NH0.8otKTFrOCs8_ueV10rNOD-rzHrCT_EN0obKS9q79bIc");
        });

    }
    public override void OnUpdate(float dt)
    {

    }
}
