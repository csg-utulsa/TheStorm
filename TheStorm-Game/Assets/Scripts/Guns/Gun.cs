using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Gun Attributes")]
    //How often the fire method of the gun can be called
    public float fireRate;
    //Angle bullets can deviate from straight
    public float inaccuracy;
    [Header("Bullet Attributes")]
    //How much damage bullets from this gun will do
    public float damage;
    //How long bullets from this gun will travel in seconds
    public float range;
    //How fast bullets from this gun travel
    public float bulletVelocity;
    //What type of bullet is shot from this gun
    public BulletTypes bulletType;

    //If the trigger is held down
    private bool isFiring;
    //Time since Fire() was last called
    private float timeSinceLastShot;

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
            if(isFiring)
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
        SpawnBullet();
    }

    /// <summary>
    /// Spawns a bullet using the attributes defined in editor
    /// </summary>
    protected virtual void SpawnBullet()
    {
        float offset = Random.Range(-inaccuracy / 2, inaccuracy / 2);
        
        BulletSpawner.Spawn(transform, damage, range, bulletVelocity, bulletType, offset);
    }

    /// <summary>
    /// Spawns a bullet with a specific Bullet Type
    /// </summary>
    /// <param name="bt">The bullet Type of the spawned bullet</param>
    protected virtual void Fire(BulletTypes bt)
    {
        float offset = Random.Range(-inaccuracy / 2, inaccuracy / 2);

        BulletSpawner.Spawn(transform, damage, range, bulletVelocity, bt, offset);
    }

    /// <summary>
    /// Spawns a bullet at the given angle
    /// </summary>
    /// <param name="angle">The angle of the bullet in degrees from forward</param>
    protected virtual void SpawnBullet(float angle)
    {
        BulletSpawner.Spawn(transform, damage, range, bulletVelocity, bulletType, angle);
    }

    /// <summary>
    /// Spawns a bullet with both a given type and angle
    /// </summary>
    /// <param name="bt">Type of the spawned bullet</param>
    /// <param name="angle">Angle of the spawned bullet in degrees from forward</param>
    protected virtual void SpawnBullet(BulletTypes bt, float angle)
    {
        BulletSpawner.Spawn(transform, damage, range, bulletVelocity, bt, angle);
    }
}
