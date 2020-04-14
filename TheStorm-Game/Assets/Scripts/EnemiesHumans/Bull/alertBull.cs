using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LAST UPDATED 12 April 2020

public class alertBull : MonoBehaviour
{
    // SCRIPTS //
    public Bull bull;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the script from the grandparent
        bull = GetComponentInParent<Transform>().parent.GetComponentInParent<Bull>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // if collided with by the player or other enemy
        if (!bull.alerted && (other.tag == "Player"))
        {
            RaycastHit hit;
            player = FindObjectOfType<Player>().transform;
            Vector3 rayDirection = player.position - transform.position;
            if (Physics.Raycast(transform.position, rayDirection, out hit))
            {
                if (hit.collider.tag == "Player")
                {
                    // call the function of the enemy this object belongs to
                    bull.BecomeAlerted();
                }
            }
        }
    }
}
