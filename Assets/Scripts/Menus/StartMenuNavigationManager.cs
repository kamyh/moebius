using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.ScenesManagement;

public class StartMenuNavigationManager : MonoBehaviour {

    public Text loadingText;

    private Scenes loader;

    void Start()
    {
        loader = gameObject.AddComponent<Scenes>();
    }

    // Use this for initialization
    public void LoadSelectionScene()
    {
        SetGuiState(true);
        loader.Load("LevelSelection");
    }

    public void LoadCreditsScene()
    {
        SetGuiState(true);
        loader.Load("Credits");
    }

    public void LoadHelpScene()
    {
        SetGuiState(true);
        loader.Load("Help");
    }

    private void SetGuiState(bool loading)
    {
        loadingText.enabled = !loading;
        foreach (Button b in GetComponents<Button>())
            b.enabled = !loading;
    }
}
