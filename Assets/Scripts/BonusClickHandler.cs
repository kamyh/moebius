using UnityEngine;
using System.Collections;

public class BonusClickHandler : MonoBehaviour {

    public float mouseTimerLimit = 0.50f;


    private bool mouseClicksStarted = false;
    private int mouseClicks = 0; 

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnMouseDown()
    {
        mouseClicks++;
        if (mouseClicksStarted)
        {
            mouseClicks++;
            checkMouseDoubleClick();
            return;
        }
        mouseClicksStarted = true;
        Invoke("checkMouseDoubleClick", mouseTimerLimit);
    }


    private void checkMouseDoubleClick()
    {
        if (mouseClicks > 1)
        {
            ConsumeBonus();
        }
        mouseClicksStarted = false;
        mouseClicks = 0;
    }

    public void ConsumeBonus()
    {
        ScoreManager.missed = ScoreManager.missed == 0 ? 0 : ScoreManager.missed - 1;
        GetComponent<AudioSource>().Play();
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
            r.enabled = false;
        foreach (Collider c in GetComponentsInChildren<Collider>())
            c.enabled = false;
        Destroy(GetComponent<BonusClickHandler>());
        Invoke("DestroySelf", 0.5f);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
