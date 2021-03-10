using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ETEditor
{
    public class AlwaysLoad
    {
        [RuntimeInitializeOnLoadMethod]
        public static void LoadInit()
        {
            SceneManager.LoadScene("Init");
        }
    }
}
