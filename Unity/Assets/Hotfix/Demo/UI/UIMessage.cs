using System;
using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
          
    [ObjectSystem]
    public class UIMessageAwakeSystem : AwakeSystem<UIMessage>
    {
	    public override void Awake(UIMessage self)
	    {
		    self.Awake();
	    }
    }
      
    [ObjectSystem]
    public class UIMessageStartSystem : StartSystem<UIMessage>
    {
	    public override void Start(UIMessage self)
	    {
		    self.Start();
	    }
    }
      
    [ObjectSystem]
    public class UIMessageUpdateSystem : UpdateSystem<UIMessage>
    {
	    public override void Update(UIMessage self)
	    {
		    self.Update();
	    }
    }
      
    [ObjectSystem]
    public class UIMessageDestroySystem : DestroySystem<UIMessage>
    {
	    public override void Destroy(UIMessage self)
	    {
		    self.Destroy();
	    }
    }

	public class UIMessage: Component
	{
	      
        public void Awake()
        {
        }
      
        public void Start()
        {
        }
      
        public void Update()
        {
        }
      
        public void Destroy()
        {
        }

    }
}