using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToBlack : MonoBehaviour
{

    public GameObject hudScreen;
    public GameObject resultScreen;
    public Camera[] sceneCameras;

    public void EndAnimation()
    {
        hudScreen.SetActive(false);
        resultScreen.SetActive(true);
        foreach(Camera cam in sceneCameras)
        {
            cam.gameObject.SetActive(false);
        }

    }

    public void DisableLayer()
    {
        gameObject.SetActive(false);
    }
}
