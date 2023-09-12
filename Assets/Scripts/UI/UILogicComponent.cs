
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
public class UILogicComponent : MonoBehaviour
{
    public string LogicTypeName;
    public UILogicBase logic;
    bool isVisiable;
    public bool IsVisiable
    {
        get
        {
            return isVisiable;
        }
    }
    public void Init()
    {
        logic.Init();
        gameObject.SetActive(false);
        this.isVisiable = false;
    }
    public void OnOpen(object userData = null)
    {
        logic.OnOpen(userData);
        gameObject.SetActive(true);
        this.isVisiable = true;
    }
    public void OnClose()
    {
        logic.OnClose();
        gameObject.SetActive(false);
        this.isVisiable = false;
    }
    public void OnUpdate(float dt)
    {
        logic.OnUpdate(dt);
    }
    public void OnDestroy()
    {
        logic.OnDestroy();
    }
}


