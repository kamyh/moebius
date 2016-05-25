using UnityEngine;
using System.Collections;

public class FireSpawner : MonoBehaviour {

    public ParticleSystem fire;
    public float yOffset = -6.3f;
    public float zOffset = -1f;
    public float xStart = -10f;
    public float xStop = 10f;
    public float step = 0.5f;

	// Use this for initialization
	void Start () {
        SpawnFire();
	}

    void SpawnFire()
    {
        for (float x = xStart; x < xStop; x += step)
        {
            ParticleSystem spawn = Instantiate(fire, new Vector3(x, yOffset, zOffset), Quaternion.identity) as ParticleSystem;
            spawn.startDelay = Random.Range(0.0f, 0.9f);
        }
    }
	
}
