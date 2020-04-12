using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LAST UPDATED 12 April 2020

public class alertEnemy : MonoBehaviour
{
    // SCRIPTS //
    public Enemy enemy;
    private Transform player;
        

    // Start is called before the first frame update
    void Start()
    {
        // Grab the script from the grandparent
        enemy = GetComponentInParent<Transform>().parent.GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // if collided with by the player or other enemy
        if (!enemy.alerted && (other.tag == "Player"))
        {
            RaycastHit hit;
            player = FindObjectOfType<Player>().transform;
            Vector3 rayDirection = player.position - transform.position;
            if (Physics.Raycast(transform.position, rayDirection, out hit))
            {
                if (hit.collider.tag == "Player") 
                {
                    // call the function of the enemy this object belongs to
                    enemy.BecomeAlerted();
                }
            }
        }
    }
}