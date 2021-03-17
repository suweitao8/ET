using System;
using System.Collections.Generic;
using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
    
    [ObjectSystem]
    public class UIMenuAwakeSystem : AwakeSystem<UIMenu>
    {
        public override void Awake(UIMenu self)
        {
            self.Awake();
        }
    }

    [ObjectSystem]
    public class UIMenuStartSystem : StartSystem<UIMenu>
    {
        public override void Start(UIMenu self)
        {
            self.Start();
        }
    }

    [ObjectSystem]
    public class UIMenuUpdateSystem : UpdateSystem<UIMenu>
    {
        public override void Update(UIMenu self)
        {
            self.Update();
        }
    }

    [ObjectSystem]
    public class UIMenuDestroySystem : DestroySystem<UIMenu>
    {
        public override void Destroy(UIMenu self)
        {
            self.Destroy();
        }
    }

    public class UIMenu : Component
	{
        
        public void Awake()
        {
            ReferenceCollector rc = this.GetUIRC();
            rc.GetButton("btnSetting").Click(() =>
            {
                UIUtil.Open<UISetting>(UILayer.PopUI);
            });
            rc.GetButton("btnGame").Click(() =>
            {
                GameManager.Instance.fsm.Value = FSMState.Game;
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
