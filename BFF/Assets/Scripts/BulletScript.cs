using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Velocity = 0;
    public Vector3 Facing;
    private float timer = 0;

    [Range(1, 10)]
    public const float lifeTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.Normalize(Facing * Velocity);
        float dot = Vector3.Dot(transform.right, dir);
        float rotationAmount = Mathf.Cos(dot);

        float temp = Vector3.Dot(transform.up, dir);

        if(temp > 0.0f)
        {
            transform.Rotate(Vector3.forward, -rotationAmount);
        }
        if (temp < 0.0f)
        {
            transform.Rotate(Vector3.forward, rotationAmount);
        }

        timer += Time.deltaTime;
        transform.position += Facing * Velocity * Time.deltaTime;

        if(timer >= lifeTime)
        {
            Destroy(transform.gameObject);
            Debug.Log("bullet ded");
        }
    }
}
