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

    [Header("audiosource and clips")]
    public AudioSource AudioSource;

    public AudioClip lobbyAmbient;
    public AudioClip corridorAmbient;
    public AudioClip templeAmbient;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayOneShot(lobbyAmbient);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            AudioSource.Stop();
            if(this.gameObject.tag == "FoyerTeleport")
            {
                player.gameObject.transform.position = corridorTeleportLocation.position;
                AudioSource.PlayOneShot(corridorAmbient);
                
            }
            else if(this.gameObject.tag == "CorridorTeleport")
            {
                player.gameObject.transform.position = templeTeleportLocation.position;
                AudioSource.PlayOneShot(templeAmbient);
            }
        }
    }
}
