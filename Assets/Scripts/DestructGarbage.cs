using UnityEngine;
using System.Collections;

public class DestructGarbage : MonoBehaviour {

    private AudioSource fineFireSound;
    private AudioSource badFireSound;

	// Use this for initialization
	void Start () {
        fineFireSound = gameObject.AddComponent<AudioSource>();
        badFireSound = gameObject.AddComponent<AudioSource>();

        fineFireSound.clip = Resources.Load("fineFire") as AudioClip;
        badFireSound.clip = Resources.Load("badSound") as AudioClip;
    }
	

    void OnCollisionEnter(Collision col)
    {
        GameObject collidingObject = col.gameObject;
        if (collidingObject.tag == "Incinerable")
        {
            Destroy(col.gameObject);
            fineFireSound.Play();
        }
        else
        {
            Rigidbody rb = collidingObject.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.velocity = new Vector3(0f, 0f, 0f);
            collidingObject.transform.position = new Vector3(Random.Range(-5.5f, -7.5f), 8f, -3f);
            Destroy(collidingObject.GetComponent<RotateGarbage>());
            ScoreManager.missed += 1;
            badFireSound.Play();
        }
    }
}
