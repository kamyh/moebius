using UnityEngine;
using System.Collections;

public class RotateGarbage : MonoBehaviour {

    private Vector3 rotVector = Vector3.zero;

    // Use this for initialization
    void Start () {
        rotVector = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void FixedUpdate()
    {
        GetComponentInParent<Rigidbody>().transform.Rotate(rotVector);
    }
}
