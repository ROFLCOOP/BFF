using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{

    public GameObject player;

    [Header("camera")]
    public GameObject mainCam;



    [Header("teleport locations")]
    public Transform corridorTeleportLocation;
    public Transform templeTeleportLocation;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(this.gameObject.tag == "FoyerTeleport")
            {
                player.gameObject.transform.position = corridorTeleportLocation.position;

                
            }
            else if(this.gameObject.tag == "CorridorTeleport")
            {
                player.gameObject.transform.position = templeTeleportLocation.position;

            }
        }
    }
}
