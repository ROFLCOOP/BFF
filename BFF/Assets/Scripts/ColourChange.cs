using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * This is a simple script that just changes the colour of a material of the object.
 * This is done by accepting 2 seperate colours and then bouncing the colour between
 * the 2 by a Time that is defined by Ping
 * */
public class ColourChange : MonoBehaviour
{
    public Color colourA;
    public Color colourB;
    public Color lerpColour;
    public Renderer rendererNew;
    public float ping;


    // Start is called before the first frame update
    void Start()
    {
        // This is grab the Renderer on the object itself. Don't have to define it in inspector
        rendererNew = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lerpColour = Color.Lerp(colourA, colourB, Mathf.PingPong(Time.time, ping));
        rendererNew.material.color = lerpColour;
    }
}
