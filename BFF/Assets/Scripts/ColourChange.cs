using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        rendererNew = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lerpColour = Color.Lerp(colourA, colourB, Mathf.PingPong(Time.time, ping));
        rendererNew.material.color = lerpColour;
    }
}
