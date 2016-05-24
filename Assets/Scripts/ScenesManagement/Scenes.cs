using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.ScenesManagement
{
    public class Scenes : MonoBehaviour
    {
        public static LevelConfiguration configs;
        public static List<string> selectedRecyclables;

        private AudioClip buttonClickSound;

        public void Load(string sceneName, LevelConfiguration configs = null)
        {
            buttonClickSound = Resources.Load("buttonClickSound") as AudioClip;
            StartCoroutine(DelayLoad(sceneName, configs));
        }

        IEnumerator DelayLoad(string sceneName, LevelConfiguration configs = null)
        {
            yield return new WaitForSeconds(buttonClickSound.length);
            if (configs == null) configs = new LevelConfiguration();
            Scenes.configs = configs;
            SceneManager.LoadScene(sceneName);
        }
    }
}
