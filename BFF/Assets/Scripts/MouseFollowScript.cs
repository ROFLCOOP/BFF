﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollowScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
        Debug.Log(Cursor.lockState);
    }
}