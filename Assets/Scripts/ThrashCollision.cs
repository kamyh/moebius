using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;


public class ThrashCollision : MonoBehaviour {

    public GameObject upDownScoreText;
    public Color scoreUpColor = Color.green;
    public Color scoreDownColor = Color.red;

    private AudioSource trashClosingSound;
    private AudioSource fineSound;
    private AudioSource wrongSound;
    private AudioSource badSound;

	// Use this for initialization
	void Start () {
        trashClosingSound = gameObject.AddComponent<AudioSource>();
        fineSound = gameObject.AddComponent<AudioSource>();
        wrongSound = gameObject.AddComponent<AudioSource>();
        badSound = gameObject.AddComponent<AudioSource>();

        trashClosingSound.clip = Resources.Load("closing") as AudioClip;
        fineSound.clip = Resources.Load("fineSound") as AudioClip;
        wrongSound.clip = Resources.Load("wrongSound") as AudioClip;
        badSound.clip = Resources.Load("badSound") as AudioClip;
    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        GameObject scorePopup = Instantiate(upDownScoreText, col.gameObject.transform.position, upDownScoreText.transform.rotation) as GameObject;
        AnimateScoreChange animation = scorePopup.AddComponent<AnimateScoreChange>();
        int score = 0;
        try {
            string collisionResultTag = TagsHelper.recyclableToThrash[col.gameObject.tag];

            if (collisionResultTag == tag)
            {
                animation.SetColor(scoreUpColor);
                fineSound.Play();
                ScoreManager.nbConsecutives++;
                score = ScoreManager.ScoreUpComboMultiplier();
            }
            else
            {
                animation.SetColor(scoreDownColor);
                wrongSound.Play();
                ScoreManager.nbConsecutives = 0;
                score = ScoreManager.HalfScoreDown();
            }
            Destroy(col.gameObject);
        } catch(KeyNotFoundException e)
        {
            e.GetHashCode();
            animation.SetColor(scoreDownColor);
            badSound.Play();
            ScoreManager.nbConsecutives = 0;
            score = ScoreManager.ScoreDown();
        }
        animation.SetText(score.ToString("+00;-00;+00"));
        trashClosingSound.Play();
        Destroy(col.gameObject);
    }

}
