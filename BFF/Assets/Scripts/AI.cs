using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent agent;
    public CharacterControl player;
    private GameObject playerLocation;

    public HealthPickup healthPickup;


    public int aggroRange;
    public float attackRange;
    public float attackCooldown;

    private float timer;

    public int damage;

    public float pickupDropChance;

    public bool isDead; 

    // Start is called before the first frame update
    void Start()
    {
        playerLocation = GameObject.FindGameObjectWithTag("Player");
        player.playerHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            int randomNum = Random.Range(0, 100);

            if (randomNum <= pickupDropChance)
            {
                Instantiate(healthPickup, this.transform.position, Quaternion.Euler(0, 0, 0));
            }

            Destroy(this.gameObject);
        }

        timer -= Time.deltaTime;
        float distance = Vector3.Distance(agent.transform.position, playerLocation.transform.position);
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
        agent.destination = playerLocation.transform.position;
    }

    void attack()
    {
        agent.destination = playerLocation.transform.position;
        //do some attack
        if (timer < 0)
        {
            player.playerHealth -= damage;
            timer = attackCooldown;
        }
        Debug.Log("attack");


    }



}
