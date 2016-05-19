using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.ScenesManagement;

public class BackToStartMenu : MonoBehaviour {


	// Use this for initialization
	public void Back()
    {
        Scenes.Load("StartMenu");
    }
}
