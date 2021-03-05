using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ETModel;
using UnityEngine.UI;
using System;

namespace ETHotfix
{
    public static class Extensions
    {
        public static GameObject Instantiate(this GameObject prefab)
        {
            return GameObject.Instantiate(prefab);
        }

        public static ReferenceCollector GetUIRC(this Component self)
        {
            return self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
        }

        public static Button GetButton(this ReferenceCollector self, string key)
        {
            return self.Get<GameObject>(key).GetComponent<Button>();
        }

        public static Text GetText(this ReferenceCollector self, string key)
        {
            return self.Get<GameObject>(key).GetComponent<Text>();
        }

        public static Button OnClick(this Button self, Action callback)
        {
            self.onClick.Add(callback);
            return self;
        }
    }
}