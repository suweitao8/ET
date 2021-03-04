using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using System.IO;

namespace ETEditor
{
    public class GenerateCodeWindow : OdinEditorWindow
    {
        public const string COMPONENT_CODE =
@"using System;
using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
    Awake系统Start系统Update系统Destroy系统
	public class 类名: Component
	{
	Awake函数Start函数Update函数Destroy函数
    }
}";

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


        [MenuItem("Tools/生成代码")]
        private static void OpenWindow()
        {
            GetWindow<GenerateCodeWindow>().Show();
        }

        [FolderPath]
        public string generateDir;

        public string className;

        public bool isAwake = true;
        public bool isStart = true;
        public bool isUpdate = true;
        public bool isDestroy = true;

        [Button(ButtonSizes.Large)]
        public void GenerateCode()
        {
            if (string.IsNullOrWhiteSpace(generateDir) ||
                string.IsNullOrWhiteSpace(className))
            {
                return;
            }

            string dir = Application.dataPath.Substring(0, Application.dataPath.Length - 6) +
                generateDir;
            if (Directory.Exists(dir) == false) Directory.CreateDirectory(dir);
            string path = $"{dir}/{className}.cs";
            FileStream fs;
            if (File.Exists(path) == false) fs = File.Create(path);
            else fs = new FileStream(path, FileMode.Truncate, FileAccess.Write);
            string code = COMPONENT_CODE.Replace("类名", className);
            string system = null;
            string function = null;
            if (isAwake)
            {
                system = SYSTEM_CODE.Replace("类名", className)
                    .Replace("函数", "Awake");
                function = FUNCTION_CODE.Replace("函数", "Awake");
                code = code.Replace("Awake系统", system)
                    .Replace("Awake函数", function);
            }
            else
            {
                code = code.Replace("Awake系统", "")
                    .Replace("Awake函数", "");
            }
            if (isStart)
            {
                system = SYSTEM_CODE.Replace("类名", className)
                    .Replace("函数", "Start");
                function = FUNCTION_CODE.Replace("函数", "Start");
                code = code.Replace("Start系统", system)
                    .Replace("Start函数", function);
            }
            else
            {
                code = code.Replace("Start系统", "")
                    .Replace("Start函数", "");
            }
            if (isUpdate)
            {
                system = SYSTEM_CODE.Replace("类名", className)
                    .Replace("函数", "Update");
                function = FUNCTION_CODE.Replace("函数", "Update");
                code = code.Replace("Update系统", system)
                    .Replace("Update函数", function);
            }
            else
            {
                code = code.Replace("Update系统", "")
                    .Replace("Update函数", "");
            }
            if (isDestroy)
            {
                system = SYSTEM_CODE.Replace("类名", className)
                    .Replace("函数", "Destroy");
                function = FUNCTION_CODE.Replace("函数", "Destroy");
                code = code.Replace("Destroy系统", system)
                    .Replace("Destroy函数", function);
            }
            else
            {
                code = code.Replace("Destroy系统", "")
                    .Replace("Destroy函数", "");
            }

            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(code);
            }

            fs.Close();
            SaveData();
            AssetDatabase.Refresh();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            generateDir = EditorPrefs.GetString("generateDir", "");
            className = EditorPrefs.GetString("className", "");
            isAwake = EditorPrefs.GetBool("isAwake", true);
            isStart = EditorPrefs.GetBool("isStart", true);
            isUpdate = EditorPrefs.GetBool("isUpdate", true);
            isDestroy = EditorPrefs.GetBool("isDestroy", true);
        }

        void SaveData()
        {
            EditorPrefs.SetString("generateDir", generateDir);
            EditorPrefs.SetString("className", className);
            EditorPrefs.SetBool("isAwake", isAwake);
            EditorPrefs.SetBool("isStart", isStart);
            EditorPrefs.SetBool("isUpdate", isUpdate);
            EditorPrefs.SetBool("isDestroy", isDestroy);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            SaveData();
        }
    }
}