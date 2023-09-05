using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITip : UILogicBase
{
    Transform msgTrans;
    TextMeshProUGUI tip;
    Transform maskTrans;
    Image msgBg;
    Button maskBtn;
    public override void Init()
    {
        maskTrans = GetComponent<Transform>("mask");
        msgBg = GetComponent<Image>("bg");
        tip = GetComponent<TextMeshProUGUI>("bg/text");
    }
    public override void OnOpen()
    {
        maskTrans.gameObject.SetActive(false);
        msgTrans.gameObject.SetActive(false);
        tip.text = "";
        Game.Event.AddListener<string, float, Color, bool, bool>(EventType.Tip, OnListenTip);
    }
    public void OnListenTip(string tip, float duration, Color bgcolor, bool showMask, bool canClose)
    {
        msgBg.color = bgcolor;
        maskTrans.gameObject.SetActive(showMask);
        msgTrans.gameObject.SetActive(tip != "");
        this.tip.text = tip;
        OnClick(maskBtn, () =>
        {
            if (canClose)
            {
                maskTrans.gameObject.SetActive(false);
                msgTrans.gameObject.SetActive(false);
            }
        });
        if (duration > 0)
        {
            Game.Timer.CreateTimer(duration, () =>
            {
                maskTrans.gameObject.SetActive(false);
                msgTrans.gameObject.SetActive(false);
            });
        }
    }
    public override void OnClose()
    {
        Game.Event.RemoveListener<string, float, Color, bool, bool>(EventType.Tip, OnListenTip);
    }

    public override void OnDestroy()
    {
    }


    public override void OnUpdate(float dt)
    {
    }
}
