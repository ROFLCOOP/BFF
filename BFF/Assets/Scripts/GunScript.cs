using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [Tooltip("How long should the shot take (seconds)")]
    [Range(0, 10)]
    public float shotTime = 0.25f;

    [Tooltip("How far should the shot go")]
    [Range(1, 10)]
    public float shotDistance = 5;

    [Tooltip("How wide should the opening of the shot be")]
    [Range(0, 1)]
    public float shotStartWidth = 0.6f;

    [Tooltip("How wide should the shot be (Degrees)")]
    [Range(1, 180)]
    public float shotEndWidth = 22.5f;

    [Tooltip("How many rays are cast per shot, more means less of a gap between rays")]
    [Range(3, 50)]
    public int shotRays = 5;

    private int killCount = 0;
    public int KillCount { get; }
    
    private int shotCount = 0;
    public int ShowCount { get; }

    Vector3 shotOriginPoint; //set every time the player shoots
    Vector3 shotDirection;

    private float shotCountDown = 0;

    GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && shotCountDown <= 0)
        {
            shotCountDown = shotTime;
            shotOriginPoint = transform.position + transform.forward * 0.25f;
            shotDirection = transform.forward;
            ParticleSystem ShootEffect = transform.Find("Rainbow").gameObject.GetComponent<ParticleSystem>();
            ShootEffect.Play();
            shotCount++;
            Debug.Log("Shot Count = " + shotCount);
        }

        if (shotCountDown > 0) // if shot needs to be based on time, put shoot in here
        {
            //Everything between here and the next comment line is here for debugging
            Vector3 originPoint = shotOriginPoint + ((-Vector3.right * shotStartWidth) * 0.5f);
            Vector3 dir = shotDirection;
            dir = Quaternion.AngleAxis(-shotEndWidth * 0.5f, Vector3.up) * dir;
            for (int i = 0; i < shotRays; i++)
            {
                Debug.DrawLine(originPoint + Vector3.up * 0.1f, (originPoint + Vector3.up * 0.1f) + dir * (shotDistance * ((shotTime - shotCountDown) / shotTime)), Color.red);
                Debug.DrawLine(originPoint, originPoint + dir * shotDistance, Color.blue);
                dir = Quaternion.AngleAxis(shotEndWidth / (shotRays - 1), Vector3.up) * dir;
                originPoint += (Vector3.right * shotStartWidth) / (shotRays - 1);
            }
            //

            shoot();
            shotCountDown -= Time.deltaTime;
        }
    }

    void shoot()
    {

        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        RaycastHit[] hit = new RaycastHit[shotRays];

        Vector3 dir = shotDirection;
        dir = Quaternion.AngleAxis(-shotEndWidth * 0.5f, Vector3.up) * dir;

        Vector3 origin = shotOriginPoint + ((-transform.right * shotStartWidth) * 0.5f);


        bool enemyHit = false; // this bool only exists for debug reasons at the moment
        for (int i = 0; i < shotRays; i++)
        {
            if (Physics.Raycast(origin, dir, out hit[i], shotDistance, layerMask))
            {
                enemyHit = true;
                GameObject enemy = hit[i].collider.gameObject;

                if (hit[i].collider.CompareTag("Enemy")
                 && hit[i].distance <= (shotDistance * ((shotTime - shotCountDown) / shotTime)))
                {
                    enemy.GetComponent<AI>().isDead = true;

                    //Destroy(enemy); // tell enemy they've been hit here
                    killCount++;
                    Debug.Log("Ray: " + i + " Hit Something! Kill Count = " + killCount);
                }
                // optional: compare distance to hit object. e.g. if distance > shotTimer, enemy wasn't hit.
            }
            dir = Quaternion.AngleAxis(shotEndWidth / (shotRays - 1), Vector3.up) * dir;
            origin += (transform.right * shotStartWidth) / (shotRays - 1);
        }

        if (!enemyHit)
        {
            //Debug.Log("None of the rays hit anything.");
        }
    }
}
