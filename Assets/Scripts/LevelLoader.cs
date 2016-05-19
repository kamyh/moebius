using UnityEngine;
using System.Collections;
using Assets.ScenesManagement;
using System;
using System.Collections.Generic;
using Assets.Scripts;

public class LevelLoader : MonoBehaviour {

    private Vector3 initThrashPos = new Vector3(6.6f, -5.25f, -1.5f);
	// Use this for initialization
	void Start () {
        if (Scenes.configs != null)
        {
            SetupGameArea();
        }
    }

    private void SetupGameArea()
    {
        List<string> selectedRecyclables = new List<string>();
        List<string> recyclables = new List<string>(TagsHelper.Recyclables);
        int chosen = 0;
        for(int i = 0; i < Scenes.configs.nbRecyclable; i++)
        {
            chosen = UnityEngine.Random.Range(0, recyclables.Count - 1);
            selectedRecyclables.Add(recyclables[chosen]);
            recyclables.RemoveAt(chosen);
        }
        foreach (string a in selectedRecyclables)
            Debug.Log(a);
        GameObject thrashBox = null;
        
        foreach(string selected in selectedRecyclables)
        {
            thrashBox = GameObject.FindGameObjectWithTag(TagsHelper.recyclableToThrash[selected]);
            thrashBox.transform.position = initThrashPos;
            initThrashPos += Vector3.up * 3;
        }
        Scenes.selectedRecyclables = selectedRecyclables;
    }

}
