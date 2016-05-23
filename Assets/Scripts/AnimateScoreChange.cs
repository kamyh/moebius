using UnityEngine;
using System.Collections;

public class AnimateScoreChange : MonoBehaviour {

    public float animationTime = 1f;
    public float scaleFactor = 1.005f;
    public float deltaPos = 0.6f;
    private float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
    }

	
	// Update is called once per frame
	void Update () {

        if(Time.time - startTime < animationTime)
        {
            transform.localScale = transform.localScale * scaleFactor;
            transform.position = Vector3.Lerp(transform.position, transform.position + (Vector3.up * deltaPos), Time.deltaTime);
        }
        else
        {
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
