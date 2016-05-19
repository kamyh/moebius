using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.ScenesManagement;

public class StartMenuNavigationManager : MonoBehaviour {

    public Text loadingText;

	// Use this for initialization
	public void LoadSelectionScene()
    {
        SetGuiState(true);
        Scenes.Load("LevelSelection");
    }

    public void LoadCreditsScene()
    {
        SetGuiState(true);
        Scenes.Load("Credits");
    }

    public void LoadHelpScene()
    {
        SetGuiState(true);
        Scenes.Load("Help");
    }

    private void SetGuiState(bool loading)
    {
        loadingText.enabled = !loading;
        foreach (Button b in GetComponents<Button>())
            b.enabled = !loading;
    }
}
