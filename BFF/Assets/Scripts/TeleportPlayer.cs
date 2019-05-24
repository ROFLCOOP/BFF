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

    [Header("audiosources")]
    public AudioSource lobbyAudioSource;
    public AudioSource corridorAudioSource;
    public AudioSource templeAudioSource;



    // Start is called before the first frame update
    void Start()
    {
        lobbyAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            lobbyAudioSource.Stop();
            corridorAudioSource.Stop();
            if(this.gameObject.tag == "FoyerTeleport")
            {
                player.gameObject.transform.position = corridorTeleportLocation.position;
                corridorAudioSource.Play();
                mainCam.GetComponent<CameraMovement>().currentZone = CameraMovement.CameraZone.CORRIDOR;
                
            }
            else if(this.gameObject.tag == "CorridorTeleport")
            {
                player.gameObject.transform.position = templeTeleportLocation.position;
                templeAudioSource.Play();
                mainCam.GetComponent<CameraMovement>().currentZone = CameraMovement.CameraZone.TEMPLE;
            }
        }
    }
}
