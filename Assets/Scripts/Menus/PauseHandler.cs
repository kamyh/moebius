using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseHandler : MonoBehaviour {

    public Canvas canvas;
    public Button muteButton;

    private bool isMute = false;
    
    void Update()
    {
        ScanForKeyStroke();
    }

    public void TogglePauseMenu()
    {
        if (canvas.enabled)
        {
            canvas.enabled = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            canvas.enabled = true;
            Time.timeScale = 0f;
            
        }
    }

    void ScanForKeyStroke()
    {
        if (Input.GetKeyDown("escape")) TogglePauseMenu();
    }

    public void Mute()
    {
        isMute = !isMute;
        AudioListener.volume = isMute ? 0f : 1f;
        muteButton.GetComponentInChildren<Text>().text = isMute ? "mute ✔" : "mute";
    }
}
