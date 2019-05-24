using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject player;

    [Range(1,20)]
    public float cameraToPlayer;

    public enum CameraZone
    {
        FOYER,
        CORRIDOR,
        TEMPLE
    };

    public CameraZone currentZone = CameraZone.FOYER;

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
        

        
        if(currentZone == CameraZone.FOYER)
        {
            if (temp.x < 209.0f)
                temp.x = 209.0f;
            else if (temp.x > 241.0f)
                temp.x = 241.0f;

            if (temp.z < -26.0f)
                temp.z = -26.0f;
        }
        else if(currentZone == CameraZone.CORRIDOR)
        {
            if (temp.x < 304.0f)
                temp.x = 304.0f;
            else if (temp.x > 377.0f)
                temp.x = 377.0f;

            if (temp.z < -19.0f)
                temp.z = -19.0f;
        }
        else if(currentZone == CameraZone.TEMPLE)
        {
            if (temp.x < 448.0f)
                temp.x = 448.0f;
            else if (temp.x > 483.0f)
                temp.x = 483.0f;

            if (temp.z < -33.0f)
                temp.z = -33.0f;
        }
        transform.position = temp;
    }
}
