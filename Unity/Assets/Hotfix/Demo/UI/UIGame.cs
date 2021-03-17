using System;
using System.Collections.Generic;
using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
    
    [ObjectSystem]
    public class UIGameAwakeSystem : AwakeSystem<UIGame>
    {
        public override void Awake(UIGame self)
        {
            self.Awake();
        }
    }

    [ObjectSystem]
    public class UIGameStartSystem : StartSystem<UIGame>
    {
        public override void Start(UIGame self)
        {
            self.Start();
        }
    }

    [ObjectSystem]
    public class UIGameUpdateSystem : UpdateSystem<UIGame>
    {
        public override void Update(UIGame self)
        {
            self.Update();
        }
    }

    [ObjectSystem]
    public class UIGameDestroySystem : DestroySystem<UIGame>
    {
        public override void Destroy(UIGame self)
        {
            self.Destroy();
        }
    }

    public class UIGame : Component
	{
        
        public void Awake()
        {
            ReferenceCollector rc = this.GetUIRC();
            rc.GetButton("btnBack").Click(() =>
            {
                GameManager.Instance.fsm.Value = FSMState.Menu;
            });
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
