using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ScoreManager : MonoBehaviour {

    public static int score = 0;
    public static int missed = 0;

    public int maxMissed = 15;

    public Text scoreText;
    public Text missedText;

	// Use this for initialization
	void Awake () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score " + score;
        missedText.text = "Missed " + missed;
        MissedColorUpdate();
	}

    private void MissedColorUpdate()
    {
        float step = 1f / (float)maxMissed;
        missedText.color = Color.Lerp(missedText.color, getColor(1f - (step * missed)), Time.deltaTime);
    }

    public Color getColor(float ratio)
    {
        float H = ratio * 0.4f; // Hue (note 0.4 = Green, see huge chart below)
        float S = 1f; // Saturation
        float V = 1f; // Brightness

        return Color.HSVToRGB(H, S, V);
    }
}
