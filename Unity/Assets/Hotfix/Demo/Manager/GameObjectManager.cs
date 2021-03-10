using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ETHotfix
{
    public class GameObjectManager
    {
        public static List<ResourceInfo<GameObject>> resourceInfos = new List<ResourceInfo<GameObject>>();
        public static Dictionary<string, List<GameObject>> pools = new Dictionary<string, List<GameObject>>();

        /// <summary>
        /// 申请
        /// </summary>
        public static GameObject Instantiate(string name)
        {
            ResourceInfo<GameObject> info = GetResourceInfo(name);
            List<GameObject> gos = GetPool(name);
            GameObject go = info.asset.Instantiate().Name(name);
            gos.Add(go);
            return go;
        }

        /// <summary>
        /// 回收
        /// </summary>
        public static void Destroy(GameObject go)
        {
            ResourceInfo<GameObject> info = GetResourceInfo(go.name);
            List<GameObject> gos = GetPool(go.name);
            gos.Remove(go);
            go.Destroy();
            if (gos.Count == 0)
            {
                info.Recycle();
                resourceInfos.Remove(info);
            }
        }

        /// <summary>
        /// 获取池子
        /// </summary>
        public static List<GameObject> GetPool(string name)
        {
            foreach (var item in pools.Keys)
            {
                if (item == name)
                {
                    return pools[item];
                }
            }

            List<GameObject> gos = new List<GameObject>();
            pools.Add(name, gos);
            return gos;
        }

        /// <summary>
        /// 获取资源信息
        /// </summary>
        public static ResourceInfo<GameObject> GetResourceInfo(string name)
        {
            for (int i = 0; i < resourceInfos.Count; i++)
            {
                if(resourceInfos[i].resName == name)
                {
                    return resourceInfos[i];
                }
            }
            ResourceInfo<GameObject> info = new ResourceInfo<GameObject>(name);
            resourceInfos.Add(info);
            return info;
        }
    }
}
