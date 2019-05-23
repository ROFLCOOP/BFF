using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    [Header("AI character prefab")]
    public GameObject aIGameObject;
    [Header("Spawn locations")]
    public Transform[] spawnLocations;

    [Header("Parameters of spawning")]
    public int spawnAmount;
    public int waveMultiplier;
    public float timeBetweenSpawns;
    public float startTimeBetweenWaves;
    public float addedTimeBetweenWaves;

    [Header("Countdown timer for next wave")]
    public Text waveCountdownText;


    private float timer;
    private int childNumber;




    // Start is called before the first frame update
    void Start()
    {
        timer = startTimeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;



        if (numberOfChildren() == 0)
        {
            waveCountdownText.gameObject.SetActive(true);
            if (timer < 0)
            {
                startTimeBetweenWaves = startTimeBetweenWaves + addedTimeBetweenWaves;
                if(startTimeBetweenWaves < 0)
                {
                    startTimeBetweenWaves = 0;
                }
                StartCoroutine(spawnDelay());
                timer = 0;
            }
        }
        else
        {
            timer = startTimeBetweenWaves;
            waveCountdownText.gameObject.SetActive(false);
        }
        waveCountdownText.text = timer.ToString("F2");
    }

    int numberOfChildren()
    {
        for (int i = 0; i < spawnLocations.Length; i++)
        {
            childNumber = this.transform.childCount;
        }
        return childNumber;
    }

    bool areThereChildren()
    {
        if (childNumber > 0)
        {
            return true;
        }
        else
            return false;
    }

    IEnumerator spawnDelay()
    {
        for (int i = 0; i < (spawnAmount * waveMultiplier); i++)
        {
            int index = Random.Range(0, spawnLocations.Length);

            Instantiate(aIGameObject,spawnLocations[index].position,Quaternion.Euler(0,0,0),this.transform);
            
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
        waveMultiplier = waveMultiplier + 1;
    }
}
