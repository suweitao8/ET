using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ETModel;
using UnityEngine.SceneManagement;

namespace ETHotfix
{
    public class SceneUtil
    {
        public static async ETVoid Load(string sceneName)
        {
            try
            {
                string curSceneName = SceneManager.GetActiveScene().name;
                if (curSceneName != "Init")
                {
                    ResourcesUtil.Unload(curSceneName);
                }
                // 加载场景资源
                await ETModel.Game.Scene.GetComponent<ResourcesComponent>().LoadBundleAsync(sceneName.StringToAB());
                // 切换到map场景
                using (SceneChangeComponent sceneChangeComponent = ETModel.Game.Scene.AddComponent<SceneChangeComponent>())
                {
                    await sceneChangeComponent.ChangeSceneAsync(sceneName);
                }
            }
            catch (System.Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }
}