using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Attributes")]
    //How often the fire method of the gun can be called
    public float fireRate;
    //How much damage bullets from this gun will do
    public float damage;
    //The 2d sprite corresponding to this weapon
    public Sprite weaponSprite;

    //If the trigger is held down
    private bool isFiring;
    //Time since Fire() was last called
    private float timeSinceLastShot;

    protected string ownerTag;

    // Start is called before the first frame update
    void Start()
    {
        isFiring = false;
        timeSinceLastShot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceLastShot <= 0)
        {
            if (isFiring)
            {
                Fire();

                timeSinceLastShot = fireRate;
            }
        }
        else
        {
            timeSinceLastShot -= Time.deltaTime;
        }
    }

    /// <summary>
    /// Called when the trigger is pulled
    /// </summary>
    public virtual void StartFiring()
    {
        isFiring = true;
    }

    /// <summary>
    /// Called when the trigger is released
    /// </summary>
    public virtual void StopFiring()
    {
        isFiring = false;
    }

    /// <summary>
    /// Called periodically while the trigger is held
    /// Based on the fire rate of the gun
    /// </summary>
    protected virtual void Fire()
    {

    }

    public void setOwnerTag(string ot)
    {
        ownerTag = ot;
    }
}
