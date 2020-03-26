using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alertBull : MonoBehaviour
{
    // SCRIPTS //
    public Bull bull;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the script from the grandparent
        bull = GetComponentInParent<Transform>().parent.GetComponentInParent<Bull>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // if collided with by the player or other enemy
        if (!bull.alerted && (other.tag == "Player" || other.tag == "Enemy"))
        {
            // call the function of the enemy this object belongs to
            bull.BecomeAlerted();
        }
    }
}
