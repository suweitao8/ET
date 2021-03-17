using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ETModel;
using UnityEngine.UI;
using System;
using System.Threading;

namespace ETHotfix
{
    public static class Extensions
    {
        public static void DestroyFromAB(this GameObject self)
        {
            GameObjectManager.Destroy(self);
        }

        /// <summary>
        /// 实例化
        /// </summary>
        public static GameObject Instantiate(this GameObject prefab)
        {
            return GameObject.Instantiate(prefab);
        }

        /// <summary>
        /// 设置名字，并返回gameobject
        /// </summary>
        public static GameObject Name(this GameObject go, string newName)
        {
            go.name = newName;
            return go;
        }

        /// <summary>
        /// 设置位置
        /// </summary>
        public static GameObject Position(this GameObject go, Vector3 pos)
        {
            go.transform.position = pos;
            return go;
        }

        /// <summary>
        /// 设置旋转
        /// </summary>
        public static GameObject Rotation(this GameObject go, Quaternion rot)
        {
            go.transform.rotation = rot;
            return go;
        }

        /// <summary>
        /// 清空transform
        /// </summary>
        public static GameObject Identity(this GameObject go)
        {
            go.transform.localPosition = Vector3.zero;
            go.transform.localRotation = Quaternion.identity;
            go.transform.localScale = Vector3.one;
            return go;
        }

        /// <summary>
        /// 获取该对象上的按钮
        /// </summary>
        public static Button ToButton(this GameObject go)
        {
            Button Button = go.GetComponent<Button>();
            if (Button == null)
            {
                throw new System.Exception("没有 Button");
            }
            return Button;
        }

        /// <summary>
        /// 获取身上的text
        /// </summary>
        public static Text ToText(this GameObject go)
        {
            Text Text = go.GetComponent<Text>();
            if (Text == null)
            {
                throw new System.Exception("没有 Text");
            }
            return Text;
        }

        /// <summary>
        /// 获取身上的image
        /// </summary>
        public static Image ToImage(this GameObject go)
        {
            Image Image = go.GetComponent<Image>();
            if (Image == null)
            {
                throw new System.Exception("没有 Image");
            }
            return Image;
        }

        /// <summary>
        /// 获取rc上的button
        /// </summary>
        public static Button GetButton(this ReferenceCollector rc, string key)
        {
            return rc.GetGameObject(key).GetComponent<Button>();
        }

        public static InputField GetInputField(this ReferenceCollector rc, string key)
        {
            return rc.GetGameObject(key).GetComponent<InputField>();
        }

        /// <summary>
        /// 获取rc的Dropdown
        /// </summary>
        public static Dropdown GetDropdown(this ReferenceCollector rc, string key)
        {
            return rc.GetGameObject(key).GetComponent<Dropdown>();
        }

        /// <summary>
        /// 获取Animator
        /// </summary>
        public static Animator GetAnimator(this ReferenceCollector rc, string key)
        {
            return rc.GetGameObject(key).GetComponent<Animator>();
        }

        /// <summary>
        /// 获取SpriteRenderer
        /// </summary>
        public static SpriteRenderer GetSprite(this ReferenceCollector rc, string key)
        {
            return rc.GetGameObject(key).GetComponent<SpriteRenderer>();
        }

        /// <summary>
        /// 获取Animation
        /// </summary>
        public static Animation GetAnimation(this ReferenceCollector rc, string key)
        {
            return rc.GetGameObject(key).GetComponent<Animation>();
        }

        /// <summary>
        /// 获取rc上的text
        /// </summary>
        public static Text GetText(this ReferenceCollector rc, string key)
        {
            return rc.GetGameObject(key).GetComponent<Text>();
        }

        /// <summary>
        /// 获取语言标识
        /// </summary>
        public static LanguageID GetLanguageID(this ReferenceCollector rc, string key)
        {
            return rc.GetGameObject(key).GetComponent<LanguageID>();
        }

        /// <summary>
        /// 获取rc上的transform
        /// </summary>
        public static Transform GetTransform(this ReferenceCollector rc, string key)
        {
            return rc.GetGameObject(key).transform;
        }

        /// <summary>
        /// 获取rc上的gameobject
        /// </summary>
        public static GameObject GetGameObject(this ReferenceCollector rc, string key)
        {
            GameObject ret = rc.Get<GameObject>(key);
            if (ret == null)
            {
                Debug.LogError($"{rc.gameObject.name}的rc没有{key}");
                return null;
            }
            return ret;
        }

        /// <summary>
        /// 获取rc上的一个text
        /// </summary>
        public static Image GetImage(this ReferenceCollector rc, string key)
        {
            return rc.GetGameObject(key).GetComponent<Image>();
        }

        /// <summary>
        /// 获取UI的ReferenceCollector
        /// </summary>
        public static ReferenceCollector GetUIRC(this Component component)
        {
            return component.GetUIGO().GetComponent<ReferenceCollector>();
        }

        /// <summary>
        /// 获取GameObject身上的ReferenceCollector
        /// </summary>
        public static ReferenceCollector GetGORC(this Component component)
        {
            return component.GameObject.GetComponent<ReferenceCollector>();
        }

        /// <summary>
        /// 获取UI的游戏对象
        /// </summary>
        public static GameObject GetUIGO(this Component component)
        {
            return component.GetParent<UI>().GameObject;
        }

        /// <summary>
        /// 注册点击，注意这里不是AddListener，在ILRuntime会出错，以为是UnityEvent，不能用
        /// </summary>
        public static Button Click(this Button button, Action callback)
        {
            button.onClick.Add(callback);
            return button;
        }

        /// <summary>
        /// 销毁这个游戏对象
        /// </summary>
        public static void Destroy(this GameObject go)
        {
            GameObject.Destroy(go);
        }

        /// <summary>
        /// time的单位是毫秒
        /// </summary>
        public static async ETTask WaitAsync(this Component component, long time, CancellationToken cancellationToken)
        {
            TimerComponent timerComponent = ETModel.Game.Scene.GetComponent<TimerComponent>();
            await timerComponent.WaitAsync(time, cancellationToken);
        }

        public static async ETTask WaitAsync(this Component component, long time)
        {
            TimerComponent timerComponent = ETModel.Game.Scene.GetComponent<TimerComponent>();
            await timerComponent.WaitAsync(time);
        }

        /// <summary>
        /// 把List塞到Queue里面
        /// </summary>
        public static void ToQueue<T>(this List<T> self, Queue<T> queue)
        {
            for (int i = 0; i < self.Count; i++)
            {
                queue.Enqueue(self[i]);
            }
        }

        /// <summary>
        /// 使用Quaternion平滑过度的方式，让self看向target
        /// </summary>
        public static void LookTo(this Transform self, Vector3 target)
        {
            Vector3 direction = target - self.position;
            direction.y = 0f;
            if (direction != Vector3.zero)
                self.rotation = Quaternion.Slerp(self.rotation,
                    Quaternion.LookRotation(direction),
                    5f * Time.deltaTime);
        }

        /// <summary>
        /// 注册事件
        /// </summary>
        public static void Register(this object self, string eventName)
        {
            EventManager.Register(self, eventName);
        }

        /// <summary>
        /// 注销
        /// </summary>
        public static void Deregister(this object self)
        {
            EventManager.Deregister(self);
        }

        /// <summary>
        /// 调用
        /// </summary>
        public static void Fire(this object self, string eventName, params object[] args)
        {
            EventManager.Fire(eventName, args);
        }

        public static async ETTask<K> Call<T, K>(this Session self, T request) where T: IRequest where K : IResponse
        {
            return (K)(await self.Call(request));
        }
    }
}