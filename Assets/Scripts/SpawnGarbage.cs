using UnityEngine;
using System.Collections.Generic;
using Assets.ScenesManagement;
using Assets.Scripts;

public class SpawnGarbage : MonoBehaviour {

    public ParticleSystem fallingParticles;
    public GameObject clickHelper;
    public float tuningDifficultyFactor = 10000f;

    private List<GameObject> incinerablePool;
    private List<GameObject> recyclablePool;
    private GameObject bonus;
    private float spawnInterval = 2f;
    private float fallVelocity = -2f;
    private float bonusSpawnRatePercentage = 3f;

    // Use this for initialization
    void Start () {
        if (Scenes.configs != null)
        {
            spawnInterval = Scenes.configs.spawnInterval;
            fallVelocity = Scenes.configs.fallVelocity;
            bonusSpawnRatePercentage = Scenes.configs.bonusSpawnRatePercent;
        }

        incinerablePool = new List<GameObject>();
        recyclablePool = new List<GameObject>();

        foreach (string tag in Scenes.selectedRecyclables)
        {
            GameObject[] recyclables = GameObject.FindGameObjectsWithTag(tag);
            if (recyclables.Length > 0)
            {
                recyclablePool.AddRange(new List<GameObject>(recyclables));
            }
        }
        GameObject[] incinerables = GameObject.FindGameObjectsWithTag(TagsHelper.Incinerables);
        if (incinerables.Length > 0)
        {
            incinerablePool.AddRange(new List<GameObject>(incinerables));
        }

        bonus = GameObject.FindGameObjectWithTag("Bonus");
        Invoke("PopGarbage", 1);
    }

    private void SetupGameObject(GameObject go)
    {
        Rigidbody rb = go.AddComponent<Rigidbody>();
        rb.useGravity = false;
        go.AddComponent<RotateGarbage>();
        go.AddComponent<ClickHandler>();
        AudioSource aSource = go.AddComponent<AudioSource>();
        aSource.clip = Resources.Load("grab") as AudioClip;
        GameObject helper = Instantiate(clickHelper, go.transform.position, Quaternion.identity) as GameObject;
        helper.transform.parent = go.transform;
    }

    private void SetupBonusObject(GameObject go)
    {
        Rigidbody rb = go.AddComponent<Rigidbody>();
        rb.useGravity = false;
        go.AddComponent<RotateGarbage>();
        AudioSource aSource = go.AddComponent<AudioSource>();
        aSource.clip = Resources.Load("bonus") as AudioClip;
        go.AddComponent<BonusClickHandler>();
    }

    void PopGarbage()
    {
        float bonusOrNotBonus = Random.Range(0f, 100f);
        int tmpScore = ScoreManager.score >= 0 ? ScoreManager.score : 0;
        if (bonusOrNotBonus > bonusSpawnRatePercentage)
        {
            List<GameObject> poolList;
            int garbageOrRecyclable = Random.Range(0, 100);
            if (garbageOrRecyclable >= 50)
            {
                poolList = recyclablePool;
            }
            else
            {
                poolList = incinerablePool;
            }
            GameObject toInstanciate = poolList[Random.Range(0, poolList.Count - 1)];
            Vector3 popPosition = new Vector3(Random.Range(-2f, 4f), 10f, 0f);
            GameObject garbage = Instantiate(toInstanciate, popPosition, Quaternion.identity) as GameObject;
            SetupGameObject(garbage);
            //ParticleSystem pSystem = Instantiate(fallingParticles) as ParticleSystem;
            //FollowGarbage fg = pSystem.GetComponent<FollowGarbage>() as FollowGarbage;
            //fg.garbage = garbage;
            garbage.GetComponent<Rigidbody>().velocity = new Vector3(0f, fallVelocity - (((float)tmpScore) / tuningDifficultyFactor), 0f);
        }
        else
        {
            Vector3 popPosition = new Vector3(Random.Range(-2f, 4f), 10f, 1f);
            GameObject bonusObj = Instantiate(bonus, popPosition, Quaternion.identity) as GameObject;
            SetupBonusObject(bonusObj);
            bonusObj.layer = 0;
            bonusObj.GetComponent<Rigidbody>().velocity = new Vector3(0f, 2 * fallVelocity - (((float)tmpScore) / tuningDifficultyFactor), 0f);
        }
        Invoke("PopGarbage", spawnInterval / ((tmpScore / tuningDifficultyFactor) + 1f));
    }
}
