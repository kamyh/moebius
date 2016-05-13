using UnityEngine;
using System.Collections;

public class FollowGarbage : MonoBehaviour {

    public GameObject garbage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        transform.position = garbage.transform.position;
    }
}
