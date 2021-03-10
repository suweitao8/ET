using System;
using ETModel;
using UnityEngine;
using Component = ETHotfix.Component;
using System.Collections;
using System.Collections.Generic;

namespace ETHotfix
{
    public static class UIUtil
    {
        public static List<string> createdUIs = new List<string>();

        /// <summary>
        /// 创建一个UI，如果不传入uiName，就把T作为uiName
        /// </summary>
        public static T Open<T>(UILayer layer = UILayer.Common, string uiName = null) where T : Component, new()
        {
            if (string.IsNullOrWhiteSpace(uiName))
            {
                uiName = typeof(T).Name;
            }
            UI ui = null;
            GameObject go = ResourcesUtil.Load<GameObject>(uiName)
                .Instantiate()
                .Name(uiName);
            go.GetComponent<Canvas>().sortingOrder = (int)layer;
            ui = ComponentFactory.Create<UI, string, GameObject>(uiName, go, false);
            Game.Scene.GetComponent<UIComponent>().Add(ui);
            createdUIs.Add(uiName);
            return ui.AddComponent<T>();
        }

        /// <summary>
        /// 尝试打开，如果已经打开，就不会打开
        /// </summary>
        public static T TryOpen<T>(UILayer layer = UILayer.Common, string uiName = null) where T : Component, new()
        {
            if (string.IsNullOrWhiteSpace(uiName))
            {
                uiName = typeof(T).Name;
            }
            if (createdUIs.Contains(uiName) == true) return Get<T>(uiName);
            else return Open<T>(layer, uiName);
        }

        /// <summary>
        /// 获取UI
        /// </summary>
        public static T Get<T>(string uiName = null) where T : Component, new()
        {
            if (string.IsNullOrWhiteSpace(uiName))
            {
                uiName = typeof(T).Name;
            }
            UI ui = Game.Scene.GetComponent<UIComponent>().Get(uiName);
            return ui.GetComponent<T>();
        }

        /// <summary>
        /// 销毁UI
        /// </summary>
        public static void Close(string uiName)
        {
            if (createdUIs.Contains(uiName) == false) return;
            Game.Scene.GetComponent<UIComponent>().Remove(uiName);
            ETModel.Game.Scene.GetComponent<ResourcesComponent>().UnloadBundle(uiName.StringToAB());
        }

        /// <summary>
        /// 销毁UI
        /// </summary>
        public static void Close<T>() where T : Component, new()
        {
            string uiName = typeof(T).Name;
            if (createdUIs.Contains(uiName) == false) return;
            Game.Scene.GetComponent<UIComponent>().Remove(uiName);
            ETModel.Game.Scene.GetComponent<ResourcesComponent>().UnloadBundle(uiName.StringToAB());
        }

        /// <summary>
        /// 关闭所有UI
        /// </summary>
        public static void CloseAll()
        {
            foreach (var name in createdUIs)
            {
                if (name == "UISceneTransition") continue;
                Close(name);
            }
            createdUIs.Clear();
        }
    }
}