using System.Collections;
using System.Collections.Generic;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
    /// <summary>
    /// 资源信息
    /// </summary>
    public class ResourceInfo<T> where T : UnityEngine.Object
    {
        public string resName;
        public T asset;

        public ResourceInfo(string resName)
        {
            this.resName = resName;
            this.asset = ResourcesUtil.Load<T>(resName);
        }

        public void Recycle()
        {
            ResourcesUtil.Unload(resName);
        }
    }

    /// <summary>
    /// 资源工具类
    /// </summary>
    public static class ResourcesUtil
    {
        public static List<string> assets = new List<string>();

        /// <summary>
        /// 加载资源
        /// </summary>
        /// <typeparam name="T">资源类型</typeparam>
        /// <param name="resName">资源名</param>
        /// <returns>资源</returns>
        public static T Load<T>(string resName) where T : UnityEngine.Object
        {
            ResourcesComponent resourcesComponent = ETModel.Game.Scene.GetComponent<ResourcesComponent>();
            resourcesComponent.LoadBundle(resName.StringToAB());
            assets.Add(resName);
            return resourcesComponent.GetAsset(resName.StringToAB(), resName) as T;
        }

        /// <summary>
        /// 卸载资源
        /// </summary>
        /// <param name="resName">资源名</param>
        public static void Unload(string resName)
        {
            if (assets.Contains(resName) == false) return;
            ETModel.Game.Scene.GetComponent<ResourcesComponent>().UnloadBundle(resName.StringToAB());
        }
    }
}