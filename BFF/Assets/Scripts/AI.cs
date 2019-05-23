using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;

    public int aggroRange;
    public float attackRange;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = agent.transform.position.magnitude - player.transform.position.magnitude;
       // if (timer > 1)
       // {
            if(distance > aggroRange)
            {
                find();
            }
            else if (distance < aggroRange && distance > attackRange)
            {
                chase();
            }
            else if(distance < attackRange)
            {
                attack();
            }
            timer = 0;
        Debug.Log(distance);
        //}
    }

    void find()
    {
        Debug.Log("finding");
       // if(agent.transform.position.magnitude - player.transform.position.magnitude < aggroRange)
       // {
       //     chase();
       // }
       // else
       // {
       //     //add some random direction and move that way
       // }
    }

    void chase()
    {
        agent.destination = player.transform.position;
        //if(agent.transform.position.magnitude - player.transform.position.magnitude < attackRange)
        //{
        //    attack();
        //}
        //else if(agent.transform.position.magnitude - player.transform.position.magnitude > aggroRange)
        //{
        //    find();
        //}
        //else
        //{
        //    chase();
        //}

    }

    void attack()
    {
        agent.destination = player.transform.position;
        //do some attack
        Debug.Log("attack");
        
       // if(agent.transform.position.magnitude - player.transform.position.magnitude > attackRange)
       // {
       //     chase();
       // }
       // else
       // {
       //     attack();
       // }

    }

    
}
