using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.ScenesManagement;

public class LevelSelectionNavigationManager : MonoBehaviour {

    public Text loadingText;

	// Use this for initialization
	public void LoadEasyMode()
    {
        SetGuiState(true);
        LevelConfiguration config = new LevelConfiguration();
        config.spawnInterval = 3f;
        Scenes.Load("MiniGame", config);
    }

    public void LoadAverageMode()
    {
        SetGuiState(true);
        LevelConfiguration config = new LevelConfiguration();
        config.spawnInterval = 2f;
        Scenes.Load("MiniGame", config);
    }

    public void LoadHardMode()
    {
        SetGuiState(true);
        LevelConfiguration config = new LevelConfiguration();
        config.spawnInterval = 1f;
        Scenes.Load("MiniGame", config);
    }

    private void SetGuiState(bool loading)
    {
        loadingText.enabled = !loading;
        foreach (Button b in GetComponents<Button>())
            b.enabled = !loading;
    }
}
