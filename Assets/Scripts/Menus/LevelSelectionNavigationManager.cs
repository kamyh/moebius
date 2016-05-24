using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.ScenesManagement;

public class LevelSelectionNavigationManager : MonoBehaviour {

    public Text loadingText;

    private Scenes loader;

    void Start()
    {
        loader = gameObject.AddComponent<Scenes>();
    }

    // Use this for initialization
    public void LoadEasyMode()
    {
        SetGuiLoadingState(true);
        LevelConfiguration config = new LevelConfiguration();
        config.spawnInterval = 3f;
        config.fallVelocity = -2f;
        loader.Load("MiniGame", config);
    }

    public void LoadAverageMode()
    {
        SetGuiLoadingState(true);
        LevelConfiguration config = new LevelConfiguration();
        config.spawnInterval = 2f;
        config.fallVelocity = -3f;
        config.nbRecyclable = 3;
        loader.Load("MiniGame", config);
    }

    public void LoadHardMode()
    {
        SetGuiLoadingState(true);
        LevelConfiguration config = new LevelConfiguration();
        config.spawnInterval = 1f;
        config.fallVelocity = -4f;
        config.nbRecyclable = 4;
        loader.Load("MiniGame", config);
    }

    private void SetGuiLoadingState(bool loading)
    {
        loadingText.enabled = !loading;
        foreach (Button b in GetComponents<Button>())
            b.enabled = !loading;
    }

}
