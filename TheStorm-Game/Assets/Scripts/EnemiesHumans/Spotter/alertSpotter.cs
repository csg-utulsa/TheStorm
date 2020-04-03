using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LAST UPDATED DEC 17 2019

public class alertSpotter : MonoBehaviour
{
    // SCRIPTS //
    public Spotter spotter;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the script from the grandparent
        spotter = GetComponentInParent<Transform>().parent.GetComponentInParent<Spotter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // if collided with by the player or other enemy
        if (spotter != null && !spotter.alerted && (other.tag == "Player" || other.tag == "Enemy"))
        {
            // call the function of the enemy this object belongs to
            spotter.BecomeAlerted();
        }
    }
}