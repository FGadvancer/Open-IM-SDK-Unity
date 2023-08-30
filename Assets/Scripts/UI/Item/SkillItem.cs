using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SuperScrollView;
public class SkillItem
{
    public GameObject obj;
    public TextMeshProUGUI vit;
    public TextMeshProUGUI name;
    public Button btn;
    public Button add;
    public int index;
    public SkillItem(GameObject obj)
    {
        var trans = obj.transform;
        this.vit = trans.Find("vit/val").GetComponent<TextMeshProUGUI>();
        this.name = trans.Find("name").GetComponent<TextMeshProUGUI>();
        this.btn = trans.GetComponent<Button>();
        this.add = trans.Find("add").GetComponent<Button>();
        this.obj = obj;
    }
}