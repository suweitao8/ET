using System;
using ETModel;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

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

	public class GameManager: Component
	{
        public static GameManager Instance;
        PlayerController pc;

        public GameObject curMap;

        public void Awake()
        {
            Instance = this;
        }
      
        public void Start()
        {
            InitGame();
        }
      
        public void Update()
        {
        }
      
        public void Destroy()
        {
            Instance = null;
        }

        /// <summary>
        /// 初始化游戏
        /// </summary>
        void InitGame()
        {
            ResourcesUtil.Load<GameObject>("DirectionalLight").Instantiate();
            CinemachineVirtualCamera virtualCamera =
                ResourcesUtil.Load<GameObject>("MainCamera")
                .Instantiate()
                .GetComponentInChildren<CinemachineVirtualCamera>();
            GameObject playerGO = ResourcesUtil.Load<GameObject>("Player").Instantiate();
            virtualCamera.m_Follow = playerGO.transform;
            pc = ComponentFactory.Create<PlayerController, GameObject>(playerGO);
            Game.Scene.AddComponent(pc);

            LoadMap(0, 0);
        }

        /// <summary>
        /// 加载地图
        /// </summary>
        void LoadMap(int mapIndex, int birthIndex)
        {
            if (curMap != null)
            {
                ResourcesUtil.Unload(curMap.name);
            }
            curMap = ResourcesUtil.Load<GameObject>($"Map{mapIndex}").Instantiate();
            curMap.name = $"Map{mapIndex}";
            pc.transform.position =
                curMap.GetComponent<ReferenceCollector>()
                .Get<GameObject>($"Birth{birthIndex}")
                .transform.position;
        }
    }
}