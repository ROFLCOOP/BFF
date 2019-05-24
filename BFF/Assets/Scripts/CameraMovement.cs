using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject player;

    [Range(1,20)]
    public float cameraToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.x = player.transform.position.x;
        temp.z = player.transform.position.z - cameraToPlayer;
        

        transform.position = temp;
        
    }
}
