using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using System.IO;
using ETModel;

namespace ETHotfix
{
    public class GenerateCodeWindow : OdinEditorWindow
    {
        public const string COMPONENT_CODE =
    @"using System;
using System.Collections.Generic;
using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
    唤醒系统开始系统更新系统销毁系统
    public class 类名 : Component
	{
        唤醒函数开始函数更新函数销毁函数
    }
}
";

        public const string SYSTEM_CODE =
    @"
    [ObjectSystem]
    public class 类名函数System : 函数System<类名>
    {
        public override void 函数(类名 self)
        {
            self.函数();
        }
    }
";

        public const string FUNCTION_CODE =
    @"
        public void 函数()
        {
        }
";

        [MenuItem("Tools/Demo/生成Component代码", priority = 1001)]
        private static void OpenWindow()
        {
            GetWindow<GenerateCodeWindow>().Show();
        }

        [FolderPath]
        public string generatePath;

        public string className;

        public bool isAwake = false;

        public bool isStart = false;

        public bool isUpdate = false;

        public bool isDestroy = false;

        [Button(ButtonSizes.Large)]
        public void GenerateCode()
        {
            if (string.IsNullOrWhiteSpace(generatePath) ||
                string.IsNullOrWhiteSpace(className))
            {
                Debug.LogError($"生成路径和类名不能为空！");
                return;
            }
            SaveData();
            string dir = Application.dataPath
                .Substring(0, Application.dataPath.Length - 6) +
                generatePath;
            if (Directory.Exists(dir) == false) Directory.CreateDirectory(dir);
            string path = $"{dir}/{className}.cs";
            FileStream fs;
            if (File.Exists(path) == false) fs = File.Create(path);
            else fs = new FileStream(path, FileMode.Truncate, FileAccess.Write);

            string componentCode = COMPONENT_CODE.Replace("类名", className);
            string systemCode = null;
            string functionCode = null;
            if (isAwake)
            {
                systemCode = SYSTEM_CODE.Replace("类名", className)
                    .Replace("函数", "Awake");
                functionCode = FUNCTION_CODE.Replace("函数", "Awake");
                componentCode = componentCode.Replace("唤醒系统", systemCode)
                    .Replace("唤醒函数", functionCode);
            }
            else
            {
                componentCode = componentCode.Replace("唤醒系统", "")
                    .Replace("唤醒函数", "");
            }
            if (isStart)
            {
                systemCode = SYSTEM_CODE.Replace("类名", className)
                    .Replace("函数", "Start");
                functionCode = FUNCTION_CODE.Replace("函数", "Start");
                componentCode = componentCode.Replace("开始系统", systemCode)
                    .Replace("开始函数", functionCode);
            }
            else
            {
                componentCode = componentCode.Replace("开始系统", "")
                    .Replace("开始函数", "");
            }
            if (isUpdate)
            {
                systemCode = SYSTEM_CODE.Replace("类名", className)
                    .Replace("函数", "Update");
                functionCode = FUNCTION_CODE.Replace("函数", "Update");
                componentCode = componentCode.Replace("更新系统", systemCode)
                    .Replace("更新函数", functionCode);
            }
            else
            {
                componentCode = componentCode.Replace("更新系统", "")
                    .Replace("更新函数", "");
            }
            if (isDestroy)
            {
                systemCode = SYSTEM_CODE.Replace("类名", className)
                    .Replace("函数", "Destroy");
                functionCode = FUNCTION_CODE.Replace("函数", "Destroy");
                componentCode = componentCode.Replace("销毁系统", systemCode)
                    .Replace("销毁函数", functionCode);
            }
            else
            {
                componentCode = componentCode.Replace("销毁系统", "")
                    .Replace("销毁函数", "");
            }

            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(componentCode);
            }
            fs.Close();

            AssetDatabase.Refresh();
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            generatePath = EditorPrefs.GetString("generatePath", "");
            className = EditorPrefs.GetString("className", "");
            isAwake = EditorPrefs.GetBool("isAwake", true);
            isStart = EditorPrefs.GetBool("isStart", true);
            isUpdate = EditorPrefs.GetBool("isUpdate", true);
            isDestroy = EditorPrefs.GetBool("isDestroy", true);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            SaveData();
        }

        void SaveData()
        {
            EditorPrefs.SetString("generatePath", generatePath);
            EditorPrefs.SetString("className", className);
            EditorPrefs.SetBool("isAwake", isAwake);
            EditorPrefs.SetBool("isStart", isStart);
            EditorPrefs.SetBool("isUpdate", isUpdate);
            EditorPrefs.SetBool("isDestroy", isDestroy);
        }
    }
}
