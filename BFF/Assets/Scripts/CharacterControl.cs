﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{
    [Tooltip("How fast should the player move('units'/second)")]
    [Range(1, 100)]
    public int playerSpeed = 10;
    
    private bool playerDead = false;
    public bool PlayerDead { get; }
    

    public Image HealthGauge;
    public float playerHealth = 100;

    //[Tooltip("Insert a Prefab for the player death particle system")]
    //public ParticleSystem DeathParticleSys;

    [Tooltip("How far from the player is the camera on Z")]
    [Range(1, 20)]
    public float cameraToPlayer = 6;


    [Header("footstep stuff")]
    public AudioSource footstepSource;

    Animator animator;

    [Range(0, 10)]
    public float deathAnimationTime = 3;

    float deathTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0) playerDead = true;
        if (playerDead && !animator.GetBool("death"))
        {

            //if (DeathParticleSys != null)
            //{
            //    ParticleSystem DeathPlay = Instantiate(DeathParticleSys, transform.position, Quaternion.identity);
            //    DeathPlay.Play();
            //}
            animator.SetBool("death", true);

            //Pass info to end game screen
            deathTimer += Time.deltaTime;
        }
        else if (!GameObject.Find("HUDCanvas").GetComponent<HUDController>().isPaused && !playerDead)
        {
            Vector3 prevPos = transform.position;
            playerMove();
            Vector3 aimDir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            float angle = Mathf.Atan2(aimDir.x, aimDir.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

            

            //if (transform.position != prevPos)
            //{
            //    HealthGauge.transform.position += transform.position - prevPos;
            //}

            HealthGauge.fillAmount = playerHealth * 0.01f;
            if (footstepSource != null) footstepSource.transform.position = this.transform.position;
        }
    }

    void playerMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (footstepSource != null && !footstepSource.isPlaying) footstepSource.Play();           
            transform.position += Vector3.forward * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (footstepSource != null && !footstepSource.isPlaying) footstepSource.Play();
            transform.position += Vector3.back * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (footstepSource != null && !footstepSource.isPlaying) footstepSource.Play();
            transform.position += Vector3.left * playerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (footstepSource != null && !footstepSource.isPlaying) footstepSource.Play();
            transform.position += Vector3.right * playerSpeed * Time.deltaTime;
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            if (footstepSource != null && footstepSource.isPlaying) footstepSource.Stop();
        }
    }
    
    public bool ReturnDeath()
    {
        return playerDead;
    }
}
