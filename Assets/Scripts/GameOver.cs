using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.ScenesManagement;

public class GameOver : MonoBehaviour {

    public Canvas gameOverCanvas;
    public Text scoreText;

    private AudioSource gameOverSound;
    private Texture2D standardCursor;

    void Start()
    {
        standardCursor = Resources.Load("standardCursor") as Texture2D;
        gameOverSound = gameObject.AddComponent<AudioSource>();
        gameOverSound.clip = Resources.Load("gameOver") as AudioClip;
    }
	
	// Update is called once per frame
	void Update () {
        if (ScoreManager.missed >= Scenes.configs.maxMissed && !gameOverCanvas.enabled)
            HandleGameOver();
	}

    public void HandleGameOver()
    {
        Cursor.SetCursor(standardCursor, Vector2.zero, CursorMode.ForceSoftware);
        gameOverCanvas.enabled = true;
        scoreText.text = "You scored " + ScoreManager.score + " points !";
        gameOverSound.Play();
        Invoke("StopGame", 0.8f);
    }

    private void StopGame()
    {
        Time.timeScale = 0f;
    }
}
