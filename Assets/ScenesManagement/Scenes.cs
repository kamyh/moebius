using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Assets.ScenesManagement
{
    public static class Scenes
    {
        public static LevelConfiguration configs;
        public static void Load(string sceneName, LevelConfiguration configs = null)
        {
            if (configs == null) configs = new LevelConfiguration();
            Scenes.configs = configs;
            SceneManager.LoadScene(sceneName);
        }
    }
}
