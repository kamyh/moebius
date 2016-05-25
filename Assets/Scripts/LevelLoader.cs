using UnityEngine;
using Assets.ScenesManagement;
using System.Collections.Generic;
using Assets.Scripts;

public class LevelLoader : MonoBehaviour {

    public Canvas pauseMenu;
    public Canvas gameOverCanvas;

    private Vector3 initThrashPos = new Vector3(6.8f, -5.0f, -1.5f);
	// Use this for initialization
	void Start () {
        pauseMenu.enabled = false;
        gameOverCanvas.enabled = false;
        if (Scenes.configs == null)
            Scenes.configs = new LevelConfiguration();
        SetupGameArea();
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

        GameObject thrashBox = null;
        initThrashPos += Vector3.up * ((4f - (float)selectedRecyclables.Count)/2f) * 2.8f;
        foreach(string selected in selectedRecyclables)
        {
            thrashBox = GameObject.FindGameObjectWithTag(TagsHelper.recyclableToThrash[selected]);
            thrashBox.transform.position = initThrashPos;
            initThrashPos += Vector3.up * 2.8f;
        }
        Scenes.selectedRecyclables = selectedRecyclables;
    }

}
