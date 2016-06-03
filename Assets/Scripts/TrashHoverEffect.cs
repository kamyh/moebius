using UnityEngine;
using System.Collections;

public class TrashHoverEffect : MonoBehaviour {

    private Renderer r;
    private Color32 yellow;
    private Color32 transparent;
    //private AudioSource hoverSound;

	// Use this for initialization
	void Start () {
        yellow = new Color32(255, 255, 0, 255);
        transparent = new Color32(0, 0, 0, 0);
        r = gameObject.GetComponent<Renderer>();
        r.material.SetColor("_OutlineColor", transparent);
        //hoverSound = gameObject.AddComponent<AudioSource>();
        //hoverSound.clip = Resources.Load("hover") as AudioClip;
    }
	
	// Update is called once per frame
	void OnMouseEnter()
    {
        r.material.SetColor("_OutlineColor", yellow);
        //hoverSound.Play();
    }

    void OnMouseExit()
    {
        r.material.SetColor("_OutlineColor", transparent);
    }
}
