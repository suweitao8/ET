using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ETModel
{
    public class ResourcesUtil
    {
        public static T Load<T>(string resName) where T : UnityEngine.Object
        {
            ResourcesComponent resourcesComponent = ETModel.Game.Scene.GetComponent<ResourcesComponent>();
            resourcesComponent.LoadBundle(resName.StringToAB());
            return resourcesComponent.GetAsset(resName.StringToAB(), resName) as T;
        }

        public static void Unload(string resName)
        {
            ETModel.Game.Scene.GetComponent<ResourcesComponent>().UnloadBundle(resName.StringToAB());
        }
    }

}