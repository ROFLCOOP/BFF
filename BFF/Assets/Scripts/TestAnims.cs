using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnims : MonoBehaviour
{

    private Animator foxy;
    private bool dead;
    private bool idle;

    // Start is called before the first frame update
    void Start()
    {
        idle = true;
        foxy = GetComponent<Animator>();
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == false)
        {

            if (Input.GetKey(KeyCode.D))
            {
                foxy.SetBool("forwards", true);
                idle = false;
            }

            if (Input.GetKey(KeyCode.W))
            {
                foxy.SetBool("forwards", true);
                idle = false;
            }

            if (Input.GetKey(KeyCode.S))
            {
                foxy.SetBool("forwards", true);
                idle = false;
            }

            if (Input.GetKey(KeyCode.A))
            {
                foxy.SetBool("backwards", true);
                idle = false; 
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (idle == true)
                {
                    foxy.SetBool("stationary", true);
                }

                else if (idle == false)
                {
                    return;
                }
            }

            //


            if (Input.GetKeyUp(KeyCode.D))
            {
                foxy.SetBool("forwards", false);
                idle = true;
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                foxy.SetBool("forwards", false);
                idle = true;
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                foxy.SetBool("forwards", false);
                idle = true;
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                foxy.SetBool("backwards", false);
                idle = true;
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                foxy.SetBool("stationary", false);
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
