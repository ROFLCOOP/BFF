using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToBlack : MonoBehaviour
{

    public GameObject hudScreen;
    public GameObject resultScreen;
    public void EndAnimation()
    {
        hudScreen.SetActive(false);
        resultScreen.SetActive(true);
        
    }

    public void DisableLayer()
    {
        gameObject.SetActive(false);
    }
}
