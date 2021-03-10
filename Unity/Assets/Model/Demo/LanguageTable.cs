using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ETModel
{
    [System.Serializable]
    public struct WordInfo
    {
        public string chinese;
        public string word;
    }

    [CreateAssetMenu(menuName = "Demo/LanguageTable", fileName = "new Language Table")]
    public class LanguageTable : ScriptableObject
    {
        public string languageName;
        public WordInfo[] words;
    }
}
