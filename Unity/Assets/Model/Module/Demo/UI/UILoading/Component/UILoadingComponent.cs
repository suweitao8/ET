using UnityEngine;
using UnityEngine.UI;

namespace ETModel
{
	[ObjectSystem]
	public class UiLoadingComponentAwakeSystem : AwakeSystem<UILoadingComponent>
	{
		public override void Awake(UILoadingComponent self)
		{
			self.txtProcess = self.GetParent<UI>().GameObject.Get<GameObject>("txtProcess").GetComponent<Text>();
			self.imgProcess = self.GetParent<UI>().GameObject.Get<GameObject>("imgProcess").GetComponent<Image>();
		}
	}

	[ObjectSystem]
	public class UiLoadingComponentStartSystem : StartSystem<UILoadingComponent>
	{
		public override void Start(UILoadingComponent self)
		{
			StartAsync(self).Coroutine();
		}
		
		public async ETVoid StartAsync(UILoadingComponent self)
		{
			TimerComponent timerComponent = Game.Scene.GetComponent<TimerComponent>();
			long instanceId = self.InstanceId;
			while (true)
			{
				await timerComponent.WaitAsync(1000);

				if (self.InstanceId != instanceId)
				{
					return;
				}

				BundleDownloaderComponent bundleDownloaderComponent = Game.Scene.GetComponent<BundleDownloaderComponent>();
				if (bundleDownloaderComponent == null)
				{
					continue;
				}
				self.txtProcess.text = $"{bundleDownloaderComponent.Progress}%";
				self.imgProcess.fillAmount = (bundleDownloaderComponent.Progress + 1) * 1f / 100f;
			}
		}
	}

	public class UILoadingComponent : Component
	{
		public Text txtProcess;
		public Image imgProcess;
	}
}
