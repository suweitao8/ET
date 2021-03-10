using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ETModel
{
    public class Bind : MonoBehaviour
    {
#if UNITY_EDITOR
        [MenuItem("GameObject/@Add Bind", false, 10)]
        static void AddBind()
        {
            foreach (var obj in Selection.objects)
            {
                if (obj is GameObject)
                {
                    GameObject go = ((GameObject)obj);
                    if (go.GetComponent<Bind>() == null)
                    {
                        go.AddComponent<Bind>();
                    }
                }
            }
            // Selection.activeGameObject.AddComponent<Bind>();
        }
#endif
    }
}
