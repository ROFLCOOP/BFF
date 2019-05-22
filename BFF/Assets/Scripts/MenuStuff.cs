using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStuff : MonoBehaviour
{
    public GameObject buttonsub;
    public Image text;

    private bool flashing;

    void Start()
    {
        text.canvasRenderer.SetAlpha(0f);
        buttonsub.gameObject.SetActive(false);
        flashing = true;
        Invoke("FadeIn", .5f);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            flashing = false;
            text.gameObject.SetActive(false);
            buttonsub.gameObject.SetActive(true);
        }
    }

    void FadeIn()
    {
        if (flashing == true)
        {
            text.CrossFadeAlpha(1.0f, 1.0f, false);
            Invoke("FadeOut", 1.3f);
        }
    }

    void FadeOut()
    {
        if (flashing == true)
        {
            text.CrossFadeAlpha(0f, 1.0f, false);
            Invoke("FadeIn", 1.3f);
        }
    }
}
