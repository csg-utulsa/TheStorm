using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AlienPickupTrigger is responsible for
/// trigger the Alien Pickup.
/// </summary>
public class AlienPickupTrigger : Pickup
{

    /***** Public Variables *****/
    public Alien alien;
    
    /// <summary>
    /// Pickup the Alien
    /// </summary>
    protected override void PickUp()
    {

        Debug.Log("PickUp");

        alien.PickUp();

        Destroy(gameObject);

    }

}
