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
        scorePopup.AddComponent<AnimateScoreChange>();
        AnimateScoreChange animation = scorePopup.GetComponent<AnimateScoreChange>();
        int score = 0;
        try {
            string collisionResultTag = TagsHelper.recyclableToThrash[col.gameObject.tag];

            if (collisionResultTag == tag)
            {
                animation.SetColor(scoreUpColor);
                score = 200;
                fineSound.Play();
            }
            else
            {
                animation.SetColor(scoreDownColor);
                score = -100;
                wrongSound.Play();
            }
            Destroy(col.gameObject);
        } catch(KeyNotFoundException e)
        {
            e.GetHashCode();
            animation.SetColor(scoreDownColor);
            score = -200;
            badSound.Play();
        }
        ScoreManager.score += score;
        animation.SetText(score.ToString("+00;-00;+00"));
        trashClosingSound.Play();
        Destroy(col.gameObject);
    }

}
