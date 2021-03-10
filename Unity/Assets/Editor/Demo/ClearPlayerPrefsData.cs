using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ETEditor
{
    public class ClearPlayerPrefsData
    {
        [MenuItem("Tools/Demo/清空 PlayerPrefs", priority = 1001)]
        public static void Clear()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
