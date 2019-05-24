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

    public GameObject deathParticles;

    public int aggroRange;
    public float attackRange;
    public float attackCooldown;

    private float timer;

    public int damage;

    public float pickupDropChance;

    public bool isDead;

    Animator animator;

    [Tooltip("how much time the death animation takes")]
    public const float animationTime = 3;

    private float deathTimer = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        playerLocation = GameObject.FindGameObjectWithTag("Player");
        ParticleSystem particleSystem = this.gameObject.GetComponent<ParticleSystem>();

        player = playerLocation.GetComponent<CharacterControl>();
        
        particleSystem.Play();

        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            deathTimer += Time.deltaTime;

            if (deathTimer >= animationTime + 3)
            {
                deathParticles.SetActive(true);
                int randomNum = Random.Range(0, 100);

                if (randomNum <= pickupDropChance)
                {
                    Instantiate(healthPickup, transform.position, Quaternion.identity);
                }

                Destroy(gameObject);
            }
            else if (deathTimer >= animationTime)
            {
                transform.position += Vector3.down * Time.deltaTime;
            }
            else if (GetComponent<BoxCollider>().enabled)
            {
                if (animator != null)
                    animator.SetBool("enemydeath", true);
                GetComponent<BoxCollider>().enabled = false;
            }


        }
        else
        {
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
