using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;

public class ThrashCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        try {
            string collisionResultTag = TagsHelper.recyclableToThrash[col.gameObject.tag];

            if (collisionResultTag == tag)
            {
                Debug.Log("SCORED RIGHT M8 !!");
            }
            else
            {
                Debug.Log("WRONG CONTAINER UHUHU");
            }
            Destroy(col.gameObject);
        } catch(KeyNotFoundException e)
        {
            Debug.Log("You shouldn't have recycled this one dude !");
        }
        Destroy(col.gameObject);
    }
}
