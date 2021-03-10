using System;
using System.Collections.Generic;
using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
    
    [ObjectSystem]
    public class UILoginAwakeSystem : AwakeSystem<UILogin>
    {
        public override void Awake(UILogin self)
        {
            self.Awake();
        }
    }

    [ObjectSystem]
    public class UILoginStartSystem : StartSystem<UILogin>
    {
        public override void Start(UILogin self)
        {
            self.Start();
        }
    }

    [ObjectSystem]
    public class UILoginUpdateSystem : UpdateSystem<UILogin>
    {
        public override void Update(UILogin self)
        {
            self.Update();
        }
    }

    [ObjectSystem]
    public class UILoginDestroySystem : DestroySystem<UILogin>
    {
        public override void Destroy(UILogin self)
        {
            self.Destroy();
        }
    }

    public class UILogin : Component
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
