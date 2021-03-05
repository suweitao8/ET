using ETModel;

namespace ETHotfix
{
	[Event(EventIdType.InitSceneStart)]
	public class InitSceneStart_CreateLoginUI: AEvent
	{
		public override void Run()
		{
			UI ui = UILoginFactory.Create();
			Game.Scene.GetComponent<UIComponent>().Add(ui);
		}
	}

	[Event(EventIdType.SayHello)]
	public class SayHelloEvent : AEvent<string>
	{
		public override void Run(string name)
		{
			Game.Scene.GetComponent<UIComponent>().Remove(name);
			ResourcesUtil.Unload(name);
		}
	}
}
