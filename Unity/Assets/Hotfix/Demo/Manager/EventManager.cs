using System.Collections;
using System.Collections.Generic;
using ETModel;
using UnityEngine;
using System.Reflection;

namespace ETHotfix
{
	/// <summary>
	/// 事件信息
	/// </summary>
	public class EventInfo
	{
		public object obj;
		public string eventName;
		public MethodInfo method;

		public EventInfo(object obj, string eventName, MethodInfo method)
		{
			this.obj = obj;
			this.eventName = eventName;
			this.method = method;
		}
	}

	/// <summary>
	/// 反射事件系统
	/// </summary>
	public static class EventManager
	{
		public static Dictionary<string, List<EventInfo>> events = new Dictionary<string, List<EventInfo>>();

		/// <summary>
		/// 注册
		/// </summary>
		public static void Register(object obj, string eventName)
		{
			List<EventInfo> infos = GetEventInfoList(eventName);
			MethodInfo method = obj.GetType().GetMethod(eventName);
			EventInfo tempInfo = new EventInfo(obj,
				eventName,
				method);
			infos.Add(tempInfo);
		}

		/// <summary>
		/// 注销
		/// </summary>
		public static void Deregister(object obj)
		{
			foreach (var eventName in events.Keys)
			{
				List<EventInfo> infos = events[eventName];
				for (int i = infos.Count - 1; i >= 0; i--)
				{
					if (infos[i].obj == obj)
					{
						infos.RemoveAt(i);
					}
				}
			}
		}

		/// <summary>
		/// 调用
		/// </summary>
		public static void Fire(string eventName, params object[] args)
		{
			List<EventInfo> infos = GetEventInfoList(eventName);
			foreach (var info in infos)
			{
				info.method.Invoke(info.obj, args);
			}
		}

		/// <summary>
		/// 获取事件信息列表
		/// </summary>
		static List<EventInfo> GetEventInfoList(string eventName)
		{
			if (events.ContainsKey(eventName) == false)
			{
				events.Add(eventName, new List<EventInfo>());
			}
			return events[eventName];
		}
	}
}