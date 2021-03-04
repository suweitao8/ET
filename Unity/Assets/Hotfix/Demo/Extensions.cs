using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ETModel;

namespace ETHotfix
{
    public static class Extensions
    {
        public static GameObject Instantiate(this GameObject prefab)
        {
            return GameObject.Instantiate(prefab);
        }
    }
}