using System;
using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
          
    [ObjectSystem]
    public class PlayerControllerAwakeSystem : AwakeSystem<PlayerController, GameObject>
    {
	    public override void Awake(PlayerController self, GameObject go)
	    {
		    self.Awake(go);
	    }
    }
      
    [ObjectSystem]
    public class PlayerControllerStartSystem : StartSystem<PlayerController>
    {
	    public override void Start(PlayerController self)
	    {
		    self.Start();
	    }
    }
      
    [ObjectSystem]
    public class PlayerControllerUpdateSystem : UpdateSystem<PlayerController>
    {
	    public override void Update(PlayerController self)
	    {
		    self.Update();
	    }
    }
      
    [ObjectSystem]
    public class PlayerControllerDestroySystem : DestroySystem<PlayerController>
    {
	    public override void Destroy(PlayerController self)
	    {
		    self.Destroy();
	    }
    }

	public class PlayerController: Component
	{
        public void Awake(GameObject go)
        {
            GameObject = go;
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