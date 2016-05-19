using UnityEngine;
using System.Collections;

public class DestructGarbage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        GameObject collidingObject = col.gameObject;
        if(collidingObject.tag == "Incinerable")
            Destroy(col.gameObject);
        else
        {
            Rigidbody rb = collidingObject.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.velocity = new Vector3(0f, 0f, 0f);
            collidingObject.transform.position = new Vector3(Random.Range(-5.5f, -7.5f), 8f, -3f);
            Destroy(collidingObject.GetComponent<RotateGarbage>());
            ScoreManager.missed += 1;
        }
    }
}
