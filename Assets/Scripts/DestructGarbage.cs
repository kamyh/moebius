using UnityEngine;
using System.Collections;

public class DestructGarbage : MonoBehaviour {

    public ParticleSystem greenFire;
    public ParticleSystem redFire;

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
            SpawnFireAnimation(col.gameObject.transform.position, true);
            Destroy(col.gameObject);
            fineFireSound.Play();
        }
        else
        {
            SpawnFireAnimation(col.gameObject.transform.position, false);
            Rigidbody rb = collidingObject.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.velocity = new Vector3(0f, 0f, 0f);
            collidingObject.transform.position = new Vector3(Random.Range(-5.5f, -7.5f), 8f, -3f);
            Destroy(collidingObject.GetComponent<RotateGarbage>());
            Destroy(collidingObject.GetComponent<ClickHandler>());
            ScoreManager.missed += 1;
            badFireSound.Play();
        }
    }

    private void SpawnFireAnimation(Vector3 position, bool isIncinerable)
    {
        ParticleSystem ps;
        position.Set(position.x, transform.position.y + 2f, position.z);
        if(isIncinerable)
            ps = Instantiate(greenFire, position, Quaternion.identity) as ParticleSystem;
        else
            ps = Instantiate(redFire, position, Quaternion.identity) as ParticleSystem;
        ps.loop = false;
        ps.transform.localScale += Vector3.one * 2f;
        ps.gameObject.AddComponent<ParticleSystemAutoDestroyer>();
    }
}
