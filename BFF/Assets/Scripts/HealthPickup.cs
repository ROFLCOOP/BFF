using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healingAmount;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Fox");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.GetComponent<CharacterControl>().playerHealth += healingAmount;
            if (player.GetComponent<CharacterControl>().playerHealth > 100)
                player.GetComponent<CharacterControl>().playerHealth = 100;
            Destroy(this.gameObject);
        }
    }
}
