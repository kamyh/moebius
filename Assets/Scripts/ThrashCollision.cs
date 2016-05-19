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
                ScoreManager.score += 200;
            }
            else
            {
                ScoreManager.score -= 100;
            }
            Destroy(col.gameObject);
        } catch(KeyNotFoundException e)
        {
            e.GetHashCode();
            ScoreManager.score -= 200;
        }
        Destroy(col.gameObject);
    }
}
