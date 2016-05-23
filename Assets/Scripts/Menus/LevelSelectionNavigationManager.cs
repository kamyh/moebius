using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.ScenesManagement;

public class LevelSelectionNavigationManager : MonoBehaviour {

    public Text loadingText;

	// Use this for initialization
	public void LoadEasyMode()
    {
        SetGuiLoadingState(true);
        LevelConfiguration config = new LevelConfiguration();
        config.spawnInterval = 3f;
        config.fallVelocity = -2f;
        Scenes.Load("MiniGame", config);
    }

    public void LoadAverageMode()
    {
        SetGuiLoadingState(true);
        LevelConfiguration config = new LevelConfiguration();
        config.spawnInterval = 2f;
        config.fallVelocity = -3f;
        config.nbRecyclable = 3;
        Scenes.Load("MiniGame", config);
    }

    public void LoadHardMode()
    {
        SetGuiLoadingState(true);
        LevelConfiguration config = new LevelConfiguration();
        config.spawnInterval = 1f;
        config.fallVelocity = -4f;
        config.nbRecyclable = 4;
        Scenes.Load("MiniGame", config);
    }

    private void SetGuiLoadingState(bool loading)
    {
        loadingText.enabled = !loading;
        foreach (Button b in GetComponents<Button>())
            b.enabled = !loading;
    }
}
