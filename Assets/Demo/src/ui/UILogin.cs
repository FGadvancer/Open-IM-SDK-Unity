using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Dynamic;
using open_im_sdk;
public class UILogin : MonoBehaviour
{
    public TMP_Dropdown UserIdDropDown;
    public TMP_InputField TokenTxt;
    public Button loginBtn;
    List<string> userIds;
    List<string> tokens;
    int selectIndex = 0;
    void Awake()
    {
        userIds = new List<string>(){
            "yejian001","yejian002"
        };
        tokens = new List<string>(){
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiJ5ZWppYW4wMDEiLCJQbGF0Zm9ybUlEIjozLCJleHAiOjE3MTY2MTQzOTEsIm5iZiI6MTcwODgzODA5MSwiaWF0IjoxNzA4ODM4MzkxfQ.4xB2OzU8uSZCWeNWQwRn6LF4b2XtjmR9lDGIvk_Sq7o",
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiJ5ZWppYW4wMDIiLCJQbGF0Zm9ybUlEIjozLCJleHAiOjE3MTY2NDY1NTYsIm5iZiI6MTcwODg3MDI1NiwiaWF0IjoxNzA4ODcwNTU2fQ.uzXn6Vzmi_y6o9-3qtlsMCrpx2ubibqE1YhRDIHd31g",
        };
    }

    void Start()
    {
        TokenTxt.text = tokens[0];
        UserIdDropDown.AddOptions(userIds);
        UserIdDropDown.onValueChanged.AddListener((index) =>
        {
            selectIndex = index;
            TokenTxt.text = tokens[index];
        });
        loginBtn.onClick.AddListener(() =>
        {
            if (IMSDK.GetLoginStatus() == LoginStatus.Logged && IMSDK.GetLoginUser() == userIds[selectIndex])
            {
                Player.CurPlayer.OnLoginSuc(userIds[selectIndex]);
            }
            else
            {
                Player.CurPlayer.Login(userIds[selectIndex], tokens[selectIndex]);
            }
        });
    }

    void Update()
    {

    }
}
