using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LAST UPDATED 12 April 2020

public class alertSpotter : MonoBehaviour
{
    // SCRIPTS //
    public Spotter spotter;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the script from the grandparent
        spotter = GetComponentInParent<Transform>().parent.GetComponentInParent<Spotter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // if collided with by the player or other enemy
        if (!spotter.alerted && (other.tag == "Player"))
        {
            RaycastHit hit;
            player = FindObjectOfType<Player>().transform;
            Vector3 rayDirection = player.position - transform.position;
            if (Physics.Raycast(transform.position, rayDirection, out hit))
            {
                if (hit.collider.tag == "Player")
                {
                    // call the function of the enemy this object belongs to
                    spotter.BecomeAlerted();
                }
            }
        }
    }
}