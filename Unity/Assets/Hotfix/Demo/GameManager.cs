using System;
using System.Collections.Generic;
using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
    
    [ObjectSystem]
    public class GameManagerAwakeSystem : AwakeSystem<GameManager>
    {
        public override void Awake(GameManager self)
        {
            self.Awake();
        }
    }

    [ObjectSystem]
    public class GameManagerStartSystem : StartSystem<GameManager>
    {
        public override void Start(GameManager self)
        {
            self.Start();
        }
    }

    [ObjectSystem]
    public class GameManagerUpdateSystem : UpdateSystem<GameManager>
    {
        public override void Update(GameManager self)
        {
            self.Update();
        }
    }

    [ObjectSystem]
    public class GameManagerDestroySystem : DestroySystem<GameManager>
    {
        public override void Destroy(GameManager self)
        {
            self.Destroy();
        }
    }

    public class GameManager : Component
	{
        public static GameManager Instance;

        public FSM fsm;

        public void Awake()
        {
            Instance = this;
            InitFSM();
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

        void InitFSM()
        {
            fsm = new FSM();
            fsm.onStateEnter += state =>
            {
                switch (state)
                {
                    case FSMState.Menu:
                        UIUtil.Open<UIMenu>();
                        break;
                    case FSMState.Game:
                        UIUtil.Open<UIGame>();
                        break;
                    default:
                        break;
                }
            };

            fsm.onStateExit += state =>
            {
                switch (state)
                {
                    case FSMState.Menu:
                        UIUtil.Close<UIMenu>();
                        break;
                    case FSMState.Game:
                        UIUtil.Close<UIGame>();
                        break;
                    default:
                        break;
                }
            };

            fsm.Value = FSMState.Menu;
        }
    }
}
