using System;
using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
          
    [ObjectSystem]
    public class Test1StartSystem : StartSystem<Test1>
    {
	    public override void Start(Test1 self)
	    {
		    self.Start();
	    }
    }
      
    [ObjectSystem]
    public class Test1DestroySystem : DestroySystem<Test1>
    {
	    public override void Destroy(Test1 self)
	    {
		    self.Destroy();
	    }
    }

	public class Test1: Component
	{
	      
        public void Start()
        {
        }
      
        public void Destroy()
        {
        }

    }
}