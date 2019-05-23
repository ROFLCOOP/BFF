using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent agent;
    public CharacterControl player;


    public int aggroRange;
    public float attackRange;
    public float attackCooldown;

    private float timer;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        player.playerHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        float distance = Vector3.Distance(agent.transform.position, player.gameObject.transform.position);
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
        agent.destination = player.gameObject.transform.position;
    }

    void attack()
    {
        agent.destination = player.gameObject.transform.position;
        //do some attack
        if (timer < 0)
        {
            player.playerHealth -= damage;
            timer = attackCooldown;
        }
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
