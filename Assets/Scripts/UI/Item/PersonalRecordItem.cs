using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PersonalRecordItem
{
    public GameObject Obj;
    public TextMeshProUGUI Time;
    public Image Role;
    public TextMeshProUGUI Points;
    public TextMeshProUGUI Opponent;
    public PersonalRecordItem(GameObject obj)
    {
        this.Obj = obj;
        var trans = obj.transform;
        this.Time = trans.Find("time/val").GetComponent<TextMeshProUGUI>();
        this.Role = trans.Find("role/icon").GetComponent<Image>();
        this.Points = trans.Find("points/val").GetComponent<TextMeshProUGUI>();
        this.Opponent = trans.Find("winper/val").GetComponent<TextMeshProUGUI>();
    }
}