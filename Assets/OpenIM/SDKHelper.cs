using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenIM
{
    public class SDKHelper : MonoBehaviour
    {
        static bool isInitialized;
        static SDKHelper _ins;
        public static SDKHelper Instance
        {
            get
            {
                Initialize();
                return _ins;
            }
        }
        void Awake()
        {
            _ins = this;
            isInitialized = true;
        }
        public static void Initialize()
        {
            if (!isInitialized)
            {
                if (!Application.isPlaying)
                {
                    return;
                }
                isInitialized = true;
                var obj = new GameObject("OpenIMSDK");
                _ins = obj.AddComponent<SDKHelper>();
                DontDestroyOnLoad(obj);
            }
        }
        //单个执行单元（无延迟）
        struct NoDelayedQueueItem
        {
            public Action action;
        }
        //全部执行列表（无延迟）
        List<NoDelayedQueueItem> listNoDelayActions = new List<NoDelayedQueueItem>();

        //单个执行单元（有延迟）
        struct DelayedQueueItem
        {
            public Action action;
            public float time;
        }
        //全部执行列表（有延迟）
        List<DelayedQueueItem> listDelayedActions = new List<DelayedQueueItem>();
        public static void QueueOnMainThread(Action taction)
        {
            QueueOnMainThread(taction, 0f);
        }

        //加入到主线程执行队列（有延迟）
        public static void QueueOnMainThread(Action action, float time)
        {
            if (Instance == null)
            {
                return;
            }
            if (time != 0)
            {
                lock (Instance.listDelayedActions)
                {
                    Instance.listDelayedActions.Add(new DelayedQueueItem { time = Time.time + time, action = action });
                }
            }
            else
            {
                lock (Instance.listNoDelayActions)
                {
                    Instance.listNoDelayActions.Add(new NoDelayedQueueItem { action = action });
                }
            }
        }


        //当前执行的无延时函数链
        List<NoDelayedQueueItem> currentActions = new List<NoDelayedQueueItem>();
        //当前执行的有延时函数链
        List<DelayedQueueItem> currentDelayed = new List<DelayedQueueItem>();

        void Update()
        {
            if (listNoDelayActions.Count > 0)
            {
                lock (listNoDelayActions)
                {
                    currentActions.Clear();
                    currentActions.AddRange(listNoDelayActions);
                    listNoDelayActions.Clear();
                }
                for (int i = 0; i < currentActions.Count; i++)
                {
                    currentActions[i].action();
                }
            }

            if (listDelayedActions.Count > 0)
            {
                lock (listDelayedActions)
                {
                    currentDelayed.Clear();
                    currentDelayed.AddRange(listDelayedActions.Where(d => Time.time >= d.time));
                    for (int i = 0; i < currentDelayed.Count; i++)
                    {
                        listDelayedActions.Remove(currentDelayed[i]);
                    }
                }

                for (int i = 0; i < currentDelayed.Count; i++)
                {
                    currentDelayed[i].action();
                }
            }
        }

        void OnDisable()
        {
            if (_ins == this)
            {
                _ins = null;
            }
        }
    }
}

