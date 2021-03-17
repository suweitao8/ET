using System;
using System.Collections.Generic;
using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
    
    [ObjectSystem]
    public class UISettingAwakeSystem : AwakeSystem<UISetting>
    {
        public override void Awake(UISetting self)
        {
            self.Awake();
        }
    }

    [ObjectSystem]
    public class UISettingStartSystem : StartSystem<UISetting>
    {
        public override void Start(UISetting self)
        {
            self.Start();
        }
    }

    [ObjectSystem]
    public class UISettingUpdateSystem : UpdateSystem<UISetting>
    {
        public override void Update(UISetting self)
        {
            self.Update();
        }
    }

    [ObjectSystem]
    public class UISettingDestroySystem : DestroySystem<UISetting>
    {
        public override void Destroy(UISetting self)
        {
            self.Destroy();
        }
    }

    public class UISetting : Component
	{
        
        public void Awake()
        {
            ReferenceCollector rc = this.GetUIRC();
            rc.GetButton("btnClose").Click(() =>
            {
                UIUtil.Close<UISetting>();
            });

            rc.GetDropdown("droLanguage").onValueChanged.AddListener(v =>
            {
                switch (v)
                {
                    case 0:
                        LanguageManager.Instance.SetLanguage("CH");
                        SaveManager.Instance.language.Value = "CH";
                        break;
                    case 1:
                        LanguageManager.Instance.SetLanguage("EN");
                        SaveManager.Instance.language.Value = "EN";
                        break;
                    default:
                        break;
                }
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
