using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;

public class HttpManager : MonoBehaviour
{
    Dictionary<UnityWebRequest, Action<string>> requestCallbacks = new Dictionary<UnityWebRequest, Action<string>>();
    private void OnDestroy()
    {
    }
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
}