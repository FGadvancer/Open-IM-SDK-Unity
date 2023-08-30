using UnityEngine;
using System.Collections.Generic;
public class EffectMgr : MonoBehaviour
{
    public List<GameObject> EffectCaches;
    Dictionary<string, ObjPool> effectPools;
    void Start()
    {
        effectPools = new Dictionary<string, ObjPool>();
        foreach (GameObject obj in EffectCaches)
        {
            Debug.Log("AddObjPool = > " + obj.name);
            effectPools.Add(obj.name, new ObjPool(obj, 1));
        }
    }
    void Update()
    {

    }

    public GameObject CreateEffect(string name, Vector3 pos, float duration = 0)
    {
        ObjPool pool;
        if (effectPools.TryGetValue(name, out pool))
        {
            var obj = pool.CreateObject();
            obj.SetActive(true);
            obj.transform.position = pos;
            if (duration <= 0)
            {
                duration = GetEffectDuraion(obj);
            }
            Game.Timer.CreateTimer(duration, () =>
            {
                Recycle(obj);
            });
            return obj;
        }
        else
        {
            Debug.LogError("Not Define Effect Pool, Create Directly");
            return null;
        }
    }
    public void Recycle(GameObject obj)
    {
        obj.SetActive(false);
        ObjPool pool;
        if (effectPools.TryGetValue(obj.name, out pool))
        {
            pool.Recycle(obj);
        }
        else
        {
            Debug.LogError("Not Define Effect Pool" + obj.name);
        }
    }

    public float GetEffectDuraion(GameObject effect)
    {
        var pss = effect.transform.GetComponentsInChildren<ParticleSystem>();
        if (pss.Length <= 0)
        {
            return -1.0f;
        }
        float duration = Mathf.NegativeInfinity;
        for (int i = 0; i < pss.Length; i++)
        {
            var ps = pss[i];
            if (ps.main.loop)
            {
                return -1.0f;
            }
            else
            {
                if (ps.main.duration > duration)
                {
                    duration = ps.main.duration;
                }
            }
        }
        return duration;
    }
}