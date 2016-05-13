using UnityEngine;
using System.Collections;
using Assets.ScenesManagement;

public class LaunchGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("ASDASDASD");
        Scenes.Load("miniGame", new LevelConfiguration());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
