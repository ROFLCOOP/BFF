using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject aIGameObject;
    public Transform spawnLocation;

    public int spawnAmount;
    public int waveMultiplier;
    public float timeBetweenSpawns;

    private float timer;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;


        if (this.transform.childCount == 0/* && other spawns dont have any children*/)
        {//basically starts a new wave
            StartCoroutine(spawnDelay());
        }


    }

    IEnumerator spawnDelay()
    {
        for (int i = 0; i < (spawnAmount * waveMultiplier); i++)
        {
            Instantiate(aIGameObject, spawnLocation);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
        waveMultiplier = waveMultiplier + 1;
    }
}
