using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToBlack : MonoBehaviour
{

    public GameObject hudScreen;
    public GameObject resultScreen;
    public Camera sceneCamera;

    public void EndAnimation()
    {
        hudScreen.SetActive(false);
        resultScreen.SetActive(true);
        sceneCamera.gameObject.SetActive(false);

    }

    public void DisableLayer()
    {
        gameObject.SetActive(false);
    }
}
