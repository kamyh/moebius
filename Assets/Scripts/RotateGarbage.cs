using UnityEngine;
using System.Collections;

public class RotateGarbage : MonoBehaviour {

    private Vector3 rotVector = Vector3.zero;

    // Use this for initialization
    void Start () {
        rotVector = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f));
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void FixedUpdate()
    {
        GetComponentInParent<Rigidbody>().transform.Rotate(rotVector);
    }
}
