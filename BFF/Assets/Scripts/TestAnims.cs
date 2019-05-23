using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnims : MonoBehaviour
{

    private Animator foxy;
    private bool dead;
    private bool fire;

    // Start is called before the first frame update
    void Start()
    {
        foxy = GetComponent<Animator>();
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                foxy.SetBool("right", true);
            }

            if (Input.GetKey(KeyCode.S))
            {
                foxy.SetBool("left", true);
            }

            if (Input.GetKey(KeyCode.A))
            {
                foxy.SetBool("forwards", true);
            }

            if (Input.GetKey(KeyCode.D))
            {
                foxy.SetBool("backwards", true);
            }

            //

            if (Input.GetKeyUp(KeyCode.W))
            {
                foxy.SetBool("right", false);
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                foxy.SetBool("left", false);
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                foxy.SetBool("forwards", false);
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                foxy.SetBool("backwards", false);
            }
        }

        // Testing death anim.

        if (Input.GetKeyDown(KeyCode.Space))
        {
            foxy.SetBool("death", true);
            dead = true;
        }
    }
}
