using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ETModel
{
    public class LanguageManager
    {
        private static LanguageManager _instance;
        public static LanguageManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LanguageManager();
                }
                return _instance;
            }
        }

        public Action onTableChanged;
        public LanguageTable curTable;

        /// <summary>
        /// 设置名称，CH表示中文，EN表示英文等
        /// </summary>
        public void SetLanguage(string name)
        {
            if (Instance.curTable != null)
            {
                ResourcesUtil.Unload($"Language{Instance.curTable.languageName}");
            }

            string resName = $"Language{name}";
            if (name == "CH")
            {
                curTable = null;
                Instance.onTableChanged?.Invoke();
                return;
            }

            LanguageTable table = ResourcesUtil.Load<LanguageTable>(resName);
            Instance.curTable = table;
            Instance.onTableChanged?.Invoke();
        }

        /// <summary>
        /// 获取对应的单词
        /// </summary>
        public string GetWord(string chinese)
        {
            if (curTable == null)
            {
                return chinese;
            }
            foreach (var info in curTable.words)
            {
                if (info.chinese == chinese)
                {
                    return info.word;
                }
            }

            Debug.LogError($"{curTable.languageName}中没有找到对应的单词：{chinese}");
            return chinese;
        }
    }
}
