using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent agent;
    private GameObject player;

    public int aggroRange;
    public float attackRange;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(agent.transform.position, player.transform.position);
        if (distance > aggroRange)
        {
            find();
        }
        else if (distance < aggroRange && distance > attackRange)
        {
            chase();
        }
        else if (distance < attackRange)
        {
            attack();
        }
        Debug.Log(distance);
    }

    void find()
    {
        Debug.Log("finding");
        agent.destination = new Vector3(this.gameObject.transform.position.x + Random.Range(-2, 2),
                                        this.gameObject.transform.position.y,
                                        this.gameObject.transform.position.z + Random.Range(-2, 2));
    }

    void chase()
    {
        agent.destination = player.transform.position;
    }

    void attack()
    {
        agent.destination = player.transform.position;
        //do some attack
        Debug.Log("attack");
    }

    bool isAlive()
    {
        if (1 == 2)//if hit by bullet 
        {
            //destroy game object
            //return true
        }
        return false;
    }


}
