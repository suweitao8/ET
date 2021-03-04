using System;
using System.Net;
using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
	[ObjectSystem]
	public class UiLoginComponentSystem : AwakeSystem<UILoginComponent>
	{
		public override void Awake(UILoginComponent self)
		{
			self.Awake();
		}
	}

	[ObjectSystem]
	public class UiLoginComponentStartSystem : StartSystem<UILoginComponent>
	{
		public override void Start(UILoginComponent self)
		{
			self.Start();
		}
	}

	public class UILoginComponent: Component
	{
		private GameObject account;
		private GameObject loginBtn;

		public void Awake()
		{
			ReferenceCollector rc = this.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
			loginBtn = rc.Get<GameObject>("LoginBtn");
			loginBtn.GetComponent<Button>().onClick.Add(OnLogin);
			this.account = rc.Get<GameObject>("Account");
		}

		public void Start()
        {
			
		}

		public void OnLogin()
		{
			// LoginHelper.OnLoginAsync(this.account.GetComponent<InputField>().text).Coroutine();
			Debug.Log("尝试关闭");
			UIUtil.Close(UIType.UILogin);
		}
	}
}
