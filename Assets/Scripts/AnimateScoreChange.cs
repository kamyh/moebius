using UnityEngine;
using System.Collections;

public class AnimateScoreChange : MonoBehaviour {

    public float animationTime = 1f;
    public float scaleFactor = 1.005f;
    public float deltaPos = 0.6f;
    public int nbMaxFrames = 100;
    private float startTime;
    private int frameCounter = 0;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
    }

	
	// Update is called once per frame
	void Update () {

        if(Time.time - startTime < animationTime && frameCounter++ < nbMaxFrames)
        {
            transform.localScale = transform.localScale * scaleFactor;
            transform.position = Vector3.Lerp(transform.position, transform.position + (Vector3.up * deltaPos), Time.deltaTime);
        }
        else
        {
            frameCounter = 0;
            Destroy(gameObject);
        }
    }

    public void SetText(string text)
    {
        TextMesh tm = transform.GetComponent<TextMesh>();
        tm.text = text;
    }

    public void SetColor(Color color)
    {
        TextMesh tm = transform.GetComponent<TextMesh>();
        tm.color = color;
    }

}
