using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [Range(1, 100)]
    public int speed = 10;
    public GameObject m_projectile;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 prevPos = transform.position;
        playerMove();

        Vector3 aimDir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(aimDir.x, aimDir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

        if(Input.GetMouseButtonDown(0))
            shoot();

        if(transform.position != prevPos)
        {
            GameObject cam = GameObject.Find("Main Camera");
            Vector3 temp = cam.transform.position;
            temp.x = transform.position.x;
            cam.transform.position = temp;

        }

        Vector3 dir = transform.forward;

        Debug.DrawLine(transform.position + (transform.forward * 0.5f), transform.position + transform.forward * 0.5f + dir * 5 , Color.green);
        dir = Quaternion.AngleAxis(22.5f, Vector3.up) * dir;
        Debug.DrawLine(transform.position + (transform.forward * 0.5f), transform.position + transform.forward * 0.5f + dir * 5.4f, Color.green);
        dir = Quaternion.AngleAxis(-45, Vector3.up) * dir;
        Debug.DrawLine(transform.position + (transform.forward * 0.5f), transform.position + transform.forward * 0.5f + dir * 5.4f, Color.green);
    }

    void shoot()
    {
        GameObject Bullet = Instantiate(m_projectile, transform.position, transform.rotation);
        Bullet.GetComponent<BulletScript>().Facing = transform.forward;
        Bullet.GetComponent<BulletScript>().Velocity = 20;

        int layerMask = 1 << 8;

        layerMask = ~layerMask;

        RaycastHit hit1;
        RaycastHit hit2;
        RaycastHit hit3;

        Vector3 dir = transform.forward;
        dir.Normalize();

        if(!Physics.Raycast(transform.position + (transform.forward * 0.5f), dir, out hit1, 1.0f, layerMask))
        {
            Debug.DrawLine(transform.position + (transform.forward * 0.5f), transform.position + (transform.forward * 0.5f) + dir, Color.green);
            Debug.Log("Raycast 1 did not hit anything");
        }

        dir = Quaternion.AngleAxis(45, Vector3.up) * dir;
        dir.Normalize();

        if (!Physics.Raycast(transform.position + transform.forward * 0.5f, dir, out hit2, 1.0f, layerMask))
        {
            Debug.Log("Raycast 2 did not hit anything");
        }

        dir = Quaternion.AngleAxis(-90, Vector3.up) * dir;
        dir.Normalize();

        if (!Physics.Raycast(transform.position + transform.forward * 0.5f, dir, out hit3, 1.0f, layerMask))
        {
            Debug.Log("Raycast 3 did not hit anything");
        }

        if ( hit1.distance < 0.6f && !hit1.collider.CompareTag("Projectile")
         || hit2.distance < 0.6f && !hit2.collider.CompareTag("Projectile")
         || hit3.distance < 0.6f && !hit3.collider.CompareTag("Projectile"))
        {
            Debug.Log("hit");
        }
    }



    void playerMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
