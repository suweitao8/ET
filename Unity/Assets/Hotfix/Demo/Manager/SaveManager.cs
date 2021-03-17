using System;
using System.Collections.Generic;
using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
    
    [ObjectSystem]
    public class SaveManagerAwakeSystem : AwakeSystem<SaveManager>
    {
        public override void Awake(SaveManager self)
        {
            self.Awake();
        }
    }

    [ObjectSystem]
    public class SaveManagerStartSystem : StartSystem<SaveManager>
    {
        public override void Start(SaveManager self)
        {
            self.Start();
        }
    }

    [ObjectSystem]
    public class SaveManagerUpdateSystem : UpdateSystem<SaveManager>
    {
        public override void Update(SaveManager self)
        {
            self.Update();
        }
    }

    [ObjectSystem]
    public class SaveManagerDestroySystem : DestroySystem<SaveManager>
    {
        public override void Destroy(SaveManager self)
        {
            self.Destroy();
        }
    }

    public class SaveManager : Component
	{
        public static SaveManager Instance;

        public StringPrefs language;

        public void Awake()
        {
            Instance = this;

            language = new StringPrefs("Language", "CH");
        }

        public void Start()
        {
        }

        public void Update()
        {
        }

        public void Destroy()
        {
            Instance = null;
        }

    }
}
