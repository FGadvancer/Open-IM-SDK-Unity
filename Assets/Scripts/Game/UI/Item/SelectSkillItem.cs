using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SuperScrollView;

public class SelectSkillItem
{
    public GameObject obj;
    public TextMeshProUGUI name;
    public Button btn;
    public Button remove;
    public Image bg;
    public SelectSkillItem(GameObject obj)
    {
        var trans = obj.transform;
        this.name = trans.Find("name").GetComponent<TextMeshProUGUI>();
        this.btn = trans.GetComponent<Button>();
        this.remove = trans.Find("remove").GetComponent<Button>();
        this.bg = trans.GetComponent<Image>();
        this.obj = obj;
        this.obj.SetActive(true);
    }
}