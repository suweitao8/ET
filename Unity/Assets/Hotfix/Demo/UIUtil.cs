using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ETModel;

namespace ETHotfix
{
    public static class UIUtil
    {
        public static T Create<T>(string uiName = null) where T : Component, new()
        {
            if (uiName == null)
                uiName = typeof(T).Name;
            GameObject go = ResourcesUtil.Load<GameObject>(uiName).Instantiate();
            UI ui = ComponentFactory.Create<UI, string, GameObject>(uiName, go, false);
            Game.Scene.GetComponent<UIComponent>().Add(ui);
            return ui.AddComponent<T>();
        }

        public static void Close(string uiName)
        {
            Game.Scene.GetComponent<UIComponent>().Remove(uiName);
            ResourcesUtil.Unload(uiName);
        }

        public static void Close<T>()
        {
            string uiName = typeof(T).Name;
            Game.Scene.GetComponent<UIComponent>().Remove(uiName);
            ResourcesUtil.Unload(uiName);
        }
    }
}
