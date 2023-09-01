using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEditor.Presets;
using System.IO;
using System.Text;
using System.Reflection;
namespace DawnEditor
{

    [InitializeOnLoad]
    public class EditorTools
    {

        #region  Editor事件监听
        static EditorTools()
        {
            EditorSceneManager.sceneOpened += EditorSceneManager_Opened;
            EditorSceneManager.sceneSaved += EditorSceneManager_sceneSaved; //场景保存事件

            //添加UI Label 
            EditorApplication.hierarchyWindowItemOnGUI += AddLabelOnHierarchyItem;
            EditorApplication.playModeStateChanged += EditorApplication_playModeStateChanged;
        }
        private static void EditorApplication_playModeStateChanged(PlayModeStateChange obj)
        {
            switch (obj)
            {
                case PlayModeStateChange.EnteredPlayMode:
                    // ClearConsoleLog();
                    break;
                case PlayModeStateChange.ExitingPlayMode:
                    break;
            }
        }
        private static void EditorSceneManager_Opened(Scene scene, OpenSceneMode mode)
        {
        }
        private static void EditorSceneManager_sceneSaved(Scene scene)
        {
            GameObject[] rootGameobjects = scene.GetRootGameObjects();
            foreach (GameObject gameObject in rootGameobjects)
            {
                if (gameObject.GetComponent<UILogicComponent>() != null)
                {
                    var savePath = "Assets/BundleResources/UI/" + gameObject.name + ".prefab";
                    PrefabUtility.SaveAsPrefabAsset(gameObject, savePath);
                    Debug.Log("Save UI Prefab = " + savePath);
                }
            }
        }
        private static void AddLabelOnHierarchyItem(int instanceid, Rect selectionrect)
        {
            var obj = EditorUtility.InstanceIDToObject(instanceid) as GameObject;
            if (obj != null)
            {
                if (obj.GetComponent<UILogicComponent>() != null)
                {
                    Rect r = new Rect(selectionrect);
                    r.x = r.width;
                    var style = new GUIStyle();
                    style.normal.textColor = Color.yellow;
                    style.hover.textColor = Color.cyan;
                    GUI.Label(r, "[UI]", style);
                }
                if (true)
                {
                    if (Selection.objects.Length == 1)
                    {
                        if (obj == Selection.objects[0])
                        {
                            Rect btnPos = new Rect(selectionrect);
                            btnPos.x = btnPos.x + (btnPos.width - 40);
                            btnPos.width = 40;
                            if (GUI.Button(btnPos, "path"))
                            {
                                string path = obj.name;
                                var temp = obj.transform.parent;
                                while (temp != null)
                                {
                                    if (temp.gameObject.GetComponent<UILogicComponent>() != null)
                                    {
                                        break;
                                    }
                                    path = temp.gameObject.name + "/" + path;
                                    temp = temp.transform.parent;
                                }
                                UnityEngine.GUIUtility.systemCopyBuffer = path;
                                Debug.Log("Path:" + path);
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 日志清理函数
        /// </summary>
        private static MethodInfo ConsoleLogClearMethod;
        private static void ClearConsoleLog()
        {
            if (ConsoleLogClearMethod == null)
            {
                var assembly = Assembly.GetAssembly(typeof(ActiveEditorTracker));
                var type = assembly.GetType("UnityEditorInternal.LogEntries");
                if (type == null)
                {
                    type = assembly.GetType("UnityEditor.LogEntries");
                }
                ConsoleLogClearMethod = type.GetMethod("Clear");
            }
            ConsoleLogClearMethod.Invoke(new object(), null);
        }
        #endregion

    }

}