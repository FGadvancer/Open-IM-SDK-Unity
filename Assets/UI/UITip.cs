using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UITip : MonoBehaviour
{
    public Image bg = null;
    public Text  tip = null;

    // Start is called before the first frame update
    void Start()
    {
        bg.gameObject.SetActive(false);
    }

    public void ShowTipInfo(string tipstr){
        tip.text = tipstr;
        bg.gameObject.SetActive(true);
        StartCoroutine("HideTip");
    }

    IEnumerator HideTip(){
        yield return new WaitForSeconds(3);
        bg.gameObject.SetActive(false);
    }
}
