using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseHandler : MonoBehaviour {

    public Canvas canvas;

    
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
}
