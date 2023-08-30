using System.Collections.Generic;
using UnityEngine;
public class ObjPool
{
    GameObject temp;
    Stack<GameObject> cacheObj;

    public ObjPool(GameObject obj, int initCount = 0)
    {
        cacheObj = new Stack<GameObject>();
        this.temp = obj;
        for (int i = 0; i <= initCount; i++)
        {
            var o = CreateObject();
            Recycle(o);
        }
    }

    public GameObject CreateObject()
    {
        GameObject obj = null;
        if (cacheObj.Count > 0)
        {
            obj = cacheObj.Pop();
        }
        else
        {
            obj = GameObject.Instantiate(temp);
        }
        obj.SetActive(false);
        obj.name = temp.name;
        return obj;
    }
    public void Recycle(GameObject obj)
    {
        cacheObj.Push(obj);
    }
}