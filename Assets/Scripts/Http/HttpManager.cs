using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
public class HttpManager : MonoBehaviour
{
    Dictionary<UnityWebRequest, Action<string>> requestCallbacks = new Dictionary<UnityWebRequest, Action<string>>();
    public void SendGETRequest(string url, Action<string> onSuccess, Action<string> onError = null)
    {
        StartCoroutine(SendGETRequestCoroutine(url, onSuccess, onError));
    }
    private IEnumerator SendGETRequestCoroutine(string url, Action<string> onSuccess, Action<string> onError)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            requestCallbacks.Add(request, onSuccess);
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + request.error);
                onError?.Invoke(request.error);
            }
        }
    }
    #region Get请求
    /// <summary>
    /// Get请求
    /// </summary>
    /// <param name="url"></param>
    /// <param name="actionResult"></param>
    public void Get(string url, Action<bool, string> actionResult = null)
    {
        StartCoroutine(_Get(url, actionResult));
    }

    private IEnumerator _Get(string url, Action<bool, string> action)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                action(false, "Connect Error or Protocol Error");
            }
            else if (request.result == UnityWebRequest.Result.Success)
            {
                action(true, request.downloadHandler.text);
            }
        }
    }
    #endregion


    #region POST请求
    public void Post(string url, string data, Action<bool, string> actionResult = null)
    {
        StartCoroutine(_Post(url, data, actionResult));
    }

    private IEnumerator _Post(string url, string data, Action<bool, string> action, Action<UnityWebRequest> preHandler = null)
    {
        Debug.Log("Post => " + url);
        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(data));
            if (preHandler != null)
            {
                preHandler(request);
            }
            request.SetRequestHeader("content-type", "application/json;charset=utf-8");
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                action(false, "Connect Error or Protocol Error");
            }
            else if (request.result == UnityWebRequest.Result.Success)
            {
                action(true, request.downloadHandler.text);
            }
        }
    }
    #endregion
    private void Update()
    {
        List<UnityWebRequest> completedRequests = new List<UnityWebRequest>();

        foreach (var request in requestCallbacks.Keys)
        {
            if (request.isDone)
            {
                if (request.result == UnityWebRequest.Result.Success)
                {
                    requestCallbacks[request]?.Invoke(request.downloadHandler.text);
                }
                completedRequests.Add(request);
            }
        }

        foreach (var request in completedRequests)
        {
            requestCallbacks.Remove(request);
            request.Dispose();
        }
    }
    Texture2D texture2D;
    public void SetImage(Image image, string url)
    {
        if (url == "")
        {
            return;
        }
        StartCoroutine(LoadTexture(image, url));
    }
    IEnumerator LoadTexture(Image image, string url)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result == UnityWebRequest.Result.ConnectionError || uwr.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("图片加载失败" + url + uwr.error);
            }
            else
            {
                texture2D = DownloadHandlerTexture.GetContent(uwr);
                Sprite temp = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.width), Vector2.zero);
                image.sprite = temp;
            }
        }
    }
}