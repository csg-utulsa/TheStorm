using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AlienPickup is the base class for
/// picking up and apply the buffs
/// from the Alien.
/// </summary>
public class AlienPickup : Pickup
{

    public Alien alien;

    /*
     * Currently unimplemented.
     * If there is any common behavior
     * from AlienPickups that need to happen
     * in Update, put it here.
     */
    new void Update() {}

    /// <summary>
    /// Handles the acquisition of the Alien.
    /// </summary>
    protected override void PickUp()
    {

        Debug.Log("Alien picked up.");

        alien.ApplyBuff();

    }

}
