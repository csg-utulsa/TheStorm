using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LAST UPDATED 12 April 2020

public class alertSniper : MonoBehaviour
{
    // SCRIPTS //
    public Sniper sniper;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the script from the grandparent
        sniper = GetComponentInParent<Transform>().parent.GetComponentInParent<Sniper>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // if collided with by the player or other enemy
        if (!sniper.alerted && (other.tag == "Player"))
        {
            RaycastHit hit;
            player = FindObjectOfType<Player>().transform;
            Vector3 rayDirection = player.position - transform.position;
            if (Physics.Raycast (transform.position, rayDirection, out hit))
            {
                if (hit.collider.tag == "Player")
                {
                    // call the function of the enemy this object belongs to
                    sniper.BecomeAlerted();
                }
            }
        }
    }
}