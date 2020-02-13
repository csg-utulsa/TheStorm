using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LAST UPDATED DEC 17 2019

public class alertSniper : MonoBehaviour
{
    // SCRIPTS //
    public Sniper sniper;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the script from the grandparent
        sniper = GetComponentInParent<Transform>().parent.GetComponentInParent<Sniper>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // if collided with by the player or other enemy
        if (!sniper.alerted && (other.tag == "Player" || other.tag == "Enemy"))
        {
            // call the function of the enemy this object belongs to
            sniper.BecomeAlerted();
        }
    }
}