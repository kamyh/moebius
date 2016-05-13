using UnityEngine;
using System.Collections.Generic;
using Assets.ScenesManagement;
using Assets.Scripts;

public class SpawnGarbage : MonoBehaviour {

    public ParticleSystem fallingParticles;   

    private List<GameObject> incinerablePool;
    private List<GameObject> recyclablePool;


    // Use this for initialization
    void Start () {
        float spawnInterval = 2f;
        if (Scenes.configs != null)
            spawnInterval = Scenes.configs.spawnInterval;

        incinerablePool = new List<GameObject>();
        recyclablePool = new List<GameObject>();

        var all = Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[];

        foreach (GameObject go in all)
        {
            if (go.tag == TagsHelper.Incinerables)
                incinerablePool.Add(go);
            if (System.Array.Exists(TagsHelper.Recyclables, e => e == go.tag))
                recyclablePool.Add(go);
        }
        InvokeRepeating("popGarbage", 1, spawnInterval);
    }

    private void SetupGameObject(GameObject go)
    {
        go.AddComponent<Rigidbody>();
        go.GetComponent<Rigidbody>().useGravity = false;
        go.AddComponent<RotateGarbage>();
        go.AddComponent<ClickHandler>();
    }

    // Update is called once per frame
    void Update () {
	    
	}

    void popGarbage()
    {
        List<GameObject> poolList;
        float garbageOrRecyclable = Random.Range(0, 100);
        if(garbageOrRecyclable >= 50)
        {
            poolList = recyclablePool;
        }
        else
        {
            poolList = incinerablePool;
        }
        GameObject toInstanciate = poolList[Random.Range(0, poolList.Count - 1)];
        Vector3 popPosition = new Vector3(Random.Range(-2f, 5f), 10f, -1f);
        GameObject garbage = Instantiate(toInstanciate, popPosition, Quaternion.identity) as GameObject;
        //ParticleSystem pSystem = Instantiate(fallingParticles) as ParticleSystem;
        //FollowGarbage fg = pSystem.GetComponent<FollowGarbage>() as FollowGarbage;
        //fg.garbage = garbage;
        SetupGameObject(garbage);

        garbage.GetComponent<Rigidbody>().velocity = new Vector3(0f, -2f, 0f);
    }
}
