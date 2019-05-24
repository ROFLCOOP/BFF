using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class WaveTrigger : MonoBehaviour
{
    public Spawn spawnMaster;
    public bool hasStarted;


    // Start is called before the first frame update
    void Start()
    {
        hasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(!hasStarted)
                FindObjectOfType<HUDController>().StartTimer();
            spawnMaster.hitTrig = true;
            spawnMaster.waveCountdownText.gameObject.SetActive(true);
        }
    }
}
