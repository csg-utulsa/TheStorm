using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LAST UPDATED DEC 17 2019

public class alertEnemy : MonoBehaviour
{
    // SCRIPTS //
    public Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the script from the grandparent
        enemy = GetComponentInParent<Transform>().parent.GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // if collided with by the player or other enemy
        if (other.tag == "Player" || other.tag == "Enemy")
        {
            // call the function of the enemy this object belongs to
            enemy.BecomeAlerted();
        }
    }
}
