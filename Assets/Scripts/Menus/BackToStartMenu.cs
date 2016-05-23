using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.ScenesManagement;

public class BackToStartMenu : MonoBehaviour {


	// Use this for initialization
	public void Back()
    {
        ScoreManager.missed = 0;
        ScoreManager.score = 0;
        Time.timeScale = 1f;
        Scenes.Load("StartMenu");
    }
}
