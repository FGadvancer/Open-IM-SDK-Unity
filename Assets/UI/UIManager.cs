using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenIM;
public class UIManager : MonoBehaviour
{
    public UILogin Login;
    public UIMain Main;
    public UITip Tip;
    // Start is called before the first frame update
    void Start()
    {
        ShowLogin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static UIManager _Instance = null;
    public static UIManager GetUIManager(){
        if (_Instance == null){
            _Instance = GameObject.Find("UIManager").GetComponent<UIManager>();
        }
        return _Instance;
    }


    public void ShowMain(){
        Login.gameObject.SetActive(false);
        Main.gameObject.SetActive(true);
    }
    public void ShowLogin(){
        Login.gameObject.SetActive(true);
        Main.gameObject.SetActive(false);
    }
}
