using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GlobalRecordItem
{
    public GameObject Obj;
    public TextMeshProUGUI Ranking;
    public TextMeshProUGUI Address;
    public TextMeshProUGUI Points;
    public TextMeshProUGUI WinPercentage;
    public GlobalRecordItem(GameObject obj)
    {
        this.Obj = obj;
        var trans = obj.transform;
        this.Ranking = trans.Find("ranking/val").GetComponent<TextMeshProUGUI>();
        this.Address = trans.Find("id/val").GetComponent<TextMeshProUGUI>();
        this.Points = trans.Find("points/val").GetComponent<TextMeshProUGUI>();
        this.WinPercentage = trans.Find("winper/val").GetComponent<TextMeshProUGUI>();
    }
}