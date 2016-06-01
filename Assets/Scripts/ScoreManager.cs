using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Assets.ScenesManagement;

public class ScoreManager : MonoBehaviour {

    public static int baseScore = 100;
    public static int score = 0;
    public static int missed = 0;
    public static int comboMultiplier = 1;
    public static int nbConsecutives = 0;

    private int maxMissed = 10;


    public Text scoreText;
    public Text missedText;
    public Text comboText;

    void Start()
    {
        if(Scenes.configs != null)
        {
            maxMissed = Scenes.configs.maxMissed;
        }
    }

	// Use this for initialization
	void Awake () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateComboMultiplier();
        scoreText.text = "Score: " + score;
        missedText.text = "Missed: " + missed + "/" + Scenes.configs.maxMissed;
        comboText.text = "Combo: x " + comboMultiplier;
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

    public static int ScoreUpComboMultiplier()
    {
        int scored = baseScore * comboMultiplier;
        score += scored;
        return scored;
    }

    public static int ScoreUp()
    {
        int scored = baseScore;
        score += scored;
        return scored;
    }

    public static int ScoreDown()
    {
        int scored = -baseScore * comboMultiplier;
        score += scored;
        return scored;
    }

    public static int HalfScoreDown()
    {
        int scored = -(baseScore / 2) * comboMultiplier;
        score += scored;
        return scored;
    }

    private void UpdateComboMultiplier()
    {
        comboMultiplier = nbConsecutives / 10 + 1;
    }
}
