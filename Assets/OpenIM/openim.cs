using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenIM;
public class openim : MonoBehaviour
{
    public static string DEFAULT_IP = "121.37.25.71";
//    public static final String DEFAULT_IP = "43.128.5.63";

    //IM sdk api地址
    public static string IM_API_URL = "http://" + DEFAULT_IP + ":10002";
    //登录注册手机验 证服务器地址
    public static string APP_AUTH_URL = "http://" + DEFAULT_IP + ":10004";
    //web socket
    public static string IM_WS_URL = "ws://" + DEFAULT_IP + ":10001";
    // Start is called before the first frame update
    void Start()
    {
    #if UNITY_ANDROID

        OpenIMClient.Init();

        InitInfo info = new InitInfo();
        info.platform = 2;
        info.api_addr = IM_API_URL;
        info.ws_addr = IM_WS_URL;
        info.data_dir = Application.persistentDataPath;
        info.log_level = 1;
        info.object_storage = "minio";
        info.encryption_key = "";
        OpenIMClient.initSDK(info);
    #endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
