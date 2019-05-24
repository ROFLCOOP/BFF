using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSound : MonoBehaviour
{
    public AudioClip[] spawning;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, (spawning.Length - 1));
        source.clip = spawning[rand];
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
