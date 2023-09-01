using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public abstract class UILogicBase
{
    public Transform UIRoot;
    public abstract void Init();
    public abstract void OnOpen();
    public abstract void OnUpdate(float dt);
    public abstract void OnClose();
    public abstract void OnDestroy();

    public Transform GetTrans(string path = "")
    {
        if (string.IsNullOrEmpty(path))
        {
            return UIRoot;
        }
        else
        {
            var child = UIRoot.Find(path);
            if (child == null)
            {
                Debug.LogError(UIRoot.name + " Not Find Child  : " + path);
            }
            return child;
        }
    }

    // 获取UI 组件
    public T GetComponent<T>(string path = "")
    {
        return GetTrans(path).GetComponent<T>();
    }

    public void OnClick(Button btn, UnityAction cb)
    {
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(() =>
        {
            cb();
        });
    }
    public void OnToggle(Toggle toggle, UnityAction<bool> cb)
    {
        toggle.onValueChanged.RemoveAllListeners();
        toggle.onValueChanged.AddListener((isOn) =>
        {
            cb(isOn);
        });
    }
}